using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health = 5f;
    public float speed = 2f;

    private float _health;

    public Rigidbody2D rb;

	private void OnEnable()
	{
        _health = health;
        this.transform.position = SpawnManager.Instance.transform.position;
	}

	// Update is called once per frame
	void FixedUpdate()
    {
        rb.MovePosition(transform.position + Vector3.left * speed * Time.deltaTime);
        // this.transform.position = Vector2.left * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _health -= 1;

            if (_health < 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
