using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionController : MonoBehaviour
{
    [SerializeField] private GameObject text1;
    [SerializeField] private GameObject text2;
    [SerializeField] private GameObject text3;
    [SerializeField] private GameObject text4;
    
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject ballPosition;
    [SerializeField] private GameObject ballPositionLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnText1Finished(float delay)
    {
        StartCoroutine(SetWithDelay(delay, text1, text2));
    }
    
    public void OnText2Finished(float delay)
    {
        StartCoroutine(SetWithDelay(delay, text2, text3));
    }
    
    public void OnText3Finished(float delay)
    {
        StartCoroutine(SetWithDelay(delay, text3, text4));
    }

    public void SpawBall()
    {
        StartCoroutine(SetActiveWithDelay(1, ballPrefab));
      
    }
    
    public void SpawBallLeft()
    {
        StartCoroutine(SetActiveWithDelayLeft(1, ballPrefab));
      
    }

    private IEnumerator SetWithDelay(float delay, GameObject toInactive, GameObject toActive)
    {
        yield return new WaitForSeconds(delay);
        toInactive.SetActive(false);
        toActive.SetActive(true);
    }
    private IEnumerator SetActiveWithDelayLeft(float delay, GameObject toActive)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(ballPrefab, ballPositionLeft.transform.position, ballPositionLeft.transform.rotation);
        // toActive.SetActive(true);
    }
    private IEnumerator SetActiveWithDelay(float delay, GameObject toActive)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(ballPrefab, ballPosition.transform.position, ballPosition.transform.rotation);
        // toActive.SetActive(true);
    }
}
