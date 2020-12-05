using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject hitEffect;
    private int scoreValue = 100;
    private GameController gameControllerScript;

    void Start()
    {
        GameObject GameControllerObject = GameObject.FindWithTag("GameController");

        if (GameControllerObject != null)
        {
            // I got the game controller object!!
            gameControllerScript = GameControllerObject.GetComponent<GameController>();
        }
        if (GameControllerObject == null)
        {
            UnityEngine.Debug.Log("IT didn't work");
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        GameObject effect =  Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, .8f);
        Destroy(gameObject);
        
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
            gameControllerScript.AddScore(scoreValue);
        }
    }
    

}
