using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    //private PlayerMovement playerMoveScript;
    private Rigidbody2D playerRb;
    private Transform playerTrans;
<<<<<<< Updated upstream
    [SerializeField] private AudioSource dashSound;
=======
    [SerializeField] private float dashCooldown;
    public bool isDashing { get; private set; }
    private bool canDash;
    [SerializeField] private float dashPower;
    [SerializeField] private float dashingTime;
    private TrailRenderer dashTrail;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        //playerMoveScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        playerTrans = GameObject.Find("Player").GetComponent<Transform>();
        dashTrail = GameObject.Find("Player").GetComponent<TrailRenderer>();
        dashCooldown = 5;
        dashTrail.emitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dashCooldown > 0)
        {
            dashCooldown -= Time.deltaTime;
        }
        else
        {
            canDash = true;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Tab) && canDash && dashCooldown <= 0)// && playerMoveScript.dashTimer <= 0)
        {
            Use();
        }
    }

    public void Use()
    {
        //StartCoroutine(PlayerDash());
        StartCoroutine(UseDash());
    }

    private IEnumerator UseDash()
    {
        canDash = false;
        isDashing = true;
        float origGrav = playerRb.gravityScale;
        Physics2D.IgnoreLayerCollision(3, 7, true);
        playerRb.gravityScale = 0f;
        playerRb.velocity = new Vector2(playerTrans.localScale.x * dashPower, 0);
        dashTrail.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        Physics2D.IgnoreLayerCollision(3, 7, false);
        playerRb.gravityScale = origGrav;
        isDashing = false;
        dashTrail.emitting = false;
        dashCooldown = 5;
    }

    /*private IEnumerator PlayerDash()
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
    }*/
}
