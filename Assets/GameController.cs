using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject ball;
    public Cup[] cups;
    public Player player;
    public TextMesh infoText;
    private float resetTimer = 3f;
	// Use this for initialization
	void Start () {
        infoText.text = "Pick the Correct Cup!";
        StartCoroutine(ShuffleRoutine());
	}
	
	// Update is called once per frame
	void Update () {
        if (player.picked)
        {
            if (player.won)
            {
                infoText.text = "You Win!";
            }
            else
            {
                infoText.text = "You Lose. Try Again.";
            }

            resetTimer -= Time.deltaTime;
            if(resetTimer <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
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


        yield return new WaitForSeconds(1f);

        for(int i = 0; i < 5; i++)
        {
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

        player.canPick = true;
    }
}
