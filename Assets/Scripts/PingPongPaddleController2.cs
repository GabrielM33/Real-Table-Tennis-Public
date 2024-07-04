using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongPaddleController2 : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectToOpen;
    [SerializeField] private GameObject _pingpongPaddle;
    [SerializeField] private MeshRenderer _pingPongPaddleMeshRendererenderer;
    public void ShowOutLine()
    {
        _pingPongPaddleMeshRendererenderer.enabled = true;
    }
    
    public void HideOutLine()
    {
        _pingPongPaddleMeshRendererenderer.enabled = false;
    }
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
        if (other.CompareTag("LeftHand"))
        {
            _pingpongPaddle.SetActive(false);
            _gameObjectToOpen.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LeftHand"))
        {
            _pingpongPaddle.SetActive(true);
            _gameObjectToOpen.SetActive(false);
        }
    }
}
