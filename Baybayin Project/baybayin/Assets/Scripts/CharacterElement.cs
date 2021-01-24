using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for most characters, except for E/I and O/U which are nearly identical. Be sure that changes here match changes there.
public class CharacterElement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterSpawner characterSpawner;
    string currString;
    float[] dist;
    GameObject[] activeChars;
    public GameObject test; //rename this
    public int prevQueueLength;

    void Start()
    {
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
                    if ((currString == gameObject.name) || 
                        (gameObject.name == "e" && currString == "i") || 
                        (gameObject.name == "o" && currString == "u"))
                    {
                        characterSpawner.score++;
                        Debug.Log("Input was " + currString + ". Correct! Current score: " + characterSpawner.score);
                        characterSpawner.charQueue.Dequeue();
                        Destroy(gameObject);
                        currString = "";
                        break;
                    }

                    else
                    {   //BUG: There is currently some sort of issue with the health counter decrementing incorrectly. Maybe correct and add feature later in update after release?
                        if (/*prevQueueLength == characterSpawner.charQueue.Count && */(currString != "")) // >=
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