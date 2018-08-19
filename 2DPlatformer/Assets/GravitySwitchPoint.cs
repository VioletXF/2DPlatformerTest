using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitchPoint : MonoBehaviour {

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
        
            if (col.tag == "character")
            {
                Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    
                    rb.gravityScale = Mathf.Abs(rb.gravityScale) * -1;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    rb.gravityScale = Mathf.Abs(rb.gravityScale);
                }

            }
    }
}
