using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   // private Vector2 playerDirection;
  //  public float playerSpeed;

    public Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        //playerDirection = new Vector2();
       // playerDirection.x = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(1, 0);
    }
}
