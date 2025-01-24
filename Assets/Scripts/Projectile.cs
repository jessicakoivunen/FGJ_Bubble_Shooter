using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5.0f;
    public float dir;

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime * transform.right;
    }
}
