using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DominantHandManager : MonoBehaviour
{
    [SerializeField] GameObject _leftHandGrabInteractor;
    [SerializeField] GameObject _rightHandGrabInteractor;
    [SerializeField] GameObject _leftHandAnchorTracking;
    [SerializeField] GameObject _rightHandAnchorTracking;
    [SerializeField] GameObject _pingPongPaddleR;
    [SerializeField] GameObject _pingPongPaddleL;
    [SerializeField] GameObject _dominantHandPoses;
    [SerializeField] public bool isRightHand = true;
    [SerializeField] public NextSceneManager nextSceneManager;
    public void SetDominantHandLeft(){
        _leftHandGrabInteractor.SetActive(true);
        _pingPongPaddleL.SetActive(false);
        _pingPongPaddleR.SetActive(false);
        isRightHand = false;
        // _pingPongPaddle.transform.SetParent(_leftHandAnchorTracking.transform);
        // _pingPongPaddle.transform.localPosition = new Vector3(-0.1219451f, -0.02127382f, -0.08375943f);
        // _pingPongPaddle.transform.localRotation = Quaternion.Euler(new Vector3(285,238,30));
        StartCoroutine(CloseDominantHandMenu());
    }

    public void SetDominantHandRight(){
        _rightHandGrabInteractor.SetActive(true);
        _pingPongPaddleR.SetActive(false);
        _pingPongPaddleL.SetActive(false);
        isRightHand = true;
        // _pingPongPaddle.transform.SetParent(_rightHandAnchorTracking.transform);
        // _pingPongPaddle.transform.localPosition = new Vector3(-0.1219451f, -0.02127382f, -0.08375943f);
        // _pingPongPaddle.transform.localRotation = Quaternion.Euler(new Vector3(82,112,198));

        StartCoroutine(CloseDominantHandMenu());

    }


    private IEnumerator CloseDominantHandMenu(){
        yield return new WaitForSeconds(1);
        if (nextSceneManager != null)
        {
            nextSceneManager.GoToNextScene();
        }
        
        // _dominantHandPoses.SetActive(false);

        
    }


}
