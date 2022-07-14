using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starts : MonoBehaviour {

    float span = 0.8f;
    float delta = 0;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        this.delta += Time.deltaTime;
        if(this.delta>this.span)
        Destroy(gameObject);
    }
}
