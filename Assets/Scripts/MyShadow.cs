using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShadow : MonoBehaviour
{
    public Transform target;
    public float raycastDistance = 2;
    public LayerMask layerMask;
    public float radius = 0.2f;
    public float verticalOffset = 0.002f;

    private Material shadowMaterial;
    private int _baseColorShaderID;
    // Start is called before the first frame update
    void Start()
    {
        shadowMaterial = GetComponent<Renderer>().material;
        _baseColorShaderID = Shader.PropertyToID("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit raycastHit;
        // bool hasHit = Physics.SphereCast(target.position, radius, Vector3.down, out raycastHit, raycastDistance, layerMask, QueryTriggerInteraction.UseGlobal);
        RaycastHit hit;
        if (Physics.Raycast(target.position, Vector3.down, out hit, 10f))
        {
            
            transform.position = new Vector3(target.position.x, hit.point.y + verticalOffset, target.position.z);

            float distant = target.position.y - hit.point.y;
            float alpha = (raycastDistance - distant) / raycastDistance;
            shadowMaterial.SetColor(_baseColorShaderID,new Color(1,1,1,alpha));
        }
    }
}
