using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    public float speed = 5;

    public float jumpforce = 10;
    public float gravity = -20;

    public Transform groundCheck;
    public Transform wallCheck;

    public LayerMask groundLayer;
    public LayerMask wallLayer;

   

    //public bool lookingRight;

    public float ogspeed;

    
    // Start is called before the first frame update

    void Start()
    {
        ogspeed = 20;
    }

    // Update is called once per frame
    void Update()
    {
       
        direction.x = Time.deltaTime * 60 * speed;

        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);

        bool isNearWall = Physics.CheckSphere(wallCheck.position, 0.15f, wallLayer);

        controller.Move(direction * Time.deltaTime);

        direction.y += gravity * Time.deltaTime;


        if (isGrounded)
        {
            

            if (Input.GetKeyDown(KeyCode.W))
            {
                direction.y = jumpforce;
                SoundManager.PlaySound("Jump");
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                
                    transform.localScale = new Vector3(1f, 0.5f, 1f);
                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
                //speed /= 2;
                SoundManager.PlaySound("Slide");

            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                
                    transform.localScale = new Vector3(1f, 1f, 1f);
                    transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
                //speed *= 2;
                

            }

        }


        if (isNearWall && isGrounded)
        {
            transform.RotateAround(transform.position, transform.up, 180f);
            speed *= -1;

            
        }

        if(!isNearWall && isGrounded)
        {
            if (speed > ogspeed)
            {
                //speed /= 2;
            }
        }

        if(isNearWall && !isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                transform.RotateAround(transform.position, transform.up, 180f);
                speed *= -1;
                direction.y = jumpforce;
                SoundManager.PlaySound("Jump");

            }
            /*
            if (Input.GetKeyDown(KeyCode.S))
            {

                transform.RotateAround(transform.position, transform.up, 180f);
                speed *= -1;

            }
            else if (Input.GetKeyUp(KeyCode.S))
            {

                transform.RotateAround(transform.position, transform.up, 180f);
                speed *= -1;
                
            }
            */
        }
    }

}
