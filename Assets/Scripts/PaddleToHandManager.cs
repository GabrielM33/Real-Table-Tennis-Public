using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class PaddleToHandManager : MonoBehaviour
{
    [SerializeField] private HandGrabInteractor _handGrabInteractorRight;
    [SerializeField] private HandGrabInteractable _handGrabInteractableRight;
    
    [SerializeField] private HandGrabInteractor _handGrabInteractorLeft;
    [SerializeField] private HandGrabInteractable _handGrabInteractableLeft;
    
    [SerializeField] private DominantHandManager _dominantHandManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_dominantHandManager.isRightHand)
        {
            _handGrabInteractorRight.ForceSelect(_handGrabInteractableRight, true);
        }
        else
        {
            _handGrabInteractorLeft.ForceSelect(_handGrabInteractableLeft, true);
        }
        
    }
}
