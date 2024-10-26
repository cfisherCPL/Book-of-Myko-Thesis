using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    
    public VectorValue spawnPosition;


// Some elements needed to handle character facing.    
    bool facingRight;
    float inputHorizontal;
    float inputVertical;

    private Rigidbody2D rb;

    private Vector2 movementDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = spawnPosition.initialValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;   
    }


    void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed;

        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if (inputHorizontal < 0 && !facingRight)
        {
            FlipCharacter();
        }

        if (inputHorizontal > 0 && facingRight)
        {
            FlipCharacter();
        }
        
    }

    void FlipCharacter()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;

    }

}
