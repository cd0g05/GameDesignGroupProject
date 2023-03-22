using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public int waitTime1 = 1;
    // CinemachineBlend myBlend = new CinemachineBlend();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait1());        
        cam1.SetActive(true);
        cam2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator wait1()
    {
        yield return new WaitForSeconds(waitTime1);
        cam1to2(); 
    }

     void cam1to2()
    {
        cam1.SetActive(false);
        cam2.SetActive(true);
        // CinemachineBlend activeBlend = myBlend.ActiveBlend;
        // Debug.Log(activeBlend);

    }
}
