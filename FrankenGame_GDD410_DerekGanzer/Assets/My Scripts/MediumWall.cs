using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumWall : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }

    public Color[] states;

    public int health { get; private set; }

    public bool unbreakable;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Start()
    {
        if(unbreakable)
        {
            health = states.Length;
            spriteRenderer.color = states[health - 1];
        }
    }

    private void Hit()
    {
        if (unbreakable)
        {
           return;
        }
        health--;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            spriteRenderer.color = states[health - 1];
           
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ProjectileController _projectilePrefab = collision.gameObject.GetComponent<ProjectileController>();
        if(collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Hit");
            Hit(); 
        }
    }
}
