using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ReturnButton : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        //var width = Camera.main.ViewportToWorldPoint(new Vector2(1f,  0.5f));
        //cameraRightMiddle.z = transform.position.z;
        //transform.position = cameraRightMiddle;
        //public Sprite hoverPic;
}

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnMouseDown()
    {
        Debug.Log("clicked");
        SceneManager.LoadScene("home screen");
    }

   

}
