using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private float visiblePosZ = -6.5f;
    private GameObject gameOverText;
    private GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        this.gameOverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z < this.visiblePosZ)
        {
            this.gameOverText.GetComponent<Text>().text = "Game Over";
        }
    }

    void OnCollisionEnter(Collision other)
    {
        string objName = other.gameObject.name;
        if (objName.StartsWith("LargeStar"))
        {
            addScore(20);
        }
        else if (objName.StartsWith("SmallStar"))
        {
            addScore(10);
        }
        else if (objName.StartsWith("LargeCloud"))
        {
            addScore(50);
        }
        else if (objName.StartsWith("SmallCloud"))
        {
            addScore(30);
        }
    }

    void addScore(int score)
    {
        int currentScore = int.Parse(this.scoreText.GetComponent<Text>().text);
        currentScore += score;
        this.scoreText.GetComponent<Text>().text = currentScore.ToString();
    }
}
