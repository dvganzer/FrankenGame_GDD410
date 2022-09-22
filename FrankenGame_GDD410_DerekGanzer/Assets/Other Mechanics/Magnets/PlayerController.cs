using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    private float _moveSpeed = 1f;
    [SerializeField] private float rotationSpeed;

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
        HandlePlayerMovement();
        if (Input.GetKey(KeyCode.LeftShift)) Attract.Invoke(transform); //invoke attract event if pressing space
    }

    private void HandlePlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput, verticalInput, 0f);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        //movementDirection.Normalize();

        transform.Translate(movementDirection * _moveSpeed * inputMagnitude * Time.deltaTime, Space.World);
        if (horizontalInput == 0 && verticalInput == 0) return;


        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        Vector3 moveDir = new Vector3(horizontalInput, verticalInput, 0f);
    

    }
}