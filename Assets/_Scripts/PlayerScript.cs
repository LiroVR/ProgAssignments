using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed, jumpStrength;
    private Rigidbody rigiBoy;
    private Vector2 moveVector;
    private bool onGround, dJump;

    private Actions pActions;

    void Awake()
    {
        pActions = new Actions(); //Initializes and assigns the actions
        rigiBoy = GetComponent<Rigidbody>(); //Fetches the rigidbody
    }

    void OnEnable()
    {
        pActions.Player.Enable(); //Enables the player action map
    }

    void OnCollisionStay() //Very basic on-ground detection. Just checks if the collider is touching anything
    {
        if(rigiBoy.velocity.y < 0.01) //Makes sure that the rigidboy is truly on the ground, by making sure it's not moving up or down (only works on flat ground)
        {
            onGround = true;
            dJump = true;
            //Debug.Log("Grounded");
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

    void Update()
    {
        moveVector = pActions.Player.Movement.ReadValue<Vector2>(); //Gets the movement data from the Input system
        transform.Translate(Time.deltaTime * speed * moveVector.y * Vector3.forward); //Converts the data to be used in 3D space (changing y for z)
        transform.Translate(Time.deltaTime * speed * moveVector.x * Vector3.right); //Same as above, but responsible for x axis
        if (pActions.Player.Jump.triggered)
        {
            Jump();
        }
    }
}
