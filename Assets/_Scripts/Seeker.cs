using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour
{

    private GameObject player;
    [SerializeField] GameObject boowomp;
    public PlayerScript pScript;
    public Animator animator;
    private Collider enemyCollider;
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
          boowomp.gameObject.SetActive(true);
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

    
}
