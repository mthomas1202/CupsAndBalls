using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public bool canPick = false;
    public bool picked = false;
    public bool won = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (canPick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;

                if(Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    Debug.Log(hit.transform.name);
                }
            }
        }
	}
}
