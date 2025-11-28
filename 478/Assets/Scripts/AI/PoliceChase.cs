using UnityEngine;
using UnityEngine.AI;

public class PoliceChase : MonoBehaviour
{
    public Transform player;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float chaseSpeed = 8f;
    public float attackRange = 15f;
    public float fireRate = 2f;

    private NavMeshAgent agent;
    private float nextFire;

    public static bool IsChasing;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = chaseSpeed;
    }

    public static void StartChase()
    {
        GameObject prefab = Resources.Load<GameObject>("PolicePrefab");
        if (prefab == null)
        {
            Debug.LogError("PolicePrefab не найден в Resources!");
            return;
        }

        GameObject cop = Object.Instantiate(prefab, new Vector3(10, 0, 10), Quaternion.identity);
        var chase = cop.GetComponent<PoliceChase>();
        chase.player = GameObject.FindGameObjectWithTag("Player").transform;
        IsChasing = true;
    }

    void Update()
    {
        if (!IsChasing || player == null)
        {
            return;
        }

        agent.SetDestination(player.position);
        float dist = Vector3.Distance(transform.position, player.position);

        if (dist <= attackRange && Time.time >= nextFire)
        {
            Shoot();
            nextFire = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = (player.position - firePoint.position).normalized * 20f;
        }
    }
}
