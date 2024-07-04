using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLineCheck : MonoBehaviour
{
    [SerializeField] private CustomHandPoseAnimationManager _customHandPoseAnimationManager;

    private void OnTriggerExit(Collider other)
    {
        // Debug.Log("Exit " + other.lay);
        _customHandPoseAnimationManager.ResetHands();
        if (other.CompareTag("Hand"))
        {
            
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
