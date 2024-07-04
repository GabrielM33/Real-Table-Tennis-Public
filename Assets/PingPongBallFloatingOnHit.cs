using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PingPongBallFloatingOnHit : MonoBehaviour
{
    [SerializeField] private float minHitForce = 1f; 
    [SerializeField] private float maxHitForce = 5f;
    [SerializeField] private float speedMultiplier = 1f;
    
    private void OnCollisionEnter(Collision other)
    {
        Rigidbody ballRigidBody = gameObject.GetComponent<Rigidbody>();

        if (other.collider.CompareTag("Paddle"))
        {
            if (ballRigidBody != null)
            {
                ballRigidBody.useGravity = true;
                
                // ballRigidBody.mass = 0.10f;
                // ballRigidBody.drag = 0.2f;
                // ballRigidBody.angularDrag = 0.10f;

                
                float relativeSpeed = other.relativeVelocity.magnitude;
                float hitForce = Mathf.Lerp(minHitForce, maxHitForce, relativeSpeed / speedMultiplier);
                
                Debug.Log("Relative Speed: " + relativeSpeed);
                Debug.Log("Hit Force: " + hitForce);
                
                Vector3 hitDirection = other.contacts[0].normal;
                ballRigidBody.AddForce(hitDirection * hitForce, ForceMode.Impulse);
                
            }
        }
        else
        {
            return;
        }
    }
    
}
