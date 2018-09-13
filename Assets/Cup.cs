using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour {

    public float downHeight = 1.3f;
    public float upHeight = 1.46f;
    public float movingSpeed = 3f;

    public Player player;
    public GameObject ball;

    public Vector3 targetPosition;
	// Use this for initialization
	void Start () {

        targetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * movingSpeed);

        if(ball != null)
        {
            ball.transform.position = new Vector3(
                transform.position.x,
                ball.transform.position.y,
                transform.position.z);
        }
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

    public void Check()
    {
        if (player.canPick)
        {
            MoveUp();
            player.canPick = false;
            player.picked = true;
            player.won = (ball != null);
        }
    }
}
