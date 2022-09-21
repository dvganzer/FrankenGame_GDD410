using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public SpriteRenderer Moon;
    public GameObject Earth;
    private int nextSceneToLoad;

    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Moon.color == Color.green && collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneToLoad);
        }
       
    }
}
