using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    Vector2 savedDir;

    private void Awake()
    {

        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        direction = new Vector3(direction.x, direction.y, 0).normalized * Speed;

        RBody = GetComponent<Rigidbody2D>();
        RBody.velocity = direction;

        Destroy(gameObject, 10);

    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }


    public float Speed = 20;
    Rigidbody2D RBody;

}
