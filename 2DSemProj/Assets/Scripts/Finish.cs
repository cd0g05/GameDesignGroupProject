using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Hit");
        if (collision.gameObject.CompareTag("Player"))
        {
            //implement level complete screen
            //
            //
            
            string thisLevel = SceneManager.GetActiveScene().name;
            int nextLevelNum = int.Parse(thisLevel.Substring(6, 1)) + 1;
            string nextLevel = thisLevel.Substring(0, 6) + nextLevelNum;
            print(nextLevel);
            AddNextUnlockedLevel(nextLevel);
            SceneManager.LoadScene("LevelSelector");

        }
    }

    private void AddNextUnlockedLevel(string nextLevel)
    {
        foreach (string completedLevel in GameObject.Find("LevelsCompleted").GetComponent<CompletedLevel>().completedLevels)
        {
            if (completedLevel.Equals(nextLevel))
            {
                return;
            }
        }
        GameObject.Find("LevelsCompleted").GetComponent<CompletedLevel>().completedLevels.Add(nextLevel);
    }
}
