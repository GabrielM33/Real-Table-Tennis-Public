using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomHandPoseAnimationManager : MonoBehaviour
{
public float poseTransitionDuration = 3f;
    
    public GameObject handStartPrefab;
    
    public CustomHandData startHandPose;
    public CustomHandData nextHandPose;

    private Vector3 startingHandPosition;
    private Vector3 finalHandPosition;
    private Quaternion startingHandRotation;
    private Quaternion finalHandRotation;

    private Quaternion[] startingFingerRotations;
    private Quaternion[] finalFingerRotations;

    private GameObject _handStartPrefab;
    private bool IsStopAnimation;
    private bool IsRunning;
    
    [SerializeField]
    private float waitTimeStarting = 0.5f;
     
    [SerializeField]
    private Renderer _hand1Renderer;
    [SerializeField]
    private Renderer _hand2Renderer;
    
    private IEnumerator coroutine;
    
    public bool isEnableDemoMode;
    
    [SerializeField]
    private Renderer _pingpongPaddle1;
    [SerializeField]
    private Renderer _pingpongPaddle2;

    // Start is called before the first frame update
    void Start()
    {
        _handStartPrefab = Instantiate(handStartPrefab, startHandPose.transform.localPosition, handStartPrefab.transform.rotation);
        _handStartPrefab.SetActive(false);
        
        _hand2Renderer.enabled = false;
        if (_pingpongPaddle2 != null)
        {
            _pingpongPaddle2.enabled = false;
        }

        if (isEnableDemoMode)
        {
            ActivateTransition();
        }
        
    }

    public void ActivateTransition()
    {
        if(IsRunning) {return;}
        IsRunning = true;
        
        if (_pingpongPaddle1 != null)
        {
            _pingpongPaddle1.enabled = false;
        }
        _hand1Renderer.enabled = false;
        _handStartPrefab.SetActive(true);
        SetHandDataValues(startHandPose, nextHandPose);
        coroutine = SetHandDataRoutine(_handStartPrefab.GetComponent<CustomHandData>(), finalHandPosition,
            finalHandRotation, finalFingerRotations, startingHandPosition, startingHandRotation,
            startingFingerRotations);
        StartCoroutine(coroutine);

        if (isEnableDemoMode)
        {
            // _hand1Renderer.enabled = true;
        }
    }

    private void OnDisable()
    {
        Destroy(_handStartPrefab);
        IsStopAnimation = true;
    }


    public void SetHandDataValues(CustomHandData h1, CustomHandData h2)
    {
        startingHandPosition = new Vector3( h1.root.position.x / h1.root.localScale.x,
            h1.root.position.y / h1.root.localScale.y, h1.root.position.z / h1.root.localScale.z);
        finalHandPosition = new Vector3(h2.root.position.x / h2.root.localScale.x,
            h2.root.position.y / h2.root.localScale.y, h2.root.position.z / h2.root.localScale.z);

        startingHandRotation = h1.root.rotation;
        finalHandRotation = h2.root.rotation;

        startingFingerRotations = new Quaternion[h1.fingerBones.Length];
        finalFingerRotations = new Quaternion[h1.fingerBones.Length];

        for (int i = 0; i < h1.fingerBones.Length; i++)
        {
            startingFingerRotations[i] = h1.fingerBones[i].rotation;
            finalFingerRotations[i] = h2.fingerBones[i].rotation;
        }
    }

    public void SetHandData(CustomHandData h, Vector3 newPosition, Quaternion newRotation, Quaternion[] newBonesRotation)
    {
        h.root.position = newPosition;
        h.root.rotation = newRotation;

        for (int i = 0; i < newBonesRotation.Length; i++)
        {
            h.fingerBones[i].rotation = newBonesRotation[i];
        }
    }

    public IEnumerator SetHandDataRoutine(CustomHandData h, Vector3 newPosition, Quaternion newRotation, Quaternion[] newBonesRotation,Vector3 startingPosition, Quaternion startingRotation, Quaternion[] startingBonesRotation)
    {
        h.root.position = startingPosition;
        h.root.rotation = startingRotation;

        for (int i = 0; i < startingBonesRotation.Length; i++)
        {
            h.fingerBones[i].rotation = startingBonesRotation[i];
        }
        
        yield return new WaitForSeconds(waitTimeStarting);
        
        float timer = 0;

        while(timer < poseTransitionDuration)
        {
            Vector3 p = Vector3.Lerp(startingPosition, newPosition, timer / poseTransitionDuration);
            Quaternion r = Quaternion.Lerp(startingRotation, newRotation, timer / poseTransitionDuration);

            h.root.position = p;
            h.root.rotation = r;

            for (int i = 0; i < newBonesRotation.Length; i++)
            {
                h.fingerBones[i].rotation = Quaternion.Lerp(startingBonesRotation[i], newBonesRotation[i], timer / poseTransitionDuration);
            }

            timer += Time.deltaTime;
            yield return null;
        }
        
        // h.root.position = newPosition;
        // h.root.rotation = newRotation;
        //
        // for (int i = 0; i < newBonesRotation.Length; i++)
        // {
        //     h.fingerBones[i].rotation = newBonesRotation[i];
        // }

        // _hand2Renderer.enabled = true;
        
        if (isEnableDemoMode)
        {
            // _hand2Renderer.enabled = true;
        }
        
        
        if (!IsStopAnimation)
        {
            yield return new WaitForSeconds(2f);
            IsRunning = false;
            ActivateTransition();
        }
    }


    public void MirrorPose(CustomHandData poseToMirror, CustomHandData poseUsedToMirror)
    {
        Vector3 mirroredPosition = poseUsedToMirror.root.position;
        mirroredPosition.x *= -1;

        Quaternion mirroredQuaternion = poseUsedToMirror.root.rotation;
        mirroredQuaternion.y *= -1;
        mirroredQuaternion.z *= -1;

        poseToMirror.root.position = mirroredPosition;
        poseToMirror.root.rotation = mirroredQuaternion;

        for (int i = 0; i < poseUsedToMirror.fingerBones.Length; i++)
        {
            poseToMirror.fingerBones[i].rotation = poseUsedToMirror.fingerBones[i].rotation;
        }
    }

    public void ResetHands()
    {
        DisableAll();
        _hand1Renderer.enabled = true;
    }

    public void DisableAll()
    {
        IsStopAnimation = true;
        IsRunning = false;
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        _hand1Renderer.enabled = false;
        _hand2Renderer.enabled = false;
        _handStartPrefab.SetActive(false);
    }
    
    public void OnFinished()
    {
        if (nextHandPose.poseActiveVisualPrefab != null)
        {
            nextHandPose.poseActiveVisualPrefab.SetActive(true);
        }
        
        if (_handStartPrefab.TryGetComponent(out CustomHandData customHandData))
        {
            customHandData.SetHandMaterialActive();
        }
        // ResetHands();
    }

    public void OnUnfinished()
    {
        if (nextHandPose.poseActiveVisualPrefab != null)
        {
            nextHandPose.poseActiveVisualPrefab.SetActive(false);
        }
        
        if (_handStartPrefab.TryGetComponent(out CustomHandData customHandData))
        {
            customHandData.SetHandMaterialDefault();
        }
    }
}
