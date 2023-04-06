using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] private List<Button> levelButtons = new List<Button>();
    [SerializeField] private GameObject errorMessage;
    // Start is called before the first frame update
    void Start()
    {
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
