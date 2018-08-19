using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    GameObject dest;
    int nowCrt = 0;
	// Use this for initialization
	void Start () {
        dest = GameObject.FindGameObjectsWithTag("character")[nowCrt];
	}
	
	// Update is called once per frame
	void LateUpdate () {


        //Debug.Log("time:" + Time.deltaTime);
        //Debug.Log("camera:"+transform.position);
        
        Vector3 pos = Vector3.Lerp(this.transform.position, dest.transform.position, 8.0f * Time.deltaTime);
        transform.position = new Vector3(pos.x, pos.y,transform.position.z);
        
	}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            nowCrt = (nowCrt + 1) % 2;
            dest = GameObject.FindGameObjectsWithTag("character")[nowCrt];
        }
    }
}
