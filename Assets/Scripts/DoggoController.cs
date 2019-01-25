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
        StartCoroutine(GetHarder());

    }

    private void Update()
    {

        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        doggo.Rotate(transform.up * turnSpeed * xInput * badHandling);

        if (canControl)
        {
            rb.AddForce(transform.forward * moveSpeed * zInput * badHandling);
        }
        ray = new Ray(doggo.position, -doggo.up);
        Physics.Raycast(ray, out hit, 2f);

        if (hit.collider != null)
            canJump = true;
        else
            canJump = false;

        if (canJump)
        {

            if (Input.GetButton("Jump"))
            {
                Jump();
            }
        }

        ToJumpOrNotToJump();

    }

    private void FixedUpdate()
    {
        
        rb.velocity -= new Vector3(0, gravity, 0) * Time.fixedDeltaTime;

        if (rb.velocity.y <= 0)
            gravity = 50;
        else
            gravity = 30;
    }

    public void increaseHandling(float multiplier)
    {

        badHandling *= multiplier;

    }

    private void Jump()
    {

        rb.AddForce(((transform.up * 3 + transform.forward) * jumpForce) + (transform.right * Random.Range(-jumpRandomness, jumpRandomness) * badHandling), ForceMode.Impulse);

    }

    private void ToJumpOrNotToJump()
    {

        int shouldIJump = Random.Range(0, 1000);
        //Debug.Log(shouldIJump);
        if(canJump)
        if(shouldIJump > (1000 - (jumpPercentage * badHandling / 2)))
        {
            Jump();
        }

    }

    IEnumerator GetHarder()
    {
        while (playing)
        {
            yield return new WaitForSeconds(1);
            increaseHandling(multiplier);
        }
    }

}
