using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ControlsSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject movementText;
    [SerializeField] private GameObject inventoryText;
    [SerializeField] private GameObject inLevelText;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private AudioSource forwardSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        forwardSound.Play();

        if (inventoryText.activeInHierarchy)
        {
            movementText.SetActive(true);
            inventoryText.SetActive(false);
            backButton.SetActive(false);
        }

        else if (inLevelText.activeInHierarchy)
        {
            inventoryText.SetActive(true);
            nextButton.SetActive(true);
            inLevelText.SetActive(false);
        }
    }

    public void Next()
    {
        forwardSound.Play();

        if (movementText.activeInHierarchy)
        {
            inventoryText.SetActive(true);
            backButton.SetActive(true);
            movementText.SetActive(false);
        }

        else if (inventoryText.activeInHierarchy) {
            inLevelText.SetActive(true);
            inventoryText.SetActive(false);
            nextButton.SetActive(false);
        }
    }
}
