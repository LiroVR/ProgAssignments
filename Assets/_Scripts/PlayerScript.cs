using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed, jumpStrength;
    private Rigidbody rigiBoy;
    private Renderer pRender;
    private Vector2 moveVector, rotate;
    private Animator animator;
    private Coroutine currentCoroutine;
    public float sensitivity = 5f;
    [SerializeField, Range(0, 180)] private float viewAngleClamp = 40f;
    private bool onGround, dJump, isAttacking, hasntShot, weaponShootToggle;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform camFollowTarget;
    [SerializeField] private Transform projectilePos;
    //[SerializeField] private GameObject projectile, shootAudio;
    [SerializeField] private WeaponBase myWeapon;

    Color redColour = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    Color greenColour = new Color(0.0f, 1.0f, 0.0f, 1.0f);

    private Actions pActions;

    void Awake()
    {
        pActions = new Actions(); //Initializes and assigns the actions
        rigiBoy = GetComponent<Rigidbody>(); //Fetches the rigidbody
        animator = GetComponent<Animator>(); //Fetches the animator
        pRender = GameObject.Find("Player").GetComponent<Renderer>(); //Sets the renderer target to the player
    }

    void OnEnable()
    {
        pActions.Player.Enable(); //Enables the player action map
    }

    void OnCollisionStay() //Very basic on-ground detection. Just checks if the collider is touching anything
    {
        if(rigiBoy.velocity.y < 0.001) //Makes sure that the rigidboy is truly on the ground, by making sure it's not moving up or down (only works on flat ground)
        {
            onGround = true;
            dJump = true;
            //Debug.Log("Grounded");
            //pRender.material.SetColor("_Color", greenColour); //Sets the player to be green when grounded
        }
    }

    void Jump()
    {
        if (onGround)
        {
            rigiBoy.AddForce((Vector3.up * jumpStrength), ForceMode.Impulse);
            onGround = false;
        }
        else if(dJump) //Adds the ability to double jump
        {
            rigiBoy.AddForce((Vector3.up * jumpStrength), ForceMode.Impulse);
            dJump = false;
        }
    }

    private void Shoot()
    {
        isAttacking = !isAttacking;
        //if (isAttacking) weapon.StartAttack();
        //Rigidbody rbBullet = Instantiate(projectile, projectilePos.position, Quaternion.identity).GetComponent<Rigidbody>();
        //rbBullet.AddForce(Vector3.forward*32f,ForceMode.Impulse);
        //for (int x = 0; x < 3; x++)
        //{
            //shootAudio.gameObject.SetActive(true);
            //Rigidbody instantiatedProjectile = Instantiate(projectile, projectilePos.position, projectilePos.rotation).GetComponent<Rigidbody>();
            //instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, 25));
            //instantiatedProjectile.AddForce(transform.TransformDirection(new Vector3(0, 0, 1)) * 50,ForceMode.Impulse);
            //yield return new WaitForSeconds(0.05f);
        //}
        weaponShootToggle = !weaponShootToggle;
        //Debug.Log("In Shoot");
        if (weaponShootToggle)
        {
            //shootAudio.gameObject.SetActive(true);
            //Debug.Log("Attempted Shooting");
            myWeapon.StartShooting();
        }
        else
        {
            //shootAudio.gameObject.SetActive(false);
            myWeapon.StopShooting();
        }
        
        //Rigidbody instantiatedProjectile = Instantiate(projectile, projectilePos.position, projectilePos.rotation).GetComponent<Rigidbody>();
        //instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, 25));
        //instantiatedProjectile.AddForce(transform.TransformDirection(new Vector3(0, 0, 1)) * 50,ForceMode.Impulse);
        //yield return new WaitForSeconds(1f);
        //currentCoroutine = null;
    }

    public void SetLook(Vector2 direction)
    {
        rotate = direction;
        transform.rotation *= Quaternion.AngleAxis(direction.x * sensitivity, Vector3.up);
        camFollowTarget.rotation *= Quaternion.AngleAxis(direction.y * -sensitivity, Vector3.right);
        camFollowTarget.rotation *= Quaternion.AngleAxis(direction.x * -sensitivity, Vector3.up);

        Vector3 angles = camFollowTarget.eulerAngles;
        float anglesX = angles.x;
        if (anglesX > 180 && anglesX < 360-viewAngleClamp)
        {
            anglesX = 360-viewAngleClamp; //Used to limit the angle/amount of rotation to the clamp
        }
        else if (anglesX < 180 && anglesX > viewAngleClamp)
        {
            anglesX = viewAngleClamp;
        }

        camFollowTarget.localEulerAngles = new Vector3(anglesX, 0, 0); //Sets the rotation of the camera to limit rotation
    }

    void Update()
    {
        moveVector = pActions.Player.Movement.ReadValue<Vector2>(); //Gets the movement data from the Input system
        transform.Translate(Time.deltaTime * speed * moveVector.y * Vector3.forward); //Converts the data to be used in 3D space (changing y for z)
        transform.Translate(Time.deltaTime * speed * moveVector.x * Vector3.right); //Same as above, but responsible for x axis
        SetLook(pActions.Player.Look.ReadValue<Vector2>()); //Reading the 'Look' from the input system
        if (onGround)
        {
            animator.SetFloat("VelocityX", speed*moveVector.x); //Controls animator values to run the locomotion animations
            animator.SetFloat("VelocityZ", speed*moveVector.y);
            animator.SetBool("OnGround", true);
        }

        if (pActions.Player.Jump.triggered)
        {
            Jump();
        }
        if (pActions.Player.Shoot.triggered)
        {
            //if(hasntShot)
            //{
                //if(currentCoroutine == null)
                //{
                    //currentCoroutine = StartCoroutine(Shoot());
                //}
            //}
            Shoot();
            //hasntShot = false;
        }
        //if (!pActions.Player.Shoot.triggered)
        //{
            //hasntShot = true;
            //shootAudio.gameObject.SetActive(false);
        //}
        if(onGround == false)
        {
            animator.SetFloat("VelocityX", 0); //Resets the floats when in the air (not entirely necessary)
            animator.SetFloat("VelocityX", 0);
            animator.SetBool("OnGround", false);
            //pRender.material.SetColor("_Color", redColour); //Player becomes red when in the air
        }
    }
}
