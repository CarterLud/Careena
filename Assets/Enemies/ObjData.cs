using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data", order = 1)]
public class ObjData : ScriptableObject
{
    [SerializeField] List<Vector2> pos;
    [SerializeField] List<GameObject> litter;

    public Vector2 getRandomTarget() => pos[Random.Range(0, pos.Count - 1)];
    public GameObject getLitterObj() => litter[Random.Range(0, litter.Count - 1)];
}
