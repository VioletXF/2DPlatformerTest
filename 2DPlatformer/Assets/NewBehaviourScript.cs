using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour {
    Rigidbody2D rb;
    Rigidbody2D rborigin;
    float speed = 30f;
    bool isOnFloor = false;
    int defAirJump=0;
    public int airJump = 1;
    public int startAirJump = 1;
    public Vector3 startPos;
    public Quaternion startRot;
    public float startGrav;
    public float startRotVel;

    public LayerMask groundLayer;
    public Vector2 startVel;

    float distToGround;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<BoxCollider2D>().bounds.extents.y;
        startPos = transform.position;
        startGrav = rb.gravityScale;
        startRot = transform.rotation;
        startRotVel = rb.angularVelocity;
        startVel = rb.velocity;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R)) {
            Die();
        }
        isOnFloor=Physics2D.Raycast(transform.position, (rb.gravityScale > 0 ? 1 : -1) * Vector2.down, distToGround + 0.1f, name == "Red" ? LayerMask.GetMask("Orange") : LayerMask.GetMask("Red"));
        isOnFloor =isOnFloor||Physics2D.Raycast(transform.position, (rb.gravityScale>0?1:-1)*Vector2.down,distToGround+0.1f,groundLayer).collider!=null;
        if (Mathf.Abs(rb.velocity.x)<=8)
          rb.AddForce(new Vector2(speed*(Input.GetKey(KeyCode.LeftShift)?0.4f:1f) * ((Input.GetKey(KeyCode.A) ? -1.0f : 0.0f) + (Input.GetKey(KeyCode.D) ? 1.0f : 0.0f)), 0));
        else
         rb.velocity = new Vector2(8*(rb.velocity.x>0?1f:-1f), rb.velocity.y);

        rb.AddTorque(1f * ((Input.GetKey(KeyCode.RightArrow) ? -1 : 0)+ (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0)));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnFloor)
            {
                Jump();
            }
            else if (airJump != 0)
            {
                Jump();
                airJump--;
            }
        }
        //Debug.Log("x vel:" + rb.velocity.x);
       
        if ((rb.gravityScale>=0&&Input.GetKeyDown(KeyCode.S))||(rb.gravityScale<0&&Input.GetKeyDown(KeyCode.W)))
        {
            rb.AddForce(new Vector2(0, -500f * (rb.gravityScale > 0 ? 1f : -1f)));
        }

        if (transform.position.y <= -50||transform.position.y>=50)
        {
            Die();
        }
	}
    void Jump()
    {
        rb.AddForce(new Vector2(0, 500f*(rb.gravityScale>0?1f:-1f)));
    }
    void OnCollisionEnter2D(Collision2D col)
    {
       // Debug.Log("col enter: " + col.collider.tag);
        switch (col.collider.tag)
        {
            case "movablefloor":
            case "floor":
            case "character":
                airJump = defAirJump;
                break;
            case "obstacle":
                Die();
                break;
        }
         

        if (isOnFloor && Input.GetKey(KeyCode.Space) && !Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void Die()
    {
        transform.position = startPos;
        transform.rotation = startRot;
        rb.gravityScale = startGrav;
        rb.velocity = startVel;
        rb.angularVelocity = startRotVel;
        airJump = startAirJump;
    }
    

}

