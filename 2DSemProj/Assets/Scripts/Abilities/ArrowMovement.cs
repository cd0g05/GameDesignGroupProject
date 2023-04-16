using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force = 10f;
    public GameObject obj;
    // public GameObject player;
    // public Rigidbody2D rb2;

    // Start is called before the first frame update
    void Start()
    {
        // rb2 = player.GetComponent<Rigidbody2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(-force * Mathf.Sign(GameObject.Find("Player").transform.localScale.x), 0, 0);
        StartCoroutine(destroying());
    }

    // Update is called once per frame
    void Update()
    {
        // force = force - 0.1f;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // if (col.gameObject.CompareTag("Ground"))
        // {
            rb.velocity = Vector2.zero;
            Debug.Log("ground");
            
        // }
    }

    public IEnumerator destroying()
    {
        yield return new WaitForSeconds(6);
        Destroy(obj);

    }
}
