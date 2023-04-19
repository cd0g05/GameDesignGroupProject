using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private Vector2 levelSelectPos;
    [SerializeField] private GameObject inventoryNotFullMessage;

    // for pause menu
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().name.Substring(0, 3).Equals("Lev"))
        {
            pauseButton.SetActive(true);
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
                print("Restart");
                RestartScene();
            }

            //loads title screen
            if (Input.GetKeyDown(KeyCode.T))
            {
                print("Title");
                ToStart();
            }

            if (Input.GetMouseButtonDown(0) && SceneManager.GetActiveScene().name.Substring(0, 3).Equals("Lev"))
            {
                GameObject.Find("Player").GetComponent<Transform>().position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
    }

    //moves to start scene
    public void ToStart()
    {
        SceneManager.LoadScene("Title");
    }

    //moves to controls scene
    public void ToControlsScene()
    {
        SceneManager.LoadScene("Controls Scene");
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



    
}
