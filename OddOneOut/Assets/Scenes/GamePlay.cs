using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GamePlay : MonoBehaviour
{   
    public Text changingText;
    public Text impos;

    static public int x = 0;
    static public List<string> players = new List<string>();
    static public List<string> animals = new List<string>() { "Mouse", "Cat", "Dog", "Lion"};
    static public bool con = false;
    static public int imposter;
    static public int animal;
    //use the list to output the players name in to the textfield called 'PlayerNametxt' in 'HideAnimalScene'


    //public InputField mainInputField;

    void Awake()    
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        while(con == false)
        {
            imposter = Random.Range(0, players.Count);
            animal = Random.Range(0, animals.Count);
            con = true;
        }
            

        if (players.Count != 0 && sceneName == "HideAnimalScene" )
            changingText.text = players[x]; 
        
        if(sceneName == "ShowAimalScene")
        {
            
            
            if(imposter == x)
            {
                impos.text = "You are the imposter.";
            }
            else
            {
                impos.text = "The Animal Is " + animals[animal];
            }

        }

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
        //mainInputField.DeactivateInputField();
        players.Add(s); //new comment

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
