using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public static LevelManager instance;
    public Transform Player;

    //public int score;
    public int levelItems;
    public Transform[] Particles;
    public Transform MainCanvas;

    public void GameOver()
    {
        GameOverScreen.Setup(UiManager.instance.Score);
    }

    public void Awake()
    {   
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
