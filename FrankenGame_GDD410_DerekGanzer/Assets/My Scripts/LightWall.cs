using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWall : MonoBehaviour
{
    public GameObject wall;
   
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
           
            Destroy(gameObject);
        }

    }
}
