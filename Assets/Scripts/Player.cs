using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    [SerializeField] float jumpSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] Vector2 deathfling = new Vector2(25f, 25f);
    [SerializeField] Vector3 FlipBackToFeet = new Vector3(0f, 0f, 0f);
    [SerializeField] Text YouWon;
    [SerializeField] Text Replay;
    [SerializeField] Text PlayerHasDied;
    [SerializeField] GameObject player;//the player itself 
    bool FeetAreTouchingGround = true;
    float doubleJump = 2;
    public bool IsAlive = true;
    public bool HasWon = false;
    Rigidbody2D myrigidbody;
    CapsuleCollider2D bodycollider;
   
    BoxCollider2D myFeet;
    public GameObject cameraObject;
    ReloadReplayGame reloadReplayGameScript;
    private bool FacingRight;

    // Start is called before the first frame update
    void Start()
    {
        FacingRight = true;
        reloadReplayGameScript = cameraObject.GetComponent<ReloadReplayGame>();
        myrigidbody = GetComponent<Rigidbody2D>();
        bodycollider = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        

        YouWon.text = "";
        Replay.text = "";
        PlayerHasDied.text = "";
    }

    // Update is called once per frame
    void Update()
    {   //if the player is not alive
        if (!IsAlive) { return; }//then simply return nothing and the game terminates
        float controlThrow = Input.GetAxis("Horizontal");// value for this is -1 to 1 lol obviously
        Run(controlThrow);
        Jump();
        FlipSprite(controlThrow);
        Death();
        GoalReached();
        SuccessPlayAgain();
        Restart();
    } 
    private void Run(float controlThrow)
    {
        //basic movement, no need to explain
        
        myrigidbody.velocity =  new Vector2(controlThrow * runSpeed, myrigidbody.velocity.y);
    }
    private void FlipSprite(float controlThrow)
    {//this makes the player face the direction for which the inputs direct(left, then face left; right, then face right)
     //if the player switches between left and right, flip the player so that is facing either left or right
     //if moving towards left and not facing left or moving right and facing left, then
        if (controlThrow > 0 && !FacingRight || controlThrow < 0 && FacingRight) { //this also allows the gun to flip according to the player, so it doesn't just stay on one side of the player
        FacingRight = !FacingRight; //make facing left false
            Vector3 theScale;
            theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

    }
         
         
     }
    private void Death()
    {// if the player touches the red block, then kill the player by setting the current state (isalive) to false
        //and also add a dramatic death, by flinging the player away when they touch the red
        // I made it so that until we fix the really strange collider system, at least the deathzones are guaranteed to kill the player, as the collision doesnt need to choose between the players colliders
        if (myFeet.IsTouchingLayers(LayerMask.GetMask("Trap"))&&!HasWon || bodycollider.IsTouchingLayers(LayerMask.GetMask("Trap")) && !HasWon)//added !HasWon so that it only says "you have died" only if the player has not died yet
        {
            IsAlive = false;
            GetComponent<Rigidbody2D>().velocity = deathfling;
            Replay.text = "Replay";
            PlayerHasDied.text = "You have died";
            

        }
        if (bodycollider.IsTouchingLayers(LayerMask.GetMask("enemy"))&&!HasWon)
            {
                IsAlive = false;
                GetComponent<Rigidbody2D>().velocity = deathfling;
                Replay.text = "Replay";
                PlayerHasDied.text = "You have died";
            }
                // so I was gonna make an Ienumerator that restarted the level after a bit but then I saw the restart button lol

            }
    private void Jump()
    {    //only allow the player to jump once. if the player is NOT touching the ground, then dont let him jump 
        //otherwise, if the player DOES have their feet on the ground, then proceed to the next line of code and let the player jump
        // ok so I added a double jump which was pretty ez to do, but a problem I noticed is the jump force gets added between 2 jumps which is kinda weird, so that could be fixed
        //I made some severely needed adjustments to the double jump mechanic, which now resets your vector when you jump so excess momentum and stuff is not possible to be carried through the double jump. I also made a check so that we can adjust the double jumps height in relation to a single jump. This adjusment will also allow us to animate wings, or a push of air for the double jump becuase the two are hopefully differentiated

        if (myFeet.IsTouchingLayers(LayerMask.GetMask("ground")))
        {
            doubleJump = 2;
        }
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("ground")) && doubleJump == 1)
        {
            return;
        }
        if (Input.GetButtonDown("Vertical"))
        {
            myrigidbody.velocity = new Vector2(0f, 0f);

            if (doubleJump == 2)
            {
                Vector2 jumpVelocityToAdd = new Vector2(player.transform.rotation.y, jumpSpeed);
                myrigidbody.velocity += jumpVelocityToAdd;
            }
            if (doubleJump == 1)
            {
                Vector2 jumpVelocityToAdd = new Vector2(player.transform.rotation.y, jumpSpeed + 5);
                myrigidbody.velocity += jumpVelocityToAdd;
            }  
            
            
            doubleJump -= 1;
        }


    

    }

    public void GoalReached() //when the player has touched the circle, then the player has won the game and can continue to next level
                               //however other levels will be worked on once animations are finished.
    {
        if (bodycollider.IsTouchingLayers(LayerMask.GetMask("Goal")))
        {

            YouWon.text = "Success!";
            HasWon = true;

        }
    }
    private void SuccessPlayAgain()//player has won the game and has the option to restart the level
    {
        if (HasWon)
        {
            Replay.text = "Replay";

        }


    }
    private void Restart()//press R to restart the whole game from the start
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!HasWon && IsAlive)
                reloadReplayGameScript.PlayAgain();
        }
    }
    //would be good if we add in possible attacking 
    //and create another scene and scripts for other things you want to do.
    //thanks!

 

}
