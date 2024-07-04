using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class OnBallPracticeHit : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.CompareTag("Paddle"))
    //     {
    //         rigidbody.useGravity = true;
    //         rigidbody.isKinematic = false;
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paddle"))
        {
            
            rigidbody.useGravity = true;
            // rigidbody.isKinematic = false;
            // var direction = rigidbody.transform.position - other.transform.position;
            // rigidbody.AddForce(other.attachedRigidbody.velocity, ForceMode.VelocityChange);
        }
        
        // StartCoroutine(ToNextScene());
    }
    
    // IEnumerator ToNextScene()
    // {
    //     _toScale.transform.DOShakeScale(2f, 0.25f, 5);
    //     yield return new WaitForSeconds(2);
    //     _toScale.transform.DOScale(Vector3.zero, 1.5f).onComplete(
    //         
    //     );
    // }
}
