using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Utils : MonoBehaviour
{
    public static void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}
