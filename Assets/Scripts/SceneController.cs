using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{

    void Awake()
    {
        Time.timeScale = 1;
    }

    public void Load(string name)
    {
        
        SceneManager.LoadScene(name);
    }
}
