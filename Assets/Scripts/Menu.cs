using Unity.Mathematics;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject Container;

    private bool isOpen = true;
    private float position = 1;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Container.SetActive(!Container.activeSelf);
            isOpen = isOpen == false;
            
        }
        if(isOpen == true)
        {
            position += 2f*Time.deltaTime;
            position = Mathf.Clamp(position, 0,1);
        }
        else
        {
            position -= 2f*Time.deltaTime;
            position = Mathf.Clamp(position, 0,1);
        }

        Container.GetComponent<RectTransform>().anchoredPosition = new Vector2(-290*(1-position), 0);
        //Debug.Log(position);
    }
}
