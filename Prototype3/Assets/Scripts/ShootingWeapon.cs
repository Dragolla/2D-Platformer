using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingWeapon : MonoBehaviour
{//real simple shooting gun mechanism
    public Transform FirePoint;
    public Transform Destination; 
    public GameObject BulletPrefab;
   // public Player MoveScript;

    // Start is called before the first frame update

   // Update is called once per frame
    private void OnMouseDown()
    {
        //GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        this.transform.position = Destination.position;
        this.transform.parent = GameObject.Find("Destination").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {

        }
    }
    void Update()
    {
  if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }      
    }
    void Shoot()
    {
        RaycastHit2D hit;
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation); //this explains itself
    }
}
