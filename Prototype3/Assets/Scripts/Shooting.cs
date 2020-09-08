using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

public class Shooting : MonoBehaviour {
    public int damage = 30;
    public Transform FirePoint;
    public GameObject BulletPrefab;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit2D HitInfo = Physics2D.Raycast( FirePoint.position, FirePoint.right);
        //Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        if (HitInfo)
        {
            FollowEnemy enemy = HitInfo.transform.GetComponent<FollowEnemy>();//access the Following enemy's script
            if (enemy != null) // if the bullet is not NULL/if the bullet hit something 
            {
                enemy.TakeDamage(damage); // then take health from the enemy
            }
        }
    }
}
