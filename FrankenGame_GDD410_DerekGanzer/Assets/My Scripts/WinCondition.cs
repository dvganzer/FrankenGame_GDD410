using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public SpriteRenderer Moon;
    public Transform Earth;
    private int nextSceneToLoad;

    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Moon.color == Color.green)
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Moon.color == Color.green && collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneToLoad);
        }
       
    }
}
