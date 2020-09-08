using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage = 30;
   [SerializeField] public Rigidbody2D rb;
    // Start is called before the first frame update
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);//bullet movement
    }
   /* void OnTriggerEnter2D(Collider2D hit)
    {
        FollowEnemy enemy = hit.GetComponent<FollowEnemy>();//access the Following enemy's script
        if(enemy != null) // if the bullet is not NULL/if the bullet hit something 
        {
            enemy.TakeDamage(damage); // then take health from the enemy
        }
        Destroy(gameObject);//then destroy the bullet
        }*/
    // Update is called once per frame
  
}
