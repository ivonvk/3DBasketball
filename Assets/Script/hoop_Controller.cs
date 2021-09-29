using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoop_Controller : MonoBehaviour {
    Rigidbody rb;
    Transform pos;
    float speed;
    float a;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        pos = GetComponent<Transform>();
        speed = -0.8f;
        a = 1f;

    }
	
	// Update is called once per frame
	void Update () {
        
        if(a > 0)
        {
            a -= 1 * Time.deltaTime;
        }
        else
        {
            a = 0;
        }
        if ((pos.position.x >1.5f || pos.position.x < -1.5f)&& a == 0)
        {
            speed = speed* -1f;
            a = 1f;
            Debug.Log("changed");
        }
        if (a == 0)
        {
            Debug.Log("unchanged");
        }
        rb.velocity = new Vector3(speed, 0, 0);
        
    }
}
