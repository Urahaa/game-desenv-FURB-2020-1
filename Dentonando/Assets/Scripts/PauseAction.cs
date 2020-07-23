using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAction : MonoBehaviour
{

    public GameObject painelPaused;
    public GameObject gameManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sair()
    {
        Time.timeScale = 1;
        Application.LoadLevel("SampleScene");
    }

    public void Continuar()
    {
        gameManager.GetComponent<GameManager>().isPaused = false;
        painelPaused.SetActive(false);
        Time.timeScale = 1;
    }

    public void Configuracoes()
    {

    }
}
