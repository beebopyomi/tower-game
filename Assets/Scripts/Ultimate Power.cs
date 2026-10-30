using System.Security.Cryptography;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UltimatePower : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
{
    if (Input.GetKeyDown(KeyCode.Y))
    {
        GameObject[] hellObjects = GameObject.FindGameObjectsWithTag("hell");
        foreach (GameObject obj in hellObjects)
        {
            HealthManager.Instance.UpdateHealth(-1);
            Destroy(obj);
        }
    }
}
}
