using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject placar;
    public GameObject opcoes;
    public GameObject preJogo;
    public GameObject sobre;
    public GameObject fases;
    public InputField nomeJogador;
    // Start is called before the first frame update
    void Start()
    {
        //placar = gameObject.transform.parent.gameObject;
        placar.SetActive(false);
        opcoes.SetActive(false);
        preJogo.SetActive(false);
        fases.SetActive(false);
        sobre.SetActive(false);
    }

    public void JogarFase1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    } 
    
    public void AbrirJogar()
    {
        //nomeJogador.Text = "";
        //nomeJogador.text.ToString() = null;
        //nomeJogador.GetComponent<Text>().Text = null;
    }
    
    public void Configuracao ()
    {

    }

    public void Placar()
    {

    }

    public void Sobre ()
    {

    }

    public void Sair ()
    {
        Application.Quit();
    }
}
