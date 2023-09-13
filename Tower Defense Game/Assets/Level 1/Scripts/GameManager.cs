using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text pointsRoundText;
    public GameObject gameOver;

    public int money;

    public GameObject[] rounds;
    public float[] roundDelay;
    private int round = 1;
    public int lives = 100;

    private bool roundInProgress = false;

    private void Update()
    {
        if (!roundInProgress && rounds.Length >= round)
        {
            StartCoroutine("RoundSpawner");
        }

        pointsRoundText.text = "Points: " + money + "\n" + "Round: " + round + "\n" + "Lives: " + lives;

        if(lives <= 0)
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }

    IEnumerator RoundSpawner()
    {
        roundInProgress = true;
        for (int i = 0; i < rounds[round - 1].transform.childCount; i++)
        {
            Instantiate(rounds[round - 1].transform.GetChild(i));
            yield return new WaitForSeconds(roundDelay[round - 1]);
        }
        yield return new WaitForSeconds(10);
        round++;
        roundInProgress = false;
    }
}