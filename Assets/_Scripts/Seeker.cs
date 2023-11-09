using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Seeker : MonoBehaviour
{

    private GameObject player;
    public NavMeshAgent agent;
    public PlayerScript pScript;
    public Animator animator;
    public LayerMask groundlayer;
    private Collider enemyCollider;
    private Vector3 walkPoint;
    public float walkPointRange;
    private bool walkpointset;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float turnSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyCollider = GetComponent<Collider>();
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Player") == true)
        {
          pScript.speed = 0f;
          pScript.jumpStrength = 0f;
          pScript.sensitivity = 0f;
          animator.SetBool("Dead", true);
          enemyCollider.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rotationHandle(player.transform.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void rotationHandle(Vector3 GO)
    {
        Quaternion _lookRotation = Quaternion.LookRotation((GO - transform.position).normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * turnSpeed);
    }

    void Patrol()
    {
        if (!walkpointset)SearchWalkPoint();
        if(walkpointset)
        {
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceWalkPoint = transform.position - walkPoint;

        if(distanceWalkPoint.magnitude < 1f)
        {
            walkpointset = false;
        }
    }

    void SearchWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if(Physics.Raycast(walkPoint, -transform.up, 1f, groundlayer))
        {
            walkpointset = true;
        }
    }
    
}
