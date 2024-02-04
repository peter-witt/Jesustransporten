using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grab : MonoBehaviour
{
    private GameObject gabbed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gabbed != null)
        {
            gabbed.GetComponent<Rigidbody2D>().AddForce((transform.position - gabbed.transform.position).normalized * 50000f * Time.deltaTime);
        }

        Vector3 p = gameObject.transform.position;
        Camera.main.transform.position = new Vector3(p.x, p.y, -10);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jesus")
        {
            collision.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
            gabbed = collision.gameObject;
        }
    }
}
