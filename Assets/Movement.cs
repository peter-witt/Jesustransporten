using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 8;

    public float hitDist = 1f;
    public int damage = 1;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.A)) {
            velocity.x = -speed;
        } else if (Input.GetKey(KeyCode.D)) {
            velocity.x = speed;
        }
        if (Input.GetKey(KeyCode.W)) {
            velocity.y = speed;
        } else if  (Input.GetKey(KeyCode.S)) {
            velocity.y = -speed;
        }
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
        body.velocity = velocity;


        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
        Vector3 mouseDir = gameObject.transform.position - mouseWorldPosition;
        Vector2 mouseDir2 = new Vector2(mouseDir.x, mouseDir.y);
        float angle = (float)Math.Atan2(mouseDir2.y, mouseDir2.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


         if (Input.GetMouseButtonDown(0)) {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemey in enemies) {
                Enemy e = enemey.GetComponent<Enemy>();
                if (e == null) continue;
                float dist = (e.transform.position - gameObject.transform.position).magnitude;
                Debug.Log("dist " + dist);
                if (dist <= hitDist) {
                    e.health -= damage;
                    if(e.health <= 0) {
                        GetComponent<AudioSource>().Play();
                    }
                    Debug.Log("HIT " + e.health);
                    animator.SetTrigger("Hitting");
                }
            } 
        }
    }
}
