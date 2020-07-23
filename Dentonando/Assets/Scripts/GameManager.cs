using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour  
{

    public GameObject painelPaused;
    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        if (isPaused)
        {

            isPaused = false;
            painelPaused.SetActive(isPaused);
            Time.timeScale = 1;
        } else
        {
            isPaused = true;
            painelPaused.SetActive(isPaused);
            Time.timeScale = 0;
        }
        
    }
}
