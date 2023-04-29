using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{

    public GameObject AI;

    void Start()
    {
        
        Vector3 position = new Vector3(0f, 0.5f, Random.Range(3f, -3f));
        Instantiate(AI, position, Quaternion.identity);
    }
    void Update()
    {
        
    }
}
