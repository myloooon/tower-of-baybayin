using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script for most characters, except for E/I and O/U which are nearly identical. Be sure that changes here match changes there.
public class EICharacterElement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterSpawner characterSpawner;
    string currString;
    float[] dist;
    GameObject[] activeChars;
    public GameObject test; //rename this
    public int prevQueueLength;

    //public InputField Field;
    //public Text TextBox;


    void Start()
    {
        //GameObject input = GameObject.FindWithTag("InputField");
       //myInput = input.GetComponent<TextInput>();
        //input.Text = "test";

        //removes (Clone) that Unity gives to the gameObject's name
        transform.name = transform.name.Replace("(Clone)", "").Trim();
        this.gameObject.SetActive(true);
        test = GameObject.Find("ground");
        characterSpawner = test.GetComponent<CharacterSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        prevQueueLength = characterSpawner.charQueue.Count;

        foreach (char currChar in Input.inputString)
        {
            if ((currChar == '\n') || (currChar == '\r')) //enter or return
            {
            
                if (characterSpawner.charQueue.Peek() == this.gameObject)
                {
                    //Debug.Log("Player input: " + currString);
                    if (currString == "e" || currString == "i")
                    {
                        //Debug.Log(characterSpawner.charQueue.Peek());
                        characterSpawner.score++;
                        Debug.Log("Input was " + currString + ". Correct! Current score: " + characterSpawner.score);
                        characterSpawner.charQueue.Dequeue();
                        Destroy(gameObject);
                        //Debug.Log(characterSpawner.charQueue.Peek());
                        currString = "";

                        
                    }
                    else
                    {
                        if (prevQueueLength == characterSpawner.charQueue.Count && currString != "") // >=
                        {
                            //Debug.Log("Incorrect! Your input was: " + currString);
                            //CharacterSpawner.health--;
                            //Debug.Log("Health: " + characterSpawner.health);
                        }
                        //Debug.Log("Incorrect!");
                        currString = "";
                    }
                }
            }
            else
            {
                currString += currChar;
            }
        }
    }

}




//I just Marie Kondo'd the crap outta this code it is SO MUCH MORE LEGIBLE NOW
//these lines SPARK JOY
