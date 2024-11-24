using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="TrashData", order = 2)]
public class trashData : ScriptableObject
{
    public List<Sprite> possibleSprites = new List<Sprite>();
    [Range(1, 3)]
    public int typeOfGarbage; // type of trash like compost, waste, recycling
    
}
