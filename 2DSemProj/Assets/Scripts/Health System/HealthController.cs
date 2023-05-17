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
    [SerializeField] public AudioSource deathSound;
    [SerializeField] public AudioSource damageSound;
    [SerializeField] public AudioSource restartSound;


    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
        player = GameObject.Find("Knight");
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
            deathSound.Play();
            fatilityText.SetActive(true);
            dead = true;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Transform>().Rotate(new Vector3(0, 0, 90));
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        restartSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayerDamage()
    {
        damageSound.Play();
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
