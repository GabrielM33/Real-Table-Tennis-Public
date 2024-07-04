using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuAppear : MonoBehaviour
{
    [SerializeField] private GameObject ballMenu1Prefab; 
    [SerializeField] private GameObject ballMenu2Prefab; 
    [SerializeField] private GameObject ballMenu3Prefab;
    
    [SerializeField] private GameObject ballMenuGroup;
    
    [SerializeField] private GameObject ballMenu1GameObject; 
    [SerializeField] private GameObject ballMenu2GameObject; 
    [SerializeField] private GameObject ballMenu3GameObject;
    
    [SerializeField] private Rigidbody ballMenu1Rigibody; 
    [SerializeField] private Rigidbody ballMenu2Rigibody; 
    [SerializeField] private Rigidbody ballMenu3Rigibody;

    private List<GameObject> instantiatedMenus = new List<GameObject>();
    
    
    [SerializeField] private GameObject leftPalm;
    [SerializeField] private GameObject rightPalm;
    
    [SerializeField] private DominantHandManager dominantHandManager;
    [SerializeField] private GameObject leftOutline;
    [SerializeField] private GameObject rightOutline;
    
    // Start is called before the first frame update
    void Start()
    {
        if (dominantHandManager != null)
        {
            if (dominantHandManager.isRightHand)
            {
                rightOutline.SetActive(true);
                leftOutline.SetActive(false);
            }
            else
            {
                leftOutline.SetActive(true);
                rightOutline.SetActive(false);
            }
        }
        
        
        instantiatedMenus.Add(ballMenu1GameObject);
        instantiatedMenus.Add(ballMenu2GameObject);
        instantiatedMenus.Add(ballMenu3GameObject);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void MakeBallMenuLeft()
    {
        if(leftPalm == null) return;
        // add animation
        // GameObject menu1 = Instantiate(ballMenu1Prefab, leftPalm.transform.position + Vector3.up * 0.3f + Vector3.left * 0.15f, transform.rotation);
        // GameObject menu2 = Instantiate(ballMenu2Prefab, leftPalm.transform.position + Vector3.up * 0.3f, transform.rotation);
        // GameObject menu3 = Instantiate(ballMenu3Prefab, leftPalm.transform.position + Vector3.up * 0.3f + Vector3.right * 0.15f, transform.rotation);
        //
        // instantiatedMenus.Add(menu1);
        // instantiatedMenus.Add(menu2);
        // instantiatedMenus.Add(menu3);
        //
        // ApplyPopUpAnimation(menu1);
        // ApplyPopUpAnimation(menu2);
        // ApplyPopUpAnimation(menu3);
        
        // ballMenu1GameObject.transform.position = leftPalm.transform.position + Vector3.up * 0.3f + Vector3.left * 0.15f;
        // ballMenu2GameObject.transform.position = leftPalm.transform.position + Vector3.up * 0.3f;
        // ballMenu3GameObject.transform.position = leftPalm.transform.position + Vector3.up * 0.3f + Vector3.right * 0.15f;
        
        ballMenuGroup.transform.position = leftPalm.transform.position + Vector3.up * 0.3f;

        MakeVeocityZero(ballMenu1Rigibody);
        MakeVeocityZero(ballMenu2Rigibody);
        MakeVeocityZero(ballMenu3Rigibody);

        // ballMenu1GameObject.transform.rotation = transform.rotation;
        // ballMenu2GameObject.transform.rotation = transform.rotation;
        // ballMenu3GameObject.transform.rotation = transform.rotation;
        foreach (GameObject menu in instantiatedMenus)
        {
            ApplyPopUpAnimation(menu);
        }
    }

    private void MakeVeocityZero(Rigidbody r)
    {
        
            r.velocity = Vector3.zero;
            r.angularVelocity = Vector3.zero;
        
    }
    
    public void MakeBallMenuRight()
    {
        if(rightPalm == null) return;
        // add animation
        // GameObject menu1 = Instantiate(ballMenu1Prefab, rightPalm.transform.position + Vector3.up * 0.3f + Vector3.left * 0.15f, transform.rotation);
        // GameObject menu2 = Instantiate(ballMenu2Prefab, rightPalm.transform.position + Vector3.up * 0.3f, transform.rotation);
        // GameObject menu3 = Instantiate(ballMenu3Prefab, rightPalm.transform.position + Vector3.up * 0.3f + Vector3.right * 0.15f, transform.rotation);
        //
        // instantiatedMenus.Add(menu1);
        // instantiatedMenus.Add(menu2);
        // instantiatedMenus.Add(menu3);
        
        // ballMenu1GameObject.transform.position = rightPalm.transform.position + Vector3.up * 0.3f + Vector3.left * 0.15f;
        // ballMenu2GameObject.transform.position = rightPalm.transform.position + Vector3.up * 0.3f;
        // ballMenu3GameObject.transform.position = rightPalm.transform.position + Vector3.up * 0.3f + Vector3.right * 0.15f;
        
        ballMenuGroup.transform.position = rightPalm.transform.position + Vector3.up * 0.3f;
        MakeVeocityZero(ballMenu1Rigibody);
        MakeVeocityZero(ballMenu2Rigibody);
        MakeVeocityZero(ballMenu3Rigibody);
        // ballMenu1GameObject.transform.rotation = transform.rotation;
        // ballMenu2GameObject.transform.rotation = transform.rotation;
        // ballMenu3GameObject.transform.rotation = transform.rotation;
        foreach (GameObject menu in instantiatedMenus)
        {
            ApplyPopUpAnimation(menu);
        }
        
        
        // ApplyPopUpAnimation(menu2);
        // ApplyPopUpAnimation(menu3);
    }

    private void ApplyPopUpAnimation(GameObject menu)
    {
        menu.SetActive(true);
        Vector3 startScale = Vector3.zero;
        Vector3 targetScale = Vector3.one;
        float duration = 0.3f;
        
        menu.transform.localScale = startScale;
        StartCoroutine(ScaleOverTime(menu.transform, targetScale, duration));
    }

    private IEnumerator ScaleOverTime(Transform menuTransform, Vector3 targetScale, float duration)
    {
        float elapsedTime = 0f;
        Vector3 initialScale = menuTransform.localScale;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            menuTransform.localScale = Vector3.Lerp(initialScale, targetScale, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        menuTransform.localScale = targetScale;
    }

    public void DestructBallMenu()
    {
        foreach (GameObject menu in instantiatedMenus)
        {
            menu.SetActive(false);
            // Destroy(menu);
        }
        // instantiatedMenus.Clear();
    }

    // private void OnDrawGizmos()
    // {
    //     // Gizmos.color = Color.blue;
    //     // Gizmos.DrawSphere(Vector3.zero, 1f);
    //     
    //     Vector3 middle = (indexFingerTip.transform.position + thumbFingerTip.transform.position) / 2f;
    //     
    //     Gizmos.DrawSphere(palm.transform.position  + Vector3.up * 0.03f, 0.02f);
    // }
}
