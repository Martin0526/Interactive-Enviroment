using Unity.VisualScripting;
using UnityEngine;


// Creates components if they are not present
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class MoveFirstPersonCamera : MonoBehaviour
{
    Rigidbody rb;

    [Header("Movement")]
    public float moveSpeed = 5f;


    [Header("Ground Check")]
    public float playerHeight = 2f;
    public LayerMask whatIsGround;

    bool grounded;

    public cameraSwitch manager = new cameraSwitch();
    public pauseMeny pause = new pauseMeny();


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // karaktären kan inte ramla omkull
    }


    void Update()
    {

        //Get keyboard Input
        float hInput = Input.GetAxisRaw("Horizontal"); 
        float vInput = Input.GetAxisRaw("Vertical");

        //Create vector describing how much we want to move
        Vector3 moveVector = (transform.forward * vInput) + (transform.right * hInput);

        if (moveVector.magnitude > 1f)  //Inga måsvingar när if statement endast är en rad (Ensuring MoveVector is not above 1 by normalising)
            moveVector = moveVector.normalized;

        moveVector *= moveSpeed;

        //Check if character is on ground
        grounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight * 0.5f) + 0.2f, whatIsGround);

        //Move character
        float verticalSpeed = rb.linearVelocity.y;

        //om man står på marken kan du gå
        if (grounded && manager.Manager == 0)
        { 
            if (pause.pauseActive == false) 
                rb.linearVelocity = new Vector3(moveVector.x, verticalSpeed, moveVector.z);
        }
    }
}
