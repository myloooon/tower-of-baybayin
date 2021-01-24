using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Works as the main game script. Handles the queue of characters, score, and game over conditions. 
public class CharacterSpawner : MonoBehaviour
{
    GameObject[] characters;
    Vector3 spawnVector = new Vector3(0, 6, 0);
    public Queue <GameObject> charQueue = new Queue<GameObject>();
    int gameStart;
    int lastCharPos;
    int nextCharPos;

    int frames;

    public int health;
    public int score;
    public float timeBetweenChars;

    void Start()
    {
        characters = new GameObject[2]; //temp for now; will change length to be variable later
        characters = Resources.LoadAll<GameObject>("Prefabs"); //loads in prefabs into the array as gameObject
        gameStart = 1;

        health = 3; //variable with difficulty?
        score = 0;
        timeBetweenChars = 5;

        StartCoroutine(characterSpawner()); //coroutine tells Unity to operate independently of frames
    }


    IEnumerator characterSpawner() //IEnumerator is used by Unity to make StartCoroutine work
    {
        if (this.gameObject != null)
        {
            while (this.gameObject)
            {
                if (gameStart != 1)
                {
                    nextCharPos = Random.Range(0, characters.Length);
                    while (lastCharPos == nextCharPos)
                    {
                        nextCharPos = Random.Range(0, characters.Length);
                    }
                    yield return new WaitForSeconds(timeBetweenChars); 
                    charQueue.Enqueue(Instantiate(characters[nextCharPos], spawnVector, Quaternion.identity));
                    lastCharPos = nextCharPos;
                }

                else
                {
                    //yield return new WaitForSeconds(1); 
                    lastCharPos = Random.Range(0, characters.Length);
                    charQueue.Enqueue(Instantiate(characters[lastCharPos], spawnVector, Quaternion.identity));
                    gameStart = 0;
                }
            }
        }

       
    }

  void Update()
    {
        frames++;
        if (frames % 1000 == 0)
        {
            timeBetweenChars = timeBetweenChars / 1.5f;
            Debug.Log("1500 frames! Time between characters is now " + timeBetweenChars);
        }

        if (Input.anyKeyDown) //for debugging
        {

           // print(Input.inputString);

        }

        if (charQueue.Count == 8 /*|| health == 0*/) //change value of queue size if needed
        {
            //charQueue.Clear();
            SceneManager.LoadScene("u lose lol"); //if tower gets too large, game over

            Debug.Log("game over!");
            Debug.Log("Final score: " + score);
            //DontDestroyOnLoad(this.gameObject);
        }



    }

    public int finalScore()
    {
        return score;
    }



}


