using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private GameObject LightCeiling;
    private List<GameObject> LightLampList;
    // Start is called before the first frame update
    void Start()
    {
        // LightCeiling = GameObject.FindGameObjectWithTag("LightCeiling");
        var l = GameObject.FindGameObjectsWithTag("LightLamp");
        if (l != null && l.Length > 0)
        {
            LightLampList = l.ToList();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LightCeilingBrightIntensity()
    {
        LightCeiling = GameObject.FindGameObjectWithTag("LightCeiling");
        Light light = LightCeiling.GetComponent<Light>();
        if (light == null) return;

        light.intensity = 3f;
        
        AdjustLightLamp(1.25f);
    }
    
    public void LightCeilingNormalIntensity()
    {
        LightCeiling = GameObject.FindGameObjectWithTag("LightCeiling");
        Light light = LightCeiling.GetComponent<Light>();
        if (light == null) return;

        light.intensity = 1.25f;

        AdjustLightLamp(0.3f);
    }
    
    public void LightCeilingDarkIntensity()
    {
        LightCeiling = GameObject.FindGameObjectWithTag("LightCeiling");
        Light light = LightCeiling.GetComponent<Light>();
        if (light == null) return;

        light.intensity = 0.5f;
        
        AdjustLightLamp(0.1f);
    }

    private void AdjustLightLamp(float intensity)
    {
        var l = GameObject.FindGameObjectsWithTag("LightLamp");
        if (l != null && l.Length > 0)
        {
            LightLampList = l.ToList();
        }

        foreach (var ligthLamp in LightLampList)
        {
            Light light = LightCeiling.GetComponent<Light>();
            if (light == null) return;
            light.intensity = intensity;
        }
    }
    public void LightColorSky()
    {
        LightCeiling = GameObject.FindGameObjectWithTag("LightCeiling");
        Light light = LightCeiling.GetComponent<Light>();
        if (light == null) return;

        light.colorTemperature = 14000f;
        
        AdjustLightLampColor(14000f);
    }
    public void LightColorWhite()
    {
        LightCeiling = GameObject.FindGameObjectWithTag("LightCeiling");
        Light light = LightCeiling.GetComponent<Light>();
        if (light == null) return;

        light.colorTemperature = 6650f;
        
        AdjustLightLampColor(6650f);
    }
    
    public void LightColorYellow()
    {
        LightCeiling = GameObject.FindGameObjectWithTag("LightCeiling");
        Light light = LightCeiling.GetComponent<Light>();
        if (light == null) return;

        light.colorTemperature = 4500f;
        
        AdjustLightLampColor(4500f);
    }
    
    private void AdjustLightLampColor(float color)
    {
        var l = GameObject.FindGameObjectsWithTag("LightLamp");
        if (l != null && l.Length > 0)
        {
            LightLampList = l.ToList();
        }

        foreach (var ligthLamp in LightLampList)
        {
            Light light = LightCeiling.GetComponent<Light>();
            if (light == null) return;
            light.colorTemperature = color;
        }
    }

    
}
