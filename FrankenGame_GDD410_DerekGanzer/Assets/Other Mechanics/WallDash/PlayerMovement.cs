using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float speedMultiplier;
    public static event Action<BoxCollider2D> TurnOnWall;
    [SerializeField] WallDash dashForce;
    private bool canDash = true;
    private Vector3 mousePosition;
    private Vector2 direction;
    public float moveSpeed;
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        speedMultiplier = 1;
    }


    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * Mathf.RoundToInt(Input.GetAxis("Horizontal")));

        //Resets Position if Out of Play Area
        if (Vector2.Distance(this.transform.position, Vector2.zero) > 7)
        {
            this.transform.position = Vector2.zero;
        }

        //Movement
        if (Input.GetMouseButton(0))
        {

            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mousePosition - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);

        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        //Reset Speed Boost

        //Speed Boosts
        if (Input.GetKeyDown(KeyCode.Mouse1)) 
        {
            speedMultiplier = dashForce.DashForce;
            //Wall Dash
           
            if (hit.collider.gameObject.CompareTag("Wall") && canDash)
            {
                Debug.Log(hit.collider.gameObject.name);
                TurnOnWall.Invoke(hit.collider.gameObject.GetComponent<BoxCollider2D>());
                //StartCoroutine(TurnWallOn(hit.collider.GetComponent<BoxCollider2D>()));
            }
        }
       
        else if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            speedMultiplier = 1;
        }
            
        

    }

    //Turns Wall Back On
    IEnumerator TurnWallOn(BoxCollider2D col)
    {
        canDash = false;    
        col.enabled = false;
        
        yield return new WaitForSeconds(0.5f);
        col.enabled = true;
        
        canDash = true;
    }
}

