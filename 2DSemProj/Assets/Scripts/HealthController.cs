using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int playerHealth;

    //private bool iFramesActive = false;

    [SerializeField] private Image[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            //if (iFramesActive == false)
            //{
                if (i < playerHealth)
                {
                    hearts[i].color = Color.red;
                }
                else
                {
                    hearts[i].color = Color.black;
                }
                //iFramesActive = true;
                //StartCoroutine(IFramesCountdown());
            //}
        }
    }

    /*IEnumerator IFramesCountdown()
    {
        yield return new WaitForSeconds(1);
        iFramesActive = false;
    }*/



    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            playerHealth -= 1;
            UpdateHealth();
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
