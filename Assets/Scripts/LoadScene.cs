using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;

    private void OnCollisionEnter2D(Collision2D other)
    {
        SceneManager.LoadScene(sceneName);
    }
}
