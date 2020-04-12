using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldWeapon : MonoBehaviour
{
    // [SerializeField] GameObject player;
    // Start is called before the first frame update
    KeyCode pickup = KeyCode.E;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D gun)
    {
     
        if (gun.gameObject.tag == "player" /*&& Input.GetKeyDown(pickup)*/) //code commented out is for "pick up when key is pressed"
         {
          gameObject.transform.parent = gun.transform;
        }
    }
}

