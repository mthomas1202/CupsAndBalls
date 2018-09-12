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

    }
}
