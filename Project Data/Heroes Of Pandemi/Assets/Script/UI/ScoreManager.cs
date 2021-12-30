using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;

    Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        score = 0;
    }

    void Update()
    {
<<<<<<< HEAD
        scoreText.text = " " + score;
=======
        scoreText.text = score.ToString();
>>>>>>> 51b31aff13879f9e6f78b862d19ae0608c1af15f
    }
}
