using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject Container;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Container.SetActive(!Container.activeSelf);
        }
    }
}
