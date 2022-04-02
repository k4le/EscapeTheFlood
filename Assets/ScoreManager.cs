using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highScoreText;

    double score = 0.0f;
    double highScore = 0.0f;

	private void Awake()
	{
        DontDestroyOnLoad(this);
	}

	void Start()
    {
        if (instance == null) // This is first object, set the static reference
         {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = score.ToString() + " POINTS";
        GameObject.FindGameObjectWithTag("HighScore").GetComponent<Text>().text = "HIGHSCORE: " + highScore.ToString();
        Destroy(this.gameObject);
    }

    public void AddPoints(double s)
	{
        if (s > score) {
            Debug.Log(highScore);
            score = s;
            GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = score.ToString() + " POINTS";
        }
	}
    public void PlayerDied()
	{
        if (highScore < score) {
            highScore = score;
		}
        score = 0;
        GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = score.ToString() + " POINTS";
        GameObject.FindGameObjectWithTag("HighScore").GetComponent<Text>().text = "HIGHSCORE: " + highScore.ToString();
    }

    void Update()
    {
        GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = score.ToString() + " POINTS";
        GameObject.FindGameObjectWithTag("HighScore").GetComponent<Text>().text = "HIGHSCORE: " + highScore.ToString();
    }
}
