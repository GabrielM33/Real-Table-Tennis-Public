using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using TMPro;
using UnityEngine;

public class TextParticleSystemController : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    public ParticleSystem textParticleSystem;
    private ParticleSystemRenderer rendererSystem;

    public AudioTrigger audioTrigger;

    public String text;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro.text = text;
        rendererSystem = textParticleSystem.GetComponent<ParticleSystemRenderer>();
        rendererSystem.mesh = textMeshPro.mesh;
        if (audioTrigger != null)
        {
            audioTrigger.PlayAudio();
        }

        
    }
}
