using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fases : MonoBehaviour
{

    public void Update()
    {
        if (GameObject.Find("GameController") != null)
        {
            if (GameObject.Find("GameController").GetComponent<GameController>().primeiraFaseConcluida && GameObject.Find("Botão Fase 2") != null)
            {
                GameObject.Find("Botão Fase 2").GetComponentInParent<Button>().interactable = true;
                GameObject.Find("MusicPlayer").GetComponent<AudioPlayer>().iniciouPrimeiraFase = false;
            }

            if (GameObject.Find("GameController").GetComponent<GameController>().segundaFaseConcluida && GameObject.Find("Botão Fase 3") != null)
            {
                GameObject.Find("Botão Fase 3").GetComponentInParent<Button>().interactable = true;
                GameObject.Find("MusicPlayer").GetComponent<AudioPlayer>().iniciouSegundaFase = false;
            }

            if (GameObject.Find("GameController").GetComponent<GameController>().terceiraFaseConcluida)
            {
                GameObject.Find("MusicPlayer").GetComponent<AudioPlayer>().iniciouTerceiraFase = false;
            }
        }
    }

    public void JogarFase1()
    {
        GameObject.Find("MusicPlayer").GetComponent<AudioPlayer>().iniciouPrimeiraFase = true;
        Application.LoadLevel("PrimeiraFase");
    }

    public void JogarFase2()
    {
        GameObject.Find("MusicPlayer").GetComponent<AudioPlayer>().iniciouSegundaFase = true;
        Application.LoadLevel("SegundaFase");
    }

    public void JogarFase3()
    {
        GameObject.Find("MusicPlayer").GetComponent<AudioPlayer>().iniciouTerceiraFase = true;
        Application.LoadLevel("TerceiraFase");
    }

}
