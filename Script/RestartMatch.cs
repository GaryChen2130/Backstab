using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartMatch : MonoBehaviour
{

    public void Rematch()
    {
        GameData.InitMatch();
        SceneManager.LoadScene("main_scene", 0);
    }

}
