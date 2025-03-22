using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHider : MonoBehaviour
{
    public float hideAfterSeconds = 5f;
    private Coroutine _hideCursorCoroutine;
    [SerializeField] GameObject player;
    private Rigidbody2D playerRB;

    void Awake()
    {
        //still need to get the player movement to not interfere with making the cursor visible again
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Initially hide the cursor
        Cursor.visible = false;
    }

    void Update()
    {

        

        // Check for mouse movement
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            // Stop the coroutine if it's running
            if (_hideCursorCoroutine != null)
            {
                StopCoroutine(_hideCursorCoroutine);
                _hideCursorCoroutine = null;
            }
            // Show the cursor
            Cursor.visible = true;
        }
        else
        {
            // Start the coroutine to hide the cursor
            if (_hideCursorCoroutine == null)
               
            {
                _hideCursorCoroutine = StartCoroutine(HideCursor());
            }
            
            //hide the cursor if player moving and mouse isnt
            if (playerRB.velocity.magnitude > 0)
            {
                Cursor.visible = false;
            }

        }


        
    }


    IEnumerator HideCursor()
    {
        yield return new WaitForSeconds(hideAfterSeconds);
        Cursor.visible = false;
    }
}
