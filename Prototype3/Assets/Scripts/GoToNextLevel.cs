using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    private Player player;
    public GameObject holdscript;
    public GameObject Button;
     void Start()
    { 
        player = holdscript.GetComponent<Player>();
    }
    void Update()
    {
        if (!player.HasWon)
        {
            Button.SetActive(false);
        }
        else
        {
            Button.SetActive(true);
        }
    }
    public void NextLevel()
    {
        if (player.HasWon)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else { return; }
    }

}
//sdfsdfsdfdsf
