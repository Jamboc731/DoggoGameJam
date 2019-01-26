using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DoggoController : MonoBehaviour {

    #region PublicVars
    public Transform doggo;
    public Rigidbody rb;
    public float moveSpeed;
    public float turnSpeed;
    public bool canControl = true;
    public float jumpForce;
    public float jumpRandomness;
    public float jumpPercentage;
    public float drag;
    public float gravity;
    public float multiplier;
    #endregion

    #region Private Vars
    private float badHandling = 1;
    private float xInput;
    private float zInput;
    private bool toJump;
    private Ray ray;
    private RaycastHit hit;
    private bool canJump = false;
    private bool playing = true;
    #endregion

    private void Start()
    {

        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {

        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        doggo.Rotate(transform.up * turnSpeed * xInput);

        if (canControl)
        {
            rb.AddForce(transform.forward * moveSpeed * zInput);
        }
        ray = new Ray(doggo.position, -doggo.up);
        Physics.Raycast(ray, out hit, 2f);

        if (hit.collider != null)
            canJump = true;
        else
            canJump = false;

        if (canJump)
        {

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }

    }

    private void FixedUpdate()
    {
        
        rb.velocity -= new Vector3(0, gravity, 0) * Time.fixedDeltaTime;

        if (rb.velocity.y <= 0)
            gravity = 50;
        else
            gravity = 30;
    }

    private void Jump()
    {

        rb.AddForce(((transform.up * 3 + transform.forward) * jumpForce) + (transform.right * Random.Range(-jumpRandomness, jumpRandomness) * badHandling), ForceMode.Impulse);

    }

    private void Turn()
    {



    }

}
