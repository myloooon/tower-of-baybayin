using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        //GameObject textGO = new GameObject();
        text = GetComponent<Text>();
        text.text = "hewwo";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            text.fontSize = 30;
        }
    }

}
