using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayer1Goal;
    private Rigidbody2D _rigidbody2D;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (!isPlayer1Goal)
            {
                Debug.LogWarning("Player 2 Scored . . .");
                GameObject.Find("GameManager").GetComponent<GameController>().Player2Scored();
            }
            else
            {
                Debug.LogWarning("Player 1 Scored . . .");
                GameObject.Find("GameManager").GetComponent<GameController>().Player1Scored();
            }
        }
    }
}