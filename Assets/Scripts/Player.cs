using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    public float Movespeed;
    public float rotateAmount;
    public Text scoreCount;
    public Text highScoreCount;
    float rot;
    private int score;

    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        highScoreCount.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.x < 0)
            {
                rot = rotateAmount;
            }
            else
            {
                rot = -rotateAmount;
            }
            transform.Rotate(0, 0, rot);
        }

        scoreCount.text = score.ToString();

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreCount.text = score.ToString();
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * Movespeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.freezeRotation = true;

        if (collision.gameObject.tag == "Food")
        {
            GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
            score += 1;
        }
        else if (collision.gameObject.tag == "Danger")
        {

            SceneManager.LoadScene("GameOver");
        }
    }
    private void OnBecameInvisible()
    {
        SceneManager.LoadScene("GameOver");
    }
}
