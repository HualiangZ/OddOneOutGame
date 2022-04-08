using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GamePlay : MonoBehaviour
{   
    public Text changingText;
   // public AddPlayer player; 
    static public int x = 0;
    static public List<string> players = new List<string>();

    //use the list to output the players name in to the textfield called 'PlayerNametxt' in 'HideAnimalScene'

    //IEnumerator Start()
    //{
    //    player = GetComponent<AddPlayer>();
    //    yield return new WaitForEndOfFrame();

    //}

    void Awake()    
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (players.Count != 0 && sceneName == "HideAnimalScene" )
            changingText.text = players[x];
 
    }

    public void ChangeScene()
    {
        if(EventSystem.current.currentSelectedGameObject.name == "ShowAnimal")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Continue" && x < players.Count-1)
        {
            x = x + 1;
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
            
    }

    //comment
    //comment
    public void ReadStringInput(string s)
    {
        players.Add(s);

        //used for testing
        //------------------------------
        foreach (string p in players)
        {
            Debug.Log(p);
        }
        int x = players.Count;


        Debug.Log(x);
        //------------------------------
    }

}
