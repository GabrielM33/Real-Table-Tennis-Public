using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class OnBallHit : MonoBehaviour
{
    [SerializeField] private NextSceneManager nextSceneManager; 
    
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
        // var a = LayerMask.NameToLayer("hand");
        if(other.gameObject.layer == LayerMask.NameToLayer("hand") || other.gameObject.layer == LayerMask.NameToLayer("paddle"))
        // if(((1<<other.gameObject.layer) & LayerMask.NameToLayer("hand")) != 0)
        {
            nextSceneManager.GoToNextScene();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("hand") || other.gameObject.layer == LayerMask.NameToLayer("paddle"))
        {
            nextSceneManager.GoToNextScene();
        }
        
    }

    
}
