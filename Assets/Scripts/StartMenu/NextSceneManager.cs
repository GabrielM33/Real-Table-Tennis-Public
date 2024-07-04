using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class NextSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _toScale; 
    
    [SerializeField] private List<GameObject> _currentSceneParent; 
    [SerializeField] private List<GameObject> _nextSceneParent; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToNextScene()
    {
        StartCoroutine(ToNextScene());
    }
    
    private IEnumerator ToNextScene()
    {
        if (_toScale != null)
        {
            _toScale.transform.DOShakeScale(0.25f, 0.25f, 5);
            yield return new WaitForSeconds(0.25f);
            _toScale.transform.DOScale(Vector3.zero, 1.5f);
            yield return new WaitForSeconds(1.5f);
        }
        foreach (var scene in _nextSceneParent)
        {
            scene.SetActive(true);
        }
        foreach (var scene in _currentSceneParent)
        {
            scene.SetActive(false);
        }
        
    }
}
