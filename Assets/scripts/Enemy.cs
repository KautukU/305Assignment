using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] Transform target;
    NavMeshAgent agent;
    public float startTimeBtwShots;
    private float timeBtwShots;
    private bool inRange = false;

    [Header("Shooting Laser")]
    public GameObject laser;
    public Transform EnemyLaserSpawn;
    public float speed = 20.0f;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    void Update()
    {

        target = player.transform;
        if (inRange)
        {
            Vector2 direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
            transform.up = direction;
            agent.SetDestination(target.position);
            if (timeBtwShots <= 0)
            {
                GameObject shootLaser = Instantiate(laser, EnemyLaserSpawn.position, EnemyLaserSpawn.rotation);
                Rigidbody2D rbody = shootLaser.GetComponent<Rigidbody2D>();
                rbody.AddForce(EnemyLaserSpawn.up * speed, ForceMode2D.Impulse);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                
                timeBtwShots -= Time.deltaTime;
            }
        }
        else
        {
            agent.SetDestination(transform.position);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            inRange = false;
        }
    }
}
