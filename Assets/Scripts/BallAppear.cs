using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAppear : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab; 
    [SerializeField] private GameObject palmL;
    [SerializeField] private GameObject palmR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void MakeBallLeft()
    {
        // Vector3 middle = (indexFingerTip.transform.position + thumbFingerTip.transform.position) / 2f;
        // Instantiate(ballPrefab, middle, transform.rotation);
        Instantiate(ballPrefab, palmL.transform.position + Vector3.up * 0.03f, transform.rotation);
    }
    
    public void MakeBallRight()
    {
        // Vector3 middle = (indexFingerTip.transform.position + thumbFingerTip.transform.position) / 2f;
        // Instantiate(ballPrefab, middle, transform.rotation);
        Instantiate(ballPrefab, palmR.transform.position + Vector3.up * 0.03f, transform.rotation);
    }

    private void OnDrawGizmos()
    {
        // Gizmos.color = Color.blue;
        // Gizmos.DrawSphere(Vector3.zero, 1f);
        
        // Vector3 middle = (indexFingerTip.transform.position + thumbFingerTip.transform.position) / 2f;
        
        // Gizmos.DrawSphere(palmL.transform.position  + Vector3.up * 0.03f, 0.02f);
    }
}
