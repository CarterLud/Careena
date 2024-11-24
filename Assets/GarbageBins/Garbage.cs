using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Garbage : MonoBehaviour
{
    [Range(1, 3)]
    public int typeOfGarbageAccepting;
    public GameObject txt;
    public int score;

    private void Start()
    {
        txt.GetComponent<Text>().text = "Press F to access " + ((typeOfGarbageAccepting == 1) ? "Garbage" : (typeOfGarbageAccepting == 2) ? "Recycling" : "Compost");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && txt.activeSelf)
        {
            for (int i = 0; i < Globals.inventory.Count; i++)
            {
                if (Globals.inventory[i] == typeOfGarbageAccepting)
                {
                    Globals.socialStatus += score;
                    Globals.inventory.Remove(typeOfGarbageAccepting);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            txt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            txt.SetActive(false);
        }
    }

}
