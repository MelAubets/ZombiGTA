using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene(2);
    }
}
