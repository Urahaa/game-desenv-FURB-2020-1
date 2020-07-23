using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController singleton = null;
    public bool primeiraFaseConcluida = false;
    public bool segundaFaseConcluida = false;
    public bool terceiraFaseConcluida = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<AudioPlayer>() != null)
        {
            if (primeiraFaseConcluida)
            {
                GameObject.Find("Botao Fase 2").GetComponentInParent<Button>().interactable = true;

                GetComponent<AudioPlayer>().iniciouPrimeiraFase = false;
            }

            if (segundaFaseConcluida)
            {
                GameObject.Find("Botao Fase 3").GetComponentInParent<Button>().interactable = true;
                GetComponent<AudioPlayer>().iniciouSegundaFase = false;
            }
            if (terceiraFaseConcluida)
            {
                GetComponent<AudioPlayer>().iniciouTerceiraFase = false;
            }
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
