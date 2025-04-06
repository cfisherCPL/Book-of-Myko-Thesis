using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private GameObject journalPanel;
    [SerializeField] private GameObject titleOverlay;
    [SerializeField] private GameObject saveConfirmPanel;
    [SerializeField] private GameObject storagePanel;
    [SerializeField] private GameObject requestPanel;
    [SerializeField] private GameObject dataSavedPanel;
    [SerializeField] private GameObject welcomeLetterPanel;
    [SerializeField] private UI_Manager UI_Manager;

    public DialogueUI DialogueUI => dialogueUI;

    public VectorValue spawnPosition;


    Animator anim;
    private Vector2 lastMoveDirection;

    private PlayerTeleport playerTeleport;
    private GoToSleep goToSleep;


// Some elements needed to handle character facing.    
    bool facingRight;
    float inputHorizontal;
    float inputVertical;

    private Rigidbody2D rb;

    private Vector2 movementDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTeleport = GetComponent<PlayerTeleport>();
        goToSleep = FindObjectOfType<GoToSleep>();
        transform.position = spawnPosition.initialValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTeleport.preventInput || goToSleep.preventInput)
        {
            return;
        }
        else
        {
            ProccessInputs();
            Animate();


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

    }


    void FixedUpdate()
    {
        if (UI_Manager.draggingItem)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }

        if (titleOverlay.activeSelf | welcomeLetterPanel.activeSelf)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }

        if (dialogueUI.IsOpen)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }

        if (journalPanel.activeSelf)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }

        if (saveConfirmPanel.activeSelf | dataSavedPanel.activeSelf)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }

        if (requestPanel.activeSelf)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }

        if (storagePanel.activeSelf)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }

        rb.velocity = movementDirection.normalized * movementSpeed;

       
        
    }

    void FlipCharacter()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;

    }

    void ProccessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if ( (moveX == 0 && moveY == 0) && (inputHorizontal !=0 || inputVertical != 0))
        {
            lastMoveDirection = movementDirection;
        }

        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }


    void Animate()
    {
        anim.SetFloat("MoveX", inputHorizontal);
        anim.SetFloat("MoveY", inputVertical);
        anim.SetFloat("MoveMagnitude", movementDirection.magnitude);
        anim.SetFloat("LastMoveX", lastMoveDirection.x);
        anim.SetFloat("LastMoveY", lastMoveDirection.y);
    }

}
