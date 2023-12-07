using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public void Setup(int Score)
    {
        gameObject.SetActive(true);
        pointsText.text = Score.ToString() + "POINTS"; 
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Main");
    }


    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }



}
