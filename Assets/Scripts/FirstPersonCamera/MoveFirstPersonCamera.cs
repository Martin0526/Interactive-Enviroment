using Unity.VisualScripting;
using UnityEngine;

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


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // karaktären kan inte ramla omkull
    }


    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal"); 
        float vInput = Input.GetAxisRaw("Vertical");

        Vector3 moveVector = (transform.forward * vInput) + (transform.right * hInput);

        if (moveVector.magnitude > 1f)  //Inga måsvingar när if statement endast är en rad (normaliserar fart på karaktär)
            moveVector = moveVector.normalized;

        moveVector *= moveSpeed;

        //kollar om man står på marken
        grounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight * 0.5f) + 0.2f, whatIsGround);

        float verticalSpeed = rb.linearVelocity.y;

        //om man står på marken kan du gå
        if (grounded)
            rb.linearVelocity = new Vector3(moveVector.x, verticalSpeed, moveVector.z);

    }
}
