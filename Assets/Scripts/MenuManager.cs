using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public GameObject StartMenu;
    public GameObject InstructionMenu;
    public GameObject PoseGroup;

    public void OnStartMenuPressed()
    {
        
        StartCoroutine(StartInstructionMenu());
    }

    public IEnumerator StartInstructionMenu()
    {
        yield return new WaitForSeconds(1f);
        StartMenu.SetActive(false);
        InstructionMenu.SetActive(true);
        
        yield return new WaitForSeconds(2f);
        PoseGroup.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
