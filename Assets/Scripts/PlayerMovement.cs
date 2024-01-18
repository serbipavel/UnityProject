using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /*float xMove;
    float zMove;*/
    [SerializeField]GameObject maincamera;

    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 2f;
    [SerializeField] int numOfJumps = 2;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Способ 2
        /*if (Input.GetKey(KeyCode.W)) zMove = 1;
        if (Input.GetKey(KeyCode.S)) zMove = -1;
        if (Input.GetKey(KeyCode.D)) xMove = 1;
        if (Input.GetKey(KeyCode.A)) xMove = -1;
        
        if (Input.GetKeyUp(KeyCode.W) ||  Input.GetKeyUp(KeyCode.S))
            zMove = 0;
        if (Input.GetKeyUp(KeyCode.D) ||  Input.GetKeyUp(KeyCode.A))
            xMove = 0;*/

        //Способ 1
        /*xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");*/

        //Способ 3
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            movement += maincamera.transform.forward;
        if (Input.GetKey(KeyCode.S))
            movement -= maincamera.transform.forward;
        if (Input.GetKey(KeyCode.A))
            movement -= maincamera.transform.right;
        if (Input.GetKey(KeyCode.D))
            movement += maincamera.transform.right;

        /*rb.velocity = new Vector3(xMove*speed, 0, zMove*speed);*/
        rb.velocity = new Vector3(movement.x*speed, rb.velocity.y,movement.z*speed);
        if (Input.GetKeyDown(KeyCode.Space) && numOfJumps>0)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            numOfJumps--;
        }
            
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
            numOfJumps = 2;
    }
}
