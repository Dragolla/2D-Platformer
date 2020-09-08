using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldWeapon : MonoBehaviour
{
    // [SerializeField] GameObject player;
    // Start is called before the first frame update
    KeyCode pickup = KeyCode.E;
    bool IsTouch = false;
    public Rigidbody2D GunBody;
    public BoxCollider2D GunCollider;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsTouch == true)
        {
            GunBody.isKinematic = false;
            GunBody.gravityScale = 0.0f;
            GunCollider.enabled = false; //Gun collider is still on even though bool says false? or am i retarded
            float PlayerLeftOrRight = 0;

            Vector3 TheScale;

            if (gameObject.transform.parent.localScale.x > 0)
            {
                PlayerLeftOrRight = 1f;
                
                TheScale = gameObject.transform.localScale;
                TheScale.x = gameObject.transform.parent.localScale.x;

                
                
                

            }
            if (gameObject.transform.parent.localScale.x < 0)
            {
                PlayerLeftOrRight = -1f;

                TheScale = gameObject.transform.localScale;
                TheScale.x = gameObject.transform.parent.localScale.x;

            }
            gameObject.transform.position = new Vector2(gameObject.transform.parent.position.x + PlayerLeftOrRight, gameObject.transform.position.y);
        }


        

    }
    void OnTriggerEnter2D(Collider2D gun)
    {

        if (gun.gameObject.tag == "player" /*&& Input.GetKeyDown(pickup)*/) //code commented out is for "pick up when key is pressed"
        {
            gameObject.transform.parent = gun.transform;
            IsTouch = true;

        }
    }
}