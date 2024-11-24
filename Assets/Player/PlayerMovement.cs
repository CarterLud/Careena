using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   // private Vector2 playerDirection;
    public float speed;

    public Rigidbody2D body;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        //playerDirection = new Vector2();
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        if(Mathf.Abs(xInput) > 0)
        {
            body.velocity = new Vector2(xInput * speed, body.velocity.y);
        }
        if(Mathf.Abs(yInput)>0)
        {
            body.velocity = new Vector2(body.velocity.x, yInput * speed);
        }
        Vector2 direction= new Vector2(xInput, yInput).normalized;

        body.velocity = direction * speed;
       
    }
}
