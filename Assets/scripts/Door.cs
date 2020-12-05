using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private playerCont player;
    private GameController gameControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<playerCont>();
        gameControllerScript = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(player.followingKey != null)
            {
                player.followingKey.followTarget = transform;
                gameControllerScript.WinGame();
            }
        }
    }
}
