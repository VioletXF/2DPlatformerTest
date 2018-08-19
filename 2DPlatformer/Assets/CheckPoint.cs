using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        OnTriggerStay2D(col);
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetKeyDown(KeyCode.F))
            if (col.tag == "character")
            {
                GetComponent<SpriteRenderer>().color = col.GetComponent<SpriteRenderer>().color;

                GameObject[] obj = GameObject.FindGameObjectsWithTag("character");
                float xoffset = 0;
                foreach (GameObject k in obj)
                {
                    NewBehaviourScript crt = k.GetComponent<NewBehaviourScript>();
                    crt.startPos = new Vector2(col.transform.position.x+xoffset,col.transform.position.y);
                    xoffset+=0.1f;
                    crt.startGrav = col.GetComponent<Rigidbody2D>().gravityScale;
                    crt.startRot = col.transform.rotation;
                    crt.startRotVel = col.GetComponent<Rigidbody2D>().angularVelocity;
                    crt.startVel = col.GetComponent<Rigidbody2D>().velocity;
                    crt.startAirJump = ((NewBehaviourScript)col.GetComponent<NewBehaviourScript>()).airJump;
                }
                obj = GameObject.FindGameObjectsWithTag("movablefloor");
                foreach (GameObject k in obj)
                {
                    MovableObject crt = k.GetComponent<MovableObject>();
                    crt.startPos = k.transform.position;
                    crt.startGrav = k.GetComponent<Rigidbody2D>().gravityScale;
                    crt.startRot = k.transform.rotation;
                    crt.startRotVel = k.GetComponent<Rigidbody2D>().angularVelocity;
                    crt.startVel = k.GetComponent<Rigidbody2D>().velocity;
                }
            }
    }
}
