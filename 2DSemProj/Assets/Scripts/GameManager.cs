using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private Vector2 levelSelectPos;
    [SerializeField] private GameObject inventoryNotFullMessage;
    [SerializeField] public AudioSource forwardSound;

    // for pause menu
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private Image inventoryImage1;
    [SerializeField] private Image inventoryImage2;
    [SerializeField] private Image inventoryImage3;
    [SerializeField] private InventoryObject globalInventory;
    private GameObject levelButtonText;
    private string ability1Name;
    private string ability2Name;
    private string ability3Name;


    // Start is called before the first frame update
    void Start()
    {
        //globalInventory = (InventoryObject) AssetDatabase.LoadAssetAtPath("Assets/InventoryOb/Inventory.asset.meta", typeof(InventoryObject));
        //print(globalInventory.Container[0].item.name);
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().name.Substring(0, 3).Equals("Lev"))
        {
            SetAbilities();
            levelButtonText = GameObject.Find("LevelTitle");
            print("Level");
            pauseButton.SetActive(true);
            levelButtonText.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = SceneManager.GetActiveScene().name;
            //inventoryImage1 = 
        }

        else if (SceneManager.GetActiveScene().name.Substring(0, 9).Equals("Inventory"))
        {
            for (int k = 0; k < globalInventory.Container.Count; k++)
            {
                globalInventory.Container[k].amount = 0;
            }
        }
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //shortcuts
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //restarts scene
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartScene();
            }

            //loads title screen
            if (Input.GetKeyDown(KeyCode.T))
            {
                ToStart();
            }

            if (Input.GetMouseButtonDown(0) && SceneManager.GetActiveScene().name.Substring(0, 3).Equals("Lev"))
            {
                GameObject.Find("Player").GetComponent<Transform>().position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        //abilities
        if (SceneManager.GetActiveScene().name.Substring(0, 3).Equals("Lev"))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && ability1Name != null)
            {

            }
        }
    }

    // restarts scene
    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // loads level select scene
    public void ToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelector");
        forwardSound.Play();
    }

    //moves to start scene
    public void ToStart()
    {
        SceneManager.LoadScene("Title");
        forwardSound.Play();

    }

    //moves to controls scene
    public void ToControlsScene()
    {
        SceneManager.LoadScene("Controls Scene");
        forwardSound.Play();

    }


    //switches from level select screen to inventory selection
    public void LevelSelectToInventory(Button levelChosen)
    {
        if (levelChosen.GetComponent<LevelButton>().isUnlocked)
        {
            print("Unlocked");
            GameObject.Find("LevelSelected").GetComponent<LevelSelected>().selectedLevel = levelChosen.name;
            SceneManager.LoadScene("InventorySelect");
        }
        else
        {
            StartCoroutine(GameObject.Find("Levels").GetComponent<LevelMenu>().ShowErrorMessage());
        }
    }

    // loads selected level
    public void InventoryToLevel()
    {
        SceneManager.LoadScene(GameObject.Find("LevelSelected").GetComponent<LevelSelected>().selectedLevel);
        forwardSound.Play();
    }


    // freezes game and brings up pause menu
    public void PauseGame()
    {
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    // unfreezes game and closes pause menu
    public void UnPauseGame()
    {
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void SetAbilities()
    {
        for (int k = 0; k < globalInventory.Container.Count; k++)
        {
            if (globalInventory.Container[k].amount == 1)
            {
                if (ability1Name == null)
                {
                    ability1Name = globalInventory.Container[k].item.name;
                    print(ability1Name);
                }

                else if (ability2Name == null)
                {
                    ability2Name = globalInventory.Container[k].item.name;
                    print(ability2Name);
                }

                else if (ability3Name == null)
                {
                    ability3Name = globalInventory.Container[k].item.name;
                    print(ability3Name);
                }
            }
        }

        GameObject[] gameObjectsinScene = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject thisObject in gameObjectsinScene)
        {
            if (thisObject.name.Equals(ability1Name))
            {
                thisObject.SetActive(true);
            }

            else if (thisObject.name.Equals(ability2Name))
            {
                thisObject.SetActive(true);
            }

            else if (thisObject.name.Equals(ability3Name))
            {
                thisObject.SetActive(true);
            }
        }
    }



    
}
