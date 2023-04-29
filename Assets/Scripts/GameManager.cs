using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI Timer;
    private float timer;

    public float TimeScale;

    void Start()
    {
        
        TimeScale = 1;
    }

    void Update()
    {
        
        Time.timeScale = TimeScale;

        timer += 1 * Time.deltaTime;
        Timer.text = timer.ToString("F1");
    }
}
