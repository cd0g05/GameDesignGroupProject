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
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //switches from start screen to level select
    public void StartToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    //moves from level select to start
    public void LevelSelectToStart()
    {
        SceneManager.LoadScene("Title");
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
        if (GameObject.Find("InventorySystem").GetComponent<InventoryMenu>().playerInventoryFull)
        {
            SceneManager.LoadScene(GameObject.Find("LevelSelector").GetComponent<LevelSelected>().selectedLevel);
        }
        else
        {
            StartCoroutine(InventoryNotFullMessage());
        }
    }

    private IEnumerator InventoryNotFullMessage()
    {
        inventoryNotFullMessage.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        inventoryNotFullMessage.SetActive(false);
    }
}
