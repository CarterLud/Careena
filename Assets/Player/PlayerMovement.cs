using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //user input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
   
}

    



//pick up trash
    public class Trash : MonoBehaviour
    {
        public Trash inTrash;
        //the array/list to hold the trash
        public List<Trash> trashItems = new List<Trash>();

        public void AddTrash(Trash newTrash)
        {
            inTrash.AddTrash(newTrash);
        }
    }

