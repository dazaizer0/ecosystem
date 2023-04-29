using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStatsManager : MonoBehaviour
{

    public float need = 100;
    public static bool lookingForNeeds;

    void Update()
    {

        if(need <= 0) 
            need = 0;

        if(need < 30)
            lookingForNeeds = true;
        else
            lookingForNeeds = false;
        
        need -= (1 * Time.deltaTime) * 5 /*/ 4*/;
    }

    void OnTriggerEnter(Collider other)
    {
        
        if(other.name == "need" && lookingForNeeds == true)
            need = 90;
    }
}
