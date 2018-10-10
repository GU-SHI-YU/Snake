using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{

    public GameObject FoodPrefab;

    public Transform BorderTop;
    public Transform BorderBottom;
    public Transform BorderLeft;
    public Transform BorderRight;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", 1, 4);
    }
    void Spawn()
    {
        int x = (int)Random.Range(BorderLeft.position.x, BorderRight.position.x);
        int y = (int)Random.Range(BorderBottom.position.y, BorderTop.position.y);
        Instantiate(FoodPrefab, new Vector2(x, y), Quaternion.identity);
    }
}