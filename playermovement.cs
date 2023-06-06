using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    
    [SerializeField] Transform GrdChk;
    [SerializeField] LayerMask ground;
    [SerializeField] AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInp = Input.GetAxis("Horizontal");
        float verticalInp = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInp * moveSpeed, rb.velocity.y, verticalInp * moveSpeed);
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jump();
        }
    }
    void jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemy head"))
        {
            Destroy(collision.transform.parent.gameObject);
            jump();
        }
    }
    bool isGrounded()
    {
        return Physics.CheckSphere(GrdChk.position, 0.1f, ground);
    }
}
