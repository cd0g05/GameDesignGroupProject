using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] private List<Button> levelButtons = new List<Button>();
    [SerializeField] private GameObject errorMessage;
    //private List<string> completedLevels = GameObject.Find("LevelsCompleted").GetComponent<CompletedLevel>().completedLevels;
    // Start is called before the first frame update
    void Start()
    {
        /*string completedLevel = GameObject.Find("LevelCompleted").GetComponent<CompletedLevel>().completedLevel;
        if (GameObject.Find(completedLevel) != null)
        {
            print("Found!");
            GameObject.Find(completedLevel).GetComponent<LevelButton>().isUnlocked = true;
        }*/

        //setting completed levels to unlock
        foreach (string completedLevel in GameObject.Find("LevelsCompleted").GetComponent<CompletedLevel>().completedLevels)
        {
            if (GameObject.Find(completedLevel) != null)
            {
                GameObject.Find(completedLevel).GetComponent<LevelButton>().isUnlocked = true;
            }
        }

        //visual appearance for unlocked and locked levels
        foreach (Button levelBut in levelButtons)
        {
            if (levelBut.GetComponent<LevelButton>().isUnlocked)
            {
                levelBut.GetComponent<Image>().color = Color.white;
            }
            else
            {
                levelBut.GetComponent<Image>().color = Color.gray;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ShowErrorMessage()
    {
        errorMessage.SetActive(true);
        yield return new WaitForSeconds(3);
        errorMessage.SetActive(false);
    }
}
