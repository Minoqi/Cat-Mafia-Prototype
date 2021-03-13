using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //Variables

    public GameObject player;

    //Scenes
    public string winScene, loseScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WinLoseScene();
        QuitGame();
    }

    //Switch to Win or Lose Scene
    //Will get reworked to match the level system if greenlit, this is a temp win/loose state
    void WinLoseScene()
    {
        //Check if player died
        if(player.GetComponent<PlayerManager>().health <= 0)
        {
            SceneManager.LoadScene(loseScene);
        }

        //Check if player won
        if(player.GetComponent<PlayerManager>().cash >= 200)
        {
            SceneManager.LoadScene(winScene);
        }
    }

    void QuitGame()
    {
        if(Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
