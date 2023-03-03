using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemyScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D homingRb;
    private Transform homingTrans;
    private BoxCollider2D homingBc;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        homingRb = GetComponent<Rigidbody2D>();
        homingBc = GetComponent<BoxCollider2D>();
        homingTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        homingRb.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;
    }
}
