using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongPaddleController : MonoBehaviour
{
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
}
