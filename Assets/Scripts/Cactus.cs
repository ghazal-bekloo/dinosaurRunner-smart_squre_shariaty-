using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
     private Rigidbody2D rb;
     public float speed;

    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position += Vector3.left * speed * Time.deltaTime;
        rb.MovePosition(rb.position+ Vector2.left * speed * Time.fixedDeltaTime);

    }
}
