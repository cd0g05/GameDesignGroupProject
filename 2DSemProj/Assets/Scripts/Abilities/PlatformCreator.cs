using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    private int numOfPlatformsActive;
    private int maxPlatforms;

    // Start is called before the first frame update
    void Start()
    {
        maxPlatforms = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && numOfPlatformsActive < maxPlatforms) 
        {
            Vector2 platformPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            StartCoroutine(DestroyPlatform(Instantiate(platform, platformPos, platform.transform.rotation)));
            numOfPlatformsActive++;
            // Animation
            //
        }
    }

    private IEnumerator DestroyPlatform(GameObject platformToDestroy)
    {
        yield return new WaitForSeconds(7);
        //animation
        Destroy(platformToDestroy);
        numOfPlatformsActive--;

    }
}
