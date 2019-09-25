using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    public Sprite flagClosed;
    public Sprite flagOpen;

    private SpriteRenderer theSpriteRenderer;

    public bool checkpointActive;
	// Use this for initialization
	void Start () {
        theSpriteRenderer = GetComponent<SpriteRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") // checkpoint once "Player" hit flag/
        {
            theSpriteRenderer.sprite = flagOpen;
            checkpointActive = true;
        }
    }
}
