using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private Vector2 levelSelectPos;
    [SerializeField] GameObject inventoryNotFullMessage;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Substring(0, 3).Equals("Lev"))
        {
            GameObject.Find("LevelCanvas").SetActive(true);
        }
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            //loads title screen
            if (Input.GetKeyDown(KeyCode.T))
            {
                print("Title");
                SceneManager.LoadScene("Title");
            }

            if (Input.GetMouseButtonDown(0) && SceneManager.GetActiveScene().name.Substring(0, 3).Equals("Lev"))
            {
                GameObject.Find("Player").GetComponent<Transform>().position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
    }

    //switches from start screen to level select
    public void ToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    //moves from level select to start
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

    //moves from inventory selection back to start screen
    public void InventoryToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void InventoryToLevel()
    {
        SceneManager.LoadScene(GameObject.Find("LevelSelected").GetComponent<LevelSelected>().selectedLevel);
    }


    public void PauseGame()
    {
        GameObject.Find("PauseButton").SetActive(false);
        GameObject.Find("PauseMenu").SetActive(true);
        Time.timeScale = 0;
    }

    
}
