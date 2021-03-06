﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class DoggoController : MonoBehaviour {

    #region PublicVars
    public Transform doggo;
    public Rigidbody rb;
    public OwnerScript own;
    public float moveSpeed;
    public float turnSpeed;
    public bool canControl = true;
    public float jumpForce;
    public float jumpRandomness;
    public float jumpPercentage;
    public float drag;
    public float gravity;
    public float multiplier;
    public bool canJump = false;
    public Animator doggoAnimator;
    #endregion

    #region Private Vars
    private float badHandling = 1;
    private float xInput;
    private float zInput;
    private bool toJump;
    private Ray ray;
    private RaycastHit hit;
    private bool playing = true;
    private bool shouldTurn = false;
    private int dir = 0;
    #endregion

    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        doggoAnimator = GetComponent<Animator>();

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        doggo.Rotate(transform.up * turnSpeed * xInput);

        if (canControl)
        {
            rb.AddForce(transform.forward * moveSpeed * zInput * (1 + (own.state / 3)));
        }
        ray = new Ray(doggo.position, -doggo.up);
        Physics.Raycast(ray, out hit, .5f);

        if (hit.collider != null)
        {
            canJump = true;
            canControl = true;
        }
        else
        {
            canJump = false;
            canControl = false;
        }

        if (canJump)
        {

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
        
        if (Random.Range(0, 1000) > (1000 - 5 * own.state))
        {
            if (Random.Range(0, 10) > 5)
                dir = 1;
            else
                dir = 0;
            StartCoroutine(RandomTurning());
        }
        if (shouldTurn)
        {
            Turn(dir);
        }

    }

    private void FixedUpdate()
    {
        
        rb.velocity -= new Vector3(0, gravity, 0) * Time.fixedDeltaTime;

        if (rb.velocity.y <= 0)
            gravity = 50;
        else
            gravity = 30;

        doggoAnimator.SetFloat("Speed", rb.velocity.magnitude);
    }

    public void Jump()
    {

        rb.AddForce(((transform.up * 3) * jumpForce) + (transform.right * Random.Range(-jumpRandomness, jumpRandomness) * badHandling), ForceMode.Impulse);

    }

    private void Turn(int dir)
    {

        doggo.Rotate(transform.up * (moveSpeed / 30) * dir);

    }

    IEnumerator RandomTurning()
    {
        shouldTurn = true;
        yield return new WaitForSeconds(1);
        shouldTurn = false;
        dir = 0;
    }

}
