using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    public GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay2D(Collider2D col)
    {
        
        if (col.tag == "character")
        {

            
            
            if (Vector2.Distance(col.transform.position,transform.position) <= 0.3f)
                if(Mathf.Abs(col.transform.rotation.eulerAngles.z % 90 - transform.rotation.eulerAngles.z % 90)<=20)
             col.transform.position = new Vector3(target.transform.position.x, target.transform.position.y);
            
        }
    }

}
