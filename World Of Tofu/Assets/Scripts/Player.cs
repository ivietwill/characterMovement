using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float movementSpeed = 5f; //Speed Moving
    public int forceConst = 3;

    private bool canJump; //Jumping
    private Rigidbody selfRigidbody;
    private bool changeColor;

    // Start is called before the first frame update
    void Start()
    {
        selfRigidbody = GetComponent <Rigidbody>();
        
    }

    
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)) {
            canJump = true;
        }

        if(Input.GetKeyUp("c"))
            changeColor = true;
            
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey("w")) {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
        } else if (Input.GetKey("w") && !Input.GetKey(KeyCode.LeftShift)) {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        } else if (Input.GetKey("s")) {
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }

        if(Input.GetKey("a") && !Input.GetKey("d")){
            transform.position += transform.TransformDirection (Vector3.left) * Time.deltaTime * movementSpeed;
        } else if ( Input.GetKey ("d") && !Input.GetKey("a")) {
            transform.position -= transform.TransformDirection (Vector3.left) * Time.deltaTime * movementSpeed;
        }

        if(canJump) {
            canJump = false;
            selfRigidbody.AddForce (0, forceConst, 0 , ForceMode.Impulse);
        }
        
        if(changeColor){
            changeColor = false;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        } 
        
        /*
        if(Input.GetKey ("c")){
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        */


      /*  Jump();   

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed; */

    }

    void Jump(){
        if (Input.GetButtonDown("Jump")){
        gameObject.GetComponent<Rigidbody2D>() .AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }
}
