using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("1 Level");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
