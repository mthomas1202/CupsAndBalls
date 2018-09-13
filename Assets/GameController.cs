using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject ball;
    public Cup[] cups;

	// Use this for initialization
	void Start () {
        StartCoroutine(ShuffleRoutine());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator ShuffleRoutine()
    {
        yield return new WaitForSeconds(1f);

        foreach (Cup cup in cups)
        {
            cup.MoveUp();
        }

        yield return new WaitForSeconds(0.5f);

        Cup targetCup = cups[Random.Range(0, cups.Length)];
        targetCup.ball = ball;
        ball.transform.position = new Vector3(
            targetCup.transform.position.x,
            ball.transform.position.y,
            targetCup.transform.position.z);

        yield return new WaitForSeconds(1.0f);

        foreach (Cup cup in cups)
        {
            cup.MoveDown();
        }

        Debug.Log("Cups Moved Down");

        yield return new WaitForSeconds(1f);


        Debug.Log("For loop reached");
        for(int i = 0; i < 5; i++)
        {
            Debug.Log("Loop: " + i);
            Cup cup1 = cups[Random.Range(0, cups.Length)];
            Cup cup2 = cup1;

            while(cup2 == cup1)
            {
                cup2 = cups[Random.Range(0, cups.Length)];
            }

            Vector3 cup1Position = cup1.targetPosition;
            cup1.targetPosition = cup2.targetPosition;
            cup2.targetPosition = cup1Position;

            yield return new WaitForSeconds(0.74f);
        }
    }
}
