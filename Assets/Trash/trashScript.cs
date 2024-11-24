using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashScript : MonoBehaviour
{
    public trashData td;
    private Sprite sp;

    // Start is called before the first frame update
    void Start()
    {
        sp = td.possibleSprites[Random.Range(0, td.possibleSprites.Count)];
        gameObject.GetComponent<SpriteRenderer>().sprite = sp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Globals.inventory.Count < Globals.maxInventory)
        {
            Globals.inventory.Add(td.typeOfGarbage);
            Destroy(gameObject);
        }
    }
}
