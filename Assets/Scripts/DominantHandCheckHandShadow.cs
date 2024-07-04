using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DominantHandCheckHandShadow : MonoBehaviour
{
    [SerializeField] DominantHandManager _dominantHandManager;
    [SerializeField] GameObject _leftPoseParent;
    [SerializeField] private GameObject _rightPoseParent;


    private void Start()
    {
        if (_dominantHandManager != null)
        {
            
            if (_dominantHandManager.isRightHand)
            {
                // _dominantHandManager.SetDominantHandRight();
                _leftPoseParent.SetActive(false);
                _rightPoseParent.SetActive(true);
            }
            else
            {
                // _dominantHandManager.SetDominantHandLeft();
                _leftPoseParent.SetActive(true);
                _rightPoseParent.SetActive(false);
            }
        }   
    }
}
