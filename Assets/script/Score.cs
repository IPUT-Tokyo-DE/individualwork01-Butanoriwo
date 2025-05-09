using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public GameObject fScore;
    public GameObject sScore;
    public GameObject tScore;
    public GameObject grade;
    [SerializeField] private int kibishisa;
  int score = 0;

    private TMP_Text firstScore;
    private TMP_Text secondScore;
    private TMP_Text thirdScore;
    private TMP_Text eater;

    // Start is called before the first frame update
    void Start()
    {
        firstScore = fScore.GetComponent<TMP_Text>();
        secondScore = sScore.GetComponent<TMP_Text>();
        thirdScore = tScore.GetComponent<TMP_Text>();
        eater = grade.GetComponent<TMP_Text>();

        score = GameManager.umami * 100 - GameManager.katame * 50 - GameManager.damage * 50;
        if (GameManager.first < score)
        {
            GameManager.third = GameManager.second;
            GameManager.second = GameManager.first;
            GameManager.first = score;
        }
        else if (GameManager.second < score)
        {
            GameManager.third = GameManager.second;
            GameManager.second = score;
        }
        else if (GameManager.third < score)
        {
            GameManager.third = score;
        }
        if (2900 < score)
        {
            eater.text += "ŽāøČ";
        }
        else
        {
            if (kibishisa < GameManager.katame)
            {
                eater.text += "°aŌĖ";
            }
            else
            {
                eater.text += "ÜÜ";
            }

            if (kibishisa < GameManager.damage)
            {
                eater.text += "õß";
            }
            else
            {
                eater.text += "ĘĖ";
            }
        }

        eater.text += "Ũ";

}

    // Update is called once per frame
    void Update()
    {
        firstScore.text = "1Ę: " + GameManager.first.ToString();
        secondScore.text = "2Ę: " + GameManager.second.ToString();
        thirdScore.text = "3Ę: " + GameManager.third.ToString();
    }

}
