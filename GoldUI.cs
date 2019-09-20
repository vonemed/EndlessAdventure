using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{

    #region Singleton
    public static GoldUI instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public Text currentScore; 
    private int modifiedScore;

    void Start()
    {
        currentScore = GetComponentInChildren<Text>();
        int.TryParse(currentScore.text, out modifiedScore); // Converting string to int
        SetScore(0); 
    }

    public void SetScore(int _score) // Sets a new score and converts it to srting
    {
        modifiedScore += _score;
        currentScore.text = modifiedScore.ToString();
    }
}
