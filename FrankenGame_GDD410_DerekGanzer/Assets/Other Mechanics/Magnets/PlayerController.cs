using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    
 

    public static event Action Throw;
    public static event Action<Transform> Attract;

    private Rigidbody2D _rb;

    private void Start() => _rb = GetComponent<Rigidbody2D>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Throw.Invoke(); //invoke throw event if LMB is pressed
    }

    private void FixedUpdate()
    {
      
        if (Input.GetKey(KeyCode.LeftShift)) Attract.Invoke(transform); //invoke attract event if pressing space
    }

   
}