using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer renderer = gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>();
        Vector3 size = renderer.bounds.size;
        gameObject.transform.localPosition = new Vector3(-size.x/2f,0,0);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
