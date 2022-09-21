using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonColor : MonoBehaviour
{
    public SpriteRenderer Moon;
    public float timer = 3f;
    public float timeLeft = 3.0f;
    public Text startText; // used for showing countdown from 3, 2, 1 
    public GameObject Planet;


    void Update()
    {
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            timeLeft -= Time.deltaTime;
            startText.text = (timeLeft).ToString("0");
            if (timeLeft < 0)
            {
                Moon.color = Color.green;
            }
        }
    }
}
