using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float crouchSpeed = 2.5f; // Скорость при приседании
    public GameObject projectile;
    public Transform shootPoint;
    public float shootForce = 700f;

    private CharacterController characterController;
    private float originalHeight;
    public float crouchHeight = 1f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalHeight = characterController.height;
    }

    void Update()
    {
        // Определяем движение
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool isCrouching = Input.GetKey(KeyCode.LeftControl);
        float currentSpeed = isCrouching ? crouchSpeed : speed;

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        characterController.Move(movement * currentSpeed * Time.deltaTime);

        // Изменяем высоту коллайдера для приседания
        if (isCrouching)
        {
            characterController.height = crouchHeight;
        }
        else
        {
            characterController.height = originalHeight;
        }

        // Стрельба
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject ball = Instantiate(projectile, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(shootPoint.forward * shootForce);
        }
    }
}
