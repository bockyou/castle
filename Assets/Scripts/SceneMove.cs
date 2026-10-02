using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public void ToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void ToEasy()
    {
        SceneManager.LoadScene(1);
    }

    public void ToHard()
    {
        SceneManager.LoadScene(2);
    }
}