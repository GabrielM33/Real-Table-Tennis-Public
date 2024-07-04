using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomHandController : MonoBehaviour
{
    [SerializeField]
    private CustomHandData _customHandData;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetSelectedHandState()
    {
        if (_customHandData)
        {
            _customHandData.SetHandMaterialActive();
        }
        
    }
    
    public void SetUnselectedHandState()
    {
        if (_customHandData)
        {
            _customHandData.SetHandMaterialDefault();
        }
    }
}
