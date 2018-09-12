using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour {

    public float downHeight = 1.3f;
    public float upHeight = 1.46f;
    public float movingSpeed = 3f;

    public GameObject ball;

    private Vector3 targetPosition;
	// Use this for initialization
	void Start () {

        targetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * movingSpeed);
	}

    public void MoveUp()
    {
        targetPosition = new Vector3(
           transform.position.x,
           upHeight,
           transform.position.z
           );
    }

    public void MoveDown()
    {
        targetPosition = new Vector3(
           transform.position.x,
           downHeight,
           transform.position.z
           );
    }
}
