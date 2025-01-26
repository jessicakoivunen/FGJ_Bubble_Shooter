using TMPro;
using UnityEngine;


public class Player : MonoBehaviour
{
    //Moving
    public float speed = 5.0f;
    private float moveLimit = 5.0f;
    public KeyCode up;
    public KeyCode down;
    public KeyCode shoot;

    //Shooting
    public GameObject projectile;
    public Vector3 dir;

    //Wobble
    private float t = 0.0f;
    private float scale1 = 1f;
    private float scale2 = 0.85f;

    //Score + death/win
    public TMP_Text scoreText;
    int score = 0;
    public GameObject WinPanel;
    public GameObject PauseButton;
    public TMP_Text WinText;

    void Update()
    {
        MoveUpDown();
        Shoot();
        Wobble();
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
            Instantiate(projectile, transform.position + dir * 1f, projectile.transform.rotation);
        }
    }

    void Wobble()
    {
        //Animation (lerp)
        t += Time.deltaTime / 2.0f;
        if (t > 1.0f)
        {
            float temp = scale1;
            scale1 = scale2;
            scale2 = temp;
            t = 0.0f;
        }
        transform.localScale = new Vector3(Mathf.Lerp(scale1, scale2, t), Mathf.Lerp(scale1, scale2, t), Mathf.Lerp(scale1, scale2, t));
    }

    private void OnTriggerEnter(Collider other)
    {
        score++;
        scoreText.text = score.ToString();
        Destroy(other.gameObject);

        if (score >= 10)
        {
            //Destroy self and projectile
            Death();
            Destroy(other.gameObject);
        }
    }

    void Death()
    {
        Destroy(gameObject);
        //new WaitForSeconds(3f);     //might not work
        WinPanel.SetActive(true);
        PauseButton.SetActive(false);
        if (dir == new Vector3(1, 0, 0))
        {
            WinText.text = "Player 2 won!";
        }
        else WinText.text = "Player 1 won!";
    }

}


//TODO:

// IMPORTANT
// ui

//NICE
// Animation
// Sounds
// Font

//player set controls
//name-tags for players