using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Clearing game memory
public class DestroyOverTime : MonoBehaviour {
    public float lifeTime;
	// Use this for initialization
	void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {
        //set amount of time, destroys object in world
        lifeTime = lifeTime - Time.deltaTime;  // Time.deltaTime = 1s/gamefps

        if (lifeTime <= 0f) // destroys copies
        {
            Destroy(gameObject);
        }



        //Debug.Log(Time.deltaTime); //puts message in console
    }
}
