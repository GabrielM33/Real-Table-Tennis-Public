using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CloseMenu : MonoBehaviour
{
    private Vector3 originalScale;
    void Start()
    {
        // originalScale = transform.localScale;
        // transform.localScale = Vector3.zero;
        // StartCoroutine(ToOpenMenu());
    }

    private void OnEnable()
    {
        // transform.DOScale(originalScale, 1f);
    }

    public void ActivateCloseMenu()
    {
        StartCoroutine(ToCloseMenu());
    }
    
    IEnumerator ToCloseMenu()
    {
        transform.DOShakeScale(0.5f, 0.1f, 3);
        yield return new WaitForSeconds(0.5f);
        transform.DOScale(Vector3.zero, 1f);
    }
    
    IEnumerator ToOpenMenu()
    {
        // transform.DOShakeScale(0.5f, 0.1f, 3);
        yield return new WaitForSeconds(1);
        transform.DOScale(originalScale, 1f);
    }
}
