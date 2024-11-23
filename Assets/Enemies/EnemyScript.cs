using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int movementSpeed;
    public GameObject body;
    private Rigidbody2D rb;

    public float wallCheckDis;

    private Vector2 directionMotion;
    public Vector2 TargetPos;
    private bool hasPath;

    // Start is called before the first frame update
    void Start()
    {
        rb = body.GetComponent<Rigidbody2D>();
    }

    public Vector2 getTargetPos()
    {

        hasPath = true;
        return new Vector2();
    }

    public void followPath()
    {
        // Get direction of motion in x
        float xDif = TargetPos.x - gameObject.transform.position.x;
        float yDif = TargetPos.y - gameObject.transform.position.y;
        directionMotion = new Vector2(Mathf.Abs(xDif) / xDif, 0);

        // Check to make sure there isnt a wall there
        Physics2D.Raycast((Vector2)transform.position, directionMotion * wallCheckDis, wallCheckDis);



    }

    private void movement()
    {
        if (!hasPath) getTargetPos();
        else followPath();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
