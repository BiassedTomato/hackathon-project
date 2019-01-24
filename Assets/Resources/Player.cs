using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

    public float Tempo = 0.2f;
    public GameObject Field;
    public Text HealthText;
    public Text ScoreText;

    int health;
    int score;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = Mathf.Clamp(value, 0, 100);
        }
    }

    private void Awake()
    {
        RBody = GetComponent<Rigidbody2D>();

        Health = 100;
        Score = 0;
    }

    private void OnEnable()
    {
        StartCoroutine("Shoot");
    }

    private void FixedUpdate()
    {
        HealthText.text = Health.ToString() ;
        ScoreText.text = Score.ToString();
    }

    Rigidbody2D RBody;
    public Transform Bullet;
    public float Speed = 3;

    Vector2 direction;
	// Update is called once per frame
	void Update ()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * Speed;
        RBody.velocity = direction;

        if(Health<=0)
            SceneManager.LoadScene("BadEnding");

        if (transform.position.x < -8 || transform.position.x >= 8 || transform.position.y < -3 || transform.position.y > 5)
            transform.position = Vector3.zero;

    }

    IEnumerator Shoot()
    {
        for(; ; )
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(Bullet, transform.position, Quaternion.identity, Field.transform);
                yield return new WaitForSeconds(Tempo);
            }
            yield return 0f;
        }
    }

}
