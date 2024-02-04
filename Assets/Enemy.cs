using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using System;
using UnityEditor;

public class Enemy : MonoBehaviour
{
    private GameObject target;
    private Vector2 randomDirection;
    private float timer = 0;
    public float speed = 10f;
    public float roamSpeed = 1f;
    public int health = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var rb = GetComponent<Rigidbody2D>();

        if (target != null)
        {
            rb.velocity = (target.transform.position - transform.position).normalized * speed * Time.deltaTime;
            float angle = (float)Math.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else
        {
            Debug.Log(timer);
            if (timer <= 0)
            {
                timer = 2f;
                transform.Rotate(new Vector3(0, 0, UnityEngine.Random.Range(-360f, 360f)));
            }
            Debug.Log(rb.velocity);
            rb.velocity = transform.up * roamSpeed * Time.deltaTime;
            timer -= Time.deltaTime;
        }

       if (health <= 0) {
            GameObject.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Trigger player");
            target = collision.gameObject;
            transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // GameObject.Destroy(target);
            // target = null;
        }
    }
}