using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private TextParticleSystemController _particlePrefab;
    [SerializeField] private GameObject _particleText;
    [SerializeField] private TMP_Text _text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Test");
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            BallInfo ballInfo = other.gameObject.GetComponent<BallInfo>();
            ballInfo.Count++;
            // _particlePrefab.text = "" + ballInfo.Count;
            _particlePrefab.text = "Good";
            TextParticleSystemController a = Instantiate(_particlePrefab, other.transform.position, _particlePrefab.transform.rotation);
            // a.text = "test";
            a.gameObject.SetActive(true);
            // _particleText.transform.position = other.transform.position;
            // Debug.Log("Test");
        
        }
    }
}
