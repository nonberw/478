using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float runSpeed = 10f;
    private float currentSpeed;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        currentSpeed = PoliceChase.IsChasing ? runSpeed : normalSpeed;
        Vector3 dir = new Vector3(h, 0, v);
        if (dir.magnitude > 1f)
        {
            dir.Normalize();
        }

        transform.Translate(dir * currentSpeed * Time.deltaTime, Space.World);
    }
}
