using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void playGame()
    {
        SceneManager.LoadScene(0);
    }
    public void quit()
    {
        Application.Quit();
        print("quit");
    }


}
