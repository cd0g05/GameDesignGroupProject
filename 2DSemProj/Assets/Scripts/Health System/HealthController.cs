using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    public int playerHealth;
    public bool canTakeDamage;
    public bool dead { get; private set; }
    private GameObject player;

    //private bool iFramesActive = false;

    [SerializeField] private Image[] hearts;
    [SerializeField] private GameObject fatilityText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
        player = GameObject.Find("Player");
        dead = false;
        canTakeDamage = true;
        fatilityText.SetActive(false);
    }

    public void UpdateHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
                if (i < playerHealth)
                {
                    hearts[i].color = Color.red;
                }
                else
                {
                    hearts[i].color = Color.black;
                }
        }

        if (playerHealth <= 0 && !dead)
        {
            fatilityText.SetActive(true);
            dead = true;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Transform>().Rotate(new Vector3(0, 0, 90));
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayerDamage()
    {
        StartCoroutine(StartIFrame());
    }

    private IEnumerator StartIFrame()
    {
        canTakeDamage = false;
        Physics2D.IgnoreLayerCollision(3, 7, true);
        GameObject.Find("Player").GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(3);
        canTakeDamage = true;
        Physics2D.IgnoreLayerCollision(3, 7, false);
        GameObject.Find("Player").GetComponent<SpriteRenderer>().color = Color.white;
    }


    //public void UseShield(float shieldTimer)
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
