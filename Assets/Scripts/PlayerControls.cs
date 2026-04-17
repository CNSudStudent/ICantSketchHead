using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    [Header("Rigidbody")]
    public Rigidbody2D rb;

    [Header("Default Down Speed")]
    public float downSpeed = 20f;

    [Header("Default Movement Speed")]
    public float movementSpeed = 10f;

    [Header("Default Directional Movement Speed")]
    public float movement = 0f;
    //Score of game
    [Header("Score Text")]
    public Text scoreText;
    private float topScore = 0.0f;
    //Ridgid2D object that is stored


    

    // Start is called before the first frame update
    void Start()
    {
        
        //variable equals to component Ridgisbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if players velocity is greater than 0
        //and position on the Y axis is greater 
        //than the score
        if (rb.velocity.y > 0 && transform.position.y > topScore)
        {
            //score equals players position
            topScore = transform.position.y;
        }
        //Text for the score equals to the top score
        scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
        // movment equals Horizontal movemnt
        //multiplied by the movement speed
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        //if direction on x axis is less than 0
        if (movement < 0)
        { //object faces to the left
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            //object faces to the right
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
        void FixedUpdate()
    {
        //Vector2 which is (x,y) velocity
        //equals to the velocity of the ridgidbody2D
        Vector2 velocity = rb.velocity;
        //Velocity of the x axis equals to
        //the direction movement on the y axis
        //of the character
        velocity.x = movement;
        //Ridgidbody2D velocity equals to
        //velocity of the object
        rb.velocity = velocity;
    }
    //Collision function
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocity = rb.velocity;
        if (velocity.y <= 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, downSpeed, 0);
        }
    }
}
