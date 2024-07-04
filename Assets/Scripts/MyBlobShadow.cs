using System.Collections;
using System.Collections.Generic;
using Meta.XR.SharedAssets;
using UnityEngine;

public class MyBlobShadow : MonoBehaviour
{
     //Moves the blobshadow on the collider underneath and dims it's intensity according to it's owner's position.
        [Tooltip("The transform that this shadow should belong to, if not specified it will take its direct parent.")]
        [SerializeField] GameObject _shadowOwner;
        // float _maxDist;
        float _minDist = 0f;
        Color _defaultCol;
        Renderer _rend;
        
        [SerializeField] float _maxDist = 1f;
        void Start()
        {
            if (!_shadowOwner)
            {
                _shadowOwner = this.transform.parent.gameObject;
            }
            _rend = GetComponent<Renderer>();
            _defaultCol = _rend.material.GetColor("_Color");
            RaycastHit hit;
            // if (Physics.Raycast(_shadowOwner.transform.position, Vector3.down, out hit, 10f))
            // {
            //     _minDist = Vector3.Distance(_shadowOwner.transform.position, hit.point);
            //     _maxDist = _minDist * 2;
            // }
        }
        void Update()
        {
            this.transform.position = _shadowOwner.transform.position;
            RaycastHit hit;
            if (Physics.Raycast(_shadowOwner.transform.position, Vector3.down, out hit, 10f))
            {
                
                this.transform.position = hit.point + (hit.normal.normalized) * 0.001f;
                this.transform.rotation = Quaternion.LookRotation(-hit.normal);
                float distance = Vector3.Distance(_shadowOwner.transform.position, hit.point);
                if (distance < _maxDist)
                {
                    float a;
                    a = Mathf.Clamp01(Remap(distance, _minDist, _maxDist, 1f, 0f));
                    _rend.material.SetColor("_Color", new Color(_defaultCol.r, _defaultCol.g, _defaultCol.b, a));
                }
                else
                {
                    _rend.material.SetColor("_Color", new Color(_defaultCol.r, _defaultCol.g, _defaultCol.b, 0f));
                }
            }
        }

        float Remap(float value, float fromMin, float fromMax, float toMin, float toMax)
        {
            return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
        }
}
