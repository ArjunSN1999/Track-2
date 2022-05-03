using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;

    public GameObject gamewon;

    public GameObject gamelost;

    public GameObject pausescreen;
    public float speed;

    private bool isgamewon;

    private bool isgamelost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isgamewon==true){
            return;
        }
        if (isgamelost==true){
            return;
        }
        if (Input.GetAxis("Horizontal") > 0) //it is Positive
        {
        rigidbody2d.velocity = new Vector2(speed, 0f);
        }
        else if (Input.GetAxis("Horizontal") < 0) //it is negative
        {
        rigidbody2d.velocity = new Vector2(-speed, 0f);
        }
        else if (Input.GetAxis("Vertical") > 0) //it is Positive
        {
        rigidbody2d.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetAxis("Vertical") < 0) //it is Nagative
        {
        rigidbody2d.velocity = new Vector2(0f, -speed);
        }
        //else if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        //{
        //rigidbody2d.velocity = new Vector2(0f, 0f);
        //}
        else if (Input.GetButtonDown("Jump"))
        {
        rigidbody2d.velocity = new Vector2(0f, 0f);
        }
        else if (Input.GetButtonDown("Cancel"))
        {
        pausescreen.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag=="WinCondition"){
                Debug.Log("Win condition");
                gamewon.SetActive(true);
                isgamewon=true;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
      if (other.gameObject.tag=="EnemyRed"){
        Debug.Log("Enemy Condition");
        gamelost.SetActive(true);
        isgamelost=true;
        }  
    }
}