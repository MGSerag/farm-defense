using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float velocity = 20f;
    public Rigidbody2D rb;

	ParticleSystem ps;
	private void Awake()
	{
		ps = this.GetComponent<ParticleSystem>();
	}
	void OnEnable()
	{
		//ps.enableEmission = true;
		rb.velocity = transform.right * velocity;	
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		rb.velocity = Vector2.zero;
		//ps.enableEmission = false;
	}

}
