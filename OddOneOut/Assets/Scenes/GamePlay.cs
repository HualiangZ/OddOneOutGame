using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class players
{
    string name;
    int vote;

    public string getName()
    {
        return name;
    }

    public void setName(string value)
    {
        name = value;
    }


    public int getVote()
    {
        return vote;
    }

    public players(string name)
    {
        this.name = name;
        this.vote = 0;
    }

    public void addVote()
    {
        vote += 1; 
    }
} 





public class GamePlay : MonoBehaviour
{   
    public Text changingText;
    public Text impos;//imposter text
    public Text v; //the most vote player text
    public Text voting;//who is voting text
    public Text DisplayListText;
    public Sprite dog;
    public Sprite goat;
    public Sprite rhino;
    public Sprite elephant;
    public Sprite giraffe;
    public Sprite donkey;
    public Sprite cheetah;
    public Sprite imposter_image;
    public Image animal_Image;

    static public int x = 0;//to keep track of players in showing animal 
    static public int y = 0;//keep track players on who is voting
    static public List<players> p = new List<players>(); 
    static public List<string> animals = new List<string>() {"goat", "dog", "rhino", "elephant", "giraffe", "donkey", "cheetah"};
    static public List<Sprite> animalImages = new List<Sprite>();
    static public bool con = false;
    static public int imposter;// rng imposter on number gen
    static public int animal;//rng animal on number gen
    //use the list to output the players name in to the textfield called 'PlayerNametxt' in 'HideAnimalScene'


    //public InputField mainInputField;

    void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        //making sure this is the right player to show if they ar animal or imposter
        if (p.Count != 0 && sceneName == "HideAnimalScene")
        {
            //string player = 
            changingText.text = "Is This " + p[x].getName();
            animalImages.Add(goat);
            animalImages.Add(dog);
            animalImages.Add(rhino);
            animalImages.Add(elephant);
            animalImages.Add(giraffe);
            animalImages.Add(donkey);
            animalImages.Add(cheetah);
        }

        //show the player if they are animal or imposter
        if (sceneName == "ShowAimalScene")
        {
            
                
            if (imposter == x)
            {
                impos.text = "You are the imposter.";
                animal_Image.sprite = imposter_image;
            }
            else
            {
                impos.text = "The Animal Is " + animals[animal];
                animal_Image.sprite = animalImages[animal];
            }

        }

        //chech who got the most vote and display it and display the real imposter
        if (sceneName == "MostPlayerVoteScene")
        {
            int x = 0;
            int player = 0;
            for (int i = 0; i < p.Count; i++)
            {
                if(x < p[i].getVote())
                {
                    player = i;
                    x = p[i].getVote();
                }

            }

            v.text = "Most voted Player " + p[player].getName();
            impos.text = "The Real Imposter Is " + p[imposter].getName();
        }


        //tell who is voting
        if (sceneName == "VoteScene")
        {
            voting.text = p[y].getName();

            ////////////27/04/2022////////////
            for (int i = 0; i <= p.Count - 1; i++)
            {
               string b = (p[i].getName());
                DisplayListText.text += b + '\n';
            }
            ////////////27/04/2022////////////
        }

    }

    //add vote to player.
    public void Vote(string s)
    {
        for(int i=0; i < p.Count; i++)
        {
            if(p[i].getName() == s)
            {
                p[i].addVote();
            }
        }
    }

    //check if all players have voted
    public void ChangePlayerVote()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "Vote" && y < p.Count - 1)
        {
            y++;
            UnityEngine.SceneManagement.SceneManager.LoadScene(6);
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(7);
        }
       
    }

    //change scene to HideAnimal and select random imposter and animal
    public void ChangeHideAnimalScene()
    {
        imposter = Random.Range(0, p.Count);
        animal = Random.Range(0, animals.Count);
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }


    //change Scene when all players have shown their role
    public void ChangeScene()
    {
        if(EventSystem.current.currentSelectedGameObject.name == "ShowAnimal")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Continue" && x < p.Count-1)
        {
            x = x + 1;
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }else if (EventSystem.current.currentSelectedGameObject.name == "Continue" && x == p.Count - 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(5);
        }
            
    }

    //add player name to list
    public void ReadStringInput(string s)
    {
        //mainInputField.DeactivateInputField();

        p.Add(new players(s));

        //used for testing
        //------------------------------
        for (int i = 0; i<p.Count; i++)
        {
            Debug.Log(p[i].getName());
        }
        int x = p.Count;


        Debug.Log(x);
        //------------------------------
    }

}
