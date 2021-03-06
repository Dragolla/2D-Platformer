﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;
    public float StoppingDistance;
    private Player player;
    public GameObject holdscript;
    public GameObject Enemy; //this is the enemy itself
    public float health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        player = holdscript.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (player.HasWon || !player.IsAlive) { return; }//if the player has won or has died, stop and do nothing
            chase();
     
        if(health == 0)//die
        {
            Die();
        }

    }

void chase() // as long as the target is far enough from the enemy, follow the player
    {
        if (Vector2.Distance(transform.position, target.position) > StoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
        }
    }

void Die()
    {
        Destroy(Enemy);
    }
public void TakeDamage(int damage) //this script is accessed by the bullet function, each time it is called, include a damage variable, and it will take that much from the health
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
}



