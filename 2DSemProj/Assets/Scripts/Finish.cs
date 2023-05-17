using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    private Animator doorAnim;
    private GameObject wCanvas;
    [SerializeField] public AudioSource nextLevelSound;


    // Start is called before the first frame update
    void Start()
    {
        doorAnim = GetComponent<Animator>();
        wCanvas = GetComponentInChildren<RectTransform>().gameObject;
        wCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // && Input.GetKey(KeyCode.W))
        {
            doorAnim.SetBool("AtDoor", true);
            wCanvas.SetActive(true);
            //implement level complete screen
            //
            //
            if (Input.GetKey(KeyCode.W))
            {
                nextLevelSound.Play();
                string thisLevel = SceneManager.GetActiveScene().name;
                int nextLevelNum = int.Parse(thisLevel.Substring(6, 1)) + 1;
                string nextLevel = thisLevel.Substring(0, 6) + nextLevelNum;
                print(nextLevel);
                AddNextUnlockedLevel(nextLevel);
                SceneManager.LoadScene("LevelSelector");
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            doorAnim.SetBool("AtDoor", false);
            wCanvas.SetActive(false);
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
