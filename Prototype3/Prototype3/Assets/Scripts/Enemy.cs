using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D enemybody;
    public Collider2D Body;
    // Start is called before the first frame update
    void Start()
    {
        enemybody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            enemybody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            enemybody.velocity = new Vector2(-moveSpeed, 0f);
        }
        
        }
    
    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(enemybody.velocity.x)), 1f);//this uses the box collider on the enemy so that each time it hits a block, it turns around
        if (collision.gameObject.CompareTag("Bullet"))//also explains itself...if the bullet hits the enemy, it just dies. no health or anything, real simple
        {
            Destroy(gameObject);
        }
    }
  
}
