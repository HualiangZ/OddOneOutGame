using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{   
    public Text changingText;
   // public AddPlayer player; 
    public int x = 0;
    static public List<string> players = new List<string>();

    //use the list to output the players name in to the textfield called 'PlayerNametxt' in 'HideAnimalScene'

    //IEnumerator Start()
    //{
    //    player = GetComponent<AddPlayer>();
    //    yield return new WaitForEndOfFrame();

    //}

    public void textChange()    
    {
        changingText.text = players[1];
 
    }


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
