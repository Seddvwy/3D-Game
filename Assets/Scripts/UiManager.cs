using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    [SerializeField]
    TextMeshProUGUI Score_TMP;
    [HideInInspector]
    public int Score;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScoreUI()
    {
        Score_TMP.text = Score.ToString();
    }

}
