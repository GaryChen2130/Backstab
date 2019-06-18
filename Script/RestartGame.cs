using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{

    public void Restart()
    {
        GameData.InitGame();
        SceneManager.LoadScene("start_scene", 0);
    }

}
