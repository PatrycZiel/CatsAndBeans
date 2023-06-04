using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public GameObject placeHolder;
    public void Restart()
    {
        placeHolder.BroadcastMessage("Zero");
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(5);
    }

    public void Level2()
    {
        placeHolder.BroadcastMessage("Zero");
        SceneManager.LoadScene(3);

    }
}
