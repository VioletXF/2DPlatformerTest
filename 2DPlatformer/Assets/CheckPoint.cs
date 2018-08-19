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
    void OnTriggerStay2D(Collider2D col)
    {
        if(Input.GetKeyDown(KeyCode.F))
        if (col.tag == "character")
        {
                GetComponent<SpriteRenderer>().color=col.GetComponent<SpriteRenderer>().color;
                NewBehaviourScript crt = col.GetComponent<NewBehaviourScript>();

                crt.startPos = col.transform.position;
                crt.startGrav = col.GetComponent<Rigidbody2D>().gravityScale;
                crt.startRot = col.transform.rotation;
                crt.startRotVel = col.GetComponent<Rigidbody2D>().angularVelocity;
                crt.startVel = col.GetComponent<Rigidbody2D>().velocity;
                crt.startAirJump = ((NewBehaviourScript)col.GetComponent<NewBehaviourScript>()).airJump;

        }
    }
}
