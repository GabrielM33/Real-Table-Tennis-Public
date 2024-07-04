using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class CustomHandData : MonoBehaviour
{
    public enum HandModelType { Left, Right}

    public HandModelType handType;
    public Transform root;
    public Transform[] fingerBones;
    public MaterialPropertyBlockEditor handMaterialPropertyBlockEditor;
    public readonly int OutlineColorID = Shader.PropertyToID("_OutlineColor");
    public readonly int OutlineOpacityID = Shader.PropertyToID("_OutlineOpacity");
    public readonly Color OutlineColorDefault = Color.white;
    public readonly Color OutlineColorActive = new Color(185, 255, 127, 255);
    public Renderer handRenderer;

    public Material HandMaterialDefault;
    public Material HandMaterialActive;
    [SerializeField]
    public GameObject poseActiveVisualPrefab;
    private void Start()
    {
        if (poseActiveVisualPrefab)
        {
            poseActiveVisualPrefab.SetActive(false);
        }
        
    }

    private void Update()
    {
        
    }

    public void SetHandMaterialActive()
    {
        handRenderer.material = HandMaterialActive;
    }
    
    public void SetHandMaterialDefault()
    {
        handRenderer.material = HandMaterialDefault;
    }
}
