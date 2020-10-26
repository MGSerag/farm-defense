using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public float moveSpeed = 2f;
    public Rigidbody2D rb;
    public Rigidbody2D rb_gun;

    // public Camera cam;
    Vector2 movement;
    Vector2 mousePos;

    [Header("Player Shooting")]
    public Transform firePoint;
    public GameObject bulletTrail;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
		{
            Shoot();
		}

        movement.x = Input.GetAxisRaw("Horizontal");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }

	private void FixedUpdate()
	{
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        rb_gun.MovePosition(rb_gun.position + movement * moveSpeed * Time.deltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, -30f, 30f);
        rb_gun.rotation = angle;
	}

	private void Shoot()
	{
        GameObject bullet = PoolManager.Instance.Requestbullet(this);
        //bullet.transform.localPosition = firePoint.position;
        //bullet.transform.localRotation = firePoint.rotation;
        //Instantiate(bulletTrail, firePoint.position, firePoint.rotation);

        //      RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        //      if (hitInfo)
        //{
        //          Debug.Log(hitInfo.transform.name);
        //}
    }
}
