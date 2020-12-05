using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public GameObject hitEffect;
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
            Debug.Log("IT didn't work");
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, .8f);
        Destroy(gameObject);

        if (other.gameObject.CompareTag("Player"))
        {
            gameControllerScript.GameOver();
        }
        
    }

}
