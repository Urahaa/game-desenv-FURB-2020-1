using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carie : MonoBehaviour
{
    public float movimento = 8;
    public Rigidbody2D rigidbody2d;



    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        andar();

    }

    void andar()
    {

        rigidbody2d.velocity = new Vector2(movimento, rigidbody2d.velocity.y);

        if (movimento < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (movimento > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }



    }

}
