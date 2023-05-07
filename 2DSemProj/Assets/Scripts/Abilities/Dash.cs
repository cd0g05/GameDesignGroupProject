using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private PlayerMovement playerMoveScript;
    private Rigidbody2D playerRb;
    private Transform playerTrans;
    [SerializeField] private AudioSource dashSound;

    // Start is called before the first frame update
    void Start()
    {
        playerMoveScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        playerTrans = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Tab) && playerMoveScript.dashTimer <= 0)// && AbilityIsActive("Dash"))
        {
            Use();
        }
    }

    public void Use()
    {
        StartCoroutine(PlayerDash());
    }

    private IEnumerator PlayerDash()
    {
        float totalForce = 0;
        playerRb.constraints = RigidbodyConstraints2D.FreezePositionY;

        float firsthorizontalInput = Input.GetAxis("Horizontal");
        if (firsthorizontalInput > 0)
        {
            dashSound.Play();
            Physics2D.IgnoreLayerCollision(3, 7, true);
            while (totalForce < playerMoveScript.dashForce && firsthorizontalInput == Input.GetAxis("Horizontal"))
            {
                GameObject.Find("HealthController").GetComponent<HealthController>().canTakeDamage = false;
                playerRb.AddForce(Vector2.right * playerMoveScript.dashing, ForceMode2D.Impulse);
                yield return new WaitForSeconds(0.1f);
                totalForce += playerMoveScript.dashing;
            }
            Physics2D.IgnoreLayerCollision(3, 7, false);
            playerMoveScript.dashTimer = 5;
            yield return new WaitForSeconds(0.25f);
            GameObject.Find("HealthController").GetComponent<HealthController>().canTakeDamage = true;
        }
        else if (firsthorizontalInput < 0)
        {
            Physics2D.IgnoreLayerCollision(3, 7, true);
            while (totalForce < playerMoveScript.dashForce && firsthorizontalInput == Input.GetAxis("Horizontal"))
            {
                GameObject.Find("HealthController").GetComponent<HealthController>().canTakeDamage = false;
                playerRb.AddForce(Vector2.left * playerMoveScript.dashing, ForceMode2D.Impulse);
                yield return new WaitForSeconds(0.1f);
                totalForce += playerMoveScript.dashing;
            }
            Physics2D.IgnoreLayerCollision(3, 7, false);
            playerMoveScript.dashTimer = 5;
            yield return new WaitForSeconds(0.25f);
            GameObject.Find("HealthController").GetComponent<HealthController>().canTakeDamage = true;
        }
        playerRb.constraints = RigidbodyConstraints2D.None;
        playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerTrans.rotation = new Quaternion(0, 0, 0, 0);
    }
}
