using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterScr : MonoBehaviour
{
    CharacterController CharController;
    Vector3 moveDir;

    public float speed;
    float ySpeed;
    public float jumpForce;
    public float gravity = -20f;
    Animator anim;
    Rigidbody rb;

    public int hp;

    

    // Start is called before the first frame update
    void Start()
    {
        CharController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        CharacterMove();

        Jump();

        attack();

        HpIndicator();
    }


    void CharacterMove()
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        CharController.Move(moveDir.normalized * speed * Time.deltaTime);
        if (moveDir.normalized != Vector3.zero)
        {

            if (Input.GetKey(KeyCode.LeftShift))
            {

                speed = 20f;
            }
            else
            {

                speed = 0.01f;
            }
            //CharController.Move(moveDir.normalized * speed * Time.deltaTime);

            anim.SetBool("move", true);

            transform.forward = moveDir;
        }

        else
        {
            anim.SetBool("move", false);
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0);
            CharController.Move(moveDir.normalized * jumpForce * Time.deltaTime);
        }
        
    }

    void attack()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            anim.Play("Attack1");

        }
    }

    void HpIndicator()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

}
