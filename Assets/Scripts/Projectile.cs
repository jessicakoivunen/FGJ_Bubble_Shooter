using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float speed = 5.0f;
    public float dir;

    float limit = 13.0f;

    void Update()
    {
        //move towads other player
        transform.position += dir * speed * Time.deltaTime * transform.right;

        //destroy out of bounds
        if (transform.position.x < -limit || transform.position.x > limit)
        {
            Destroy(gameObject);
        }
    }
}
