using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelected : MonoBehaviour
{
    public string selectedLevel;
    // Start is called before the first frame update

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        selectedLevel = "";
        if (GameObject.FindGameObjectsWithTag("SelectedLevel").Length > 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
