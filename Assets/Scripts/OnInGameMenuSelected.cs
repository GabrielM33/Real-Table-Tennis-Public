using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnInGameMenuSelected : MonoBehaviour
{
    [SerializeField] private String sceneName;
    [SerializeField] private NextSceneManager _nextSceneManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("hand"))
        {
            HandleAnimationAndSelectMenu();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            HandleAnimationAndSelectMenu();
        }
    }

    private void HandleAnimationAndSelectMenu()
    {
        _nextSceneManager.GoToNextScene();
        // if (!string.IsNullOrEmpty(sceneName))
        // {
        //     if (sceneName == "TutorialScene")
        //     {
        //         
        //     }
        //     SceneManager.LoadScene(sceneName);
        // }
    }
}
