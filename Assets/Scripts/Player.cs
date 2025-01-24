using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public GameObject projectile;

    public float speed = 5.0f;
    private float moveLimit = 5.0f;

    public KeyCode up;
    public KeyCode down;
    public KeyCode shoot;

    public Vector3 dir;

    void Update()
    {
        MoveUpDown();
        Shoot();
    }

    private void MoveUpDown()
    {
        //Move
        if (Input.GetKey(down))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        else if (Input.GetKey(up))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        //Limits
        if (transform.position.y > moveLimit)
        {
            //transform.position = new Vector3(0, moveLimit, 0);
            transform.position = new Vector3(transform.position.x, moveLimit, 0);
        }
        if (transform.position.y < -moveLimit)
        {
            transform.position = new Vector3(transform.position.x, -moveLimit, 0);
        }
        
    }

    private void Shoot()
    {
        //Shoot projectile towards other player
        if (Input.GetKeyDown(shoot))
        {
            Instantiate(projectile, transform.position + dir * 0.5f, projectile.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy self and projectile
        Debug.Log("hit");
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}


//TODO:

// IMPORTANT
// Movement
// Shoot
// Collision check


//NICE
// Animation
// Sounds