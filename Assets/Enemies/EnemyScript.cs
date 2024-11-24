using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    
    public GameObject body;
    private Rigidbody2D rb;

    // characteristics
    [SerializeField] int movementSpeed;
    [SerializeField] int drag;

    [SerializeField] ObjData objData;

    // path following
    [SerializeField] List<GameObject> pos;
    private Vector2 directionMotion;
    private Vector2 TargetPos;
    private bool hasPath;
    public float wallCheckDis;
    public float difOffset;
    private int layer;

    // timer
    public float maxTimer;
    private float currentTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.drag = 10;

        layer = LayerMask.GetMask("Wall");
    }

    Vector2 getTargetPos()
    {
        TargetPos = objData.getRandomTarget(pos);
        hasPath = true;
        return new Vector2();
    }

    bool checkWall() => (Physics2D.Raycast((Vector2)transform.position, directionMotion, wallCheckDis, layer)) ? true : false;

    void followPath()
    {
        // Get direction of motion in x
        float xDif = TargetPos.x - gameObject.transform.position.x;
        float yDif = TargetPos.y - gameObject.transform.position.y;

        // checks to see if enemy completed path
        if (Mathf.Abs(xDif) < difOffset && Mathf.Abs(yDif) < difOffset)
        {
            hasPath = false;
            return;
        }

        directionMotion = new Vector2(Mathf.Abs(xDif) / xDif, 0); // sets direction of motion in the x direction by default

        // Check to make sure there isnt a wall there
        bool isWall = checkWall();
        if (isWall || Mathf.Abs(xDif) < difOffset)
        {
            directionMotion = new Vector2(0, Mathf.Abs(yDif) / yDif);
        }

        rb.AddForce(directionMotion * movementSpeed * Time.deltaTime, ForceMode2D.Impulse);
    }

    void throwLitter()
    {
        if (currentTimer < 0)
        {
            GameObject litterType = objData.getLitterObj();

            var litter = Instantiate(litterType);
            return;
        }
        currentTimer -= Time.deltaTime;
    }

    void movement()
    {
        if (!hasPath) getTargetPos();
        else followPath();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
}
