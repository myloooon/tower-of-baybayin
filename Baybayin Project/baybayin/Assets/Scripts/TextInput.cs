using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{

    void Start()
    {
        
        var input = gameObject.GetComponent<InputField>();

        input.Select();
        input.ActivateInputField();

        var se = new InputField.SubmitEvent();

        

        se.AddListener(SubmitName);
        input.onEndEdit = se;

        //or simply use the line below, 
        //input.onEndEdit.AddListener(SubmitName);  // This also works
    }


    private void SubmitName(string arg0)
    {
        Debug.Log("Input: " + arg0);

    }

}