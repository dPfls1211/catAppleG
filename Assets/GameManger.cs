using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour {
    public Text scoreText;
    public int currentScore = 0;
	// Use this for initialization
	void Start () {
        scoreText.text = "score : " + currentScore.ToString();
	}
    public void upScore()
    {
        currentScore+=10;
        scoreText.text = "score : " + currentScore.ToString();
    }
}
