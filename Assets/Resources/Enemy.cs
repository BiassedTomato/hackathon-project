using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    Rigidbody2D RBody;
    Transform enemy;
    public GameObject Player;

    Player playerStats;

    // Use this for initialization
    void Awake()
    {
        enemy = GameObject.Find("whitecell").transform;
        RBody = GetComponent<Rigidbody2D>();
        playerStats = enemy.GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            playerStats.Score += 3;
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Play")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Player>().Health -= 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RBody.velocity = (enemy.position - transform.position).normalized * 2;
    }
}
