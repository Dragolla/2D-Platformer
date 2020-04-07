using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadReplayGame : MonoBehaviour
{
    public GameObject GetOtherFunction;//contain the script
    public Player script;//the script
    private void Start()
    {
        script = GetOtherFunction.GetComponent<Player>(); // access the script by assigning the script to a access-friendly variable
    }
    public void PlayAgain()
    {
        if (script.HasWon||!script.IsAlive)//basically only allow this to happen when the player has won, or has died
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }
        else{return;}//not really necessary, just in case we need it in the future
        
    }
}
