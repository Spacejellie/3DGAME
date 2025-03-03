using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;

    private void Start()
    {
       
    }

    private void Update()
    {
       if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneName);
        }  
    }
}
