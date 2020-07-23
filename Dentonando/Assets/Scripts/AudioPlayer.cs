using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer singleton = null;

    public bool iniciouPrimeiraFase = false;
    public bool iniciouSegundaFase = false;
    public bool iniciouTerceiraFase = false;
    public bool isPlaying = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((iniciouPrimeiraFase || iniciouSegundaFase || iniciouTerceiraFase) && !isPlaying)
        {
            GetComponent<AudioSource>().Play();
            isPlaying = true;
        }
    }

    

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (singleton == null)
        {
            singleton = this;
        }
    }
}
