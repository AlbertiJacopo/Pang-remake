using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public int Score = 0;
    public int Time = 0;
    public Text HealthTxt;
    public Text ScoreTxt;
    public Text TimeTxt;
    private HealthComponent m_Health;

    public void SetScore()
    {
        Score = Score + 100;
        ScoreTxt.text = "Score: " + Score;
    }

    public void SetLifes()
    {
        HealthTxt.text = "Life(s): " + m_Health.LifeCount;
    }

    public IEnumerator SetTime()
    {
        TimeTxt.text = "Time: " + Time;
        while (Time > 0)
        {
            yield return new WaitForSeconds(1f);
            Time -= 1;
        }
    }

    private void Start()
    {
        StartCoroutine(SetTime());
        m_Health = GetComponent<HealthComponent>();
    }
}
