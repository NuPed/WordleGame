using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI textCount, textAnswer;
    public GameObject winGameobject, loseGameobject, ans_Gameobject, count_Gameobject;

    public void CountText(int count)
    {
        textCount.text = "Guess Count: ";
        textCount.text += count.ToString();
    }
    public void RevealAnswer(string answer)
    {
        textAnswer.text = answer.ToString();
    }

    public void Win()
    {
        winGameobject.SetActive(true);
        ans_Gameobject.SetActive(true);
        count_Gameobject.SetActive(true);
    }

    public void Lose()
    {
        loseGameobject.SetActive(true);
        ans_Gameobject.SetActive(true);
        count_Gameobject.SetActive(true);
    }

    public void ReplayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

