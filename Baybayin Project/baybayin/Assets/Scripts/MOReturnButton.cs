using UnityEngine;

public class MOReturnButton : MonoBehaviour
{
    public Sprite hoverPic;
    public Sprite OGPic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        //Debug.Log("hi!");
        transform.GetComponent<SpriteRenderer>().sprite = hoverPic;
        transform.localScale = new Vector3(1.0f, 1.0f, 0.0f);
    }

    private void OnMouseExit()
    {
        //Debug.Log("bye!");
        transform.GetComponent<SpriteRenderer>().sprite = OGPic;
        transform.localScale = new Vector3(0.5f, 0.5f, 0.0f);
    }

}
