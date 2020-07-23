using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forcaPulo;
    public float velocidadeMaxima;

    public int vidas;

    public bool isGrounded;
    
    public Rigidbody2D rigidbody2d;

    public GameObject lastCheckpoint;


    void Start()
    {
        inicializarObjetos();
    }

    private void inicializarObjetos()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        pular();
        andar();
        
    }

   void andar()
    {
        float movimento = Input.GetAxis("Horizontal");
        rigidbody2d.velocity = new Vector2(movimento * velocidadeMaxima, rigidbody2d.velocity.y);
        
        if(movimento < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } else if (movimento > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        TratarSpriteMovimento(movimento);


    }

    void TratarSpriteMovimento(float movimento)
    {
        if (movimento != 0 & isGrounded)
        {
            GetComponent<Animator>().SetBool("andando", true);
            GetComponent<Animator>().SetBool("pulando", false);
        }
        else if (isGrounded)
        {
            GetComponent<Animator>().SetBool("andando", false);
            GetComponent<Animator>().SetBool("pulando", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("pulando", true);
        }
    }

    void pular()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rigidbody2d.AddForce(new Vector2(0, forcaPulo));
            GetComponent<AudioSource>().Play();
            
        }
        if(isGrounded)
        {
            GetComponent<Animator>().SetBool("pulando", false);
        } else
        {
            GetComponent<Animator>().SetBool("pulando", true);
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            lastCheckpoint = collision.gameObject;
        }

        if (collision.gameObject.CompareTag("Refrigerante"))
        {
            velocidadeMaxima = velocidadeMaxima / 2;
            forcaPulo = 5000;
        }

        if (collision.gameObject.CompareTag("FioDental"))
        {
            velocidadeMaxima = velocidadeMaxima + 20f;
            forcaPulo = 7000;
            Destroy(collision.gameObject);
            StartCoroutine(time());
        }
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(20);
        velocidadeMaxima = velocidadeMaxima - 20;
        forcaPulo = 5300;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Refrigerante"))
        {
            velocidadeMaxima = velocidadeMaxima * 2;
            forcaPulo = 5300;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Carie"))
        {
            transform.position = lastCheckpoint.transform.position;
        }

        if (collision.gameObject.CompareTag("Buracos"))
        {
            transform.position = lastCheckpoint.transform.position;
        }

        if (collision.gameObject.CompareTag("FinalPrimeiraFase"))
        {
            GameObject.Find("GameController").GetComponent<GameController>().primeiraFaseConcluida = true;
            GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();
            GameObject.Find("MusicPlayer").GetComponent<AudioPlayer>().iniciouPrimeiraFase = false;
            GameObject.Find("MusicPlayer").GetComponent<AudioPlayer>().isPlaying = false;
            Application.LoadLevel("TransicaoFase1");

        }

        if (collision.gameObject.CompareTag("FinalSegundaFase"))
        {
            GameObject.Find("GameController").GetComponent<GameController>().segundaFaseConcluida = true;
            GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();
            GameObject.Find("MusicPlayer").GetComponent<AudioPlayer>().iniciouSegundaFase = false;
            GameObject.Find("MusicPlayer").GetComponent<AudioPlayer>().isPlaying = false;
            Application.LoadLevel("TransicaoFase2");
        }

        if (collision.gameObject.CompareTag("FinalTerceiraFase"))
        {
            GameObject.Find("GameController").GetComponent<GameController>().terceiraFaseConcluida = true;
            GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();
            GameObject.Find("MusicPlayer").GetComponent<AudioPlayer>().iniciouTerceiraFase = false;
            GameObject.Find("MusicPlayer").GetComponent<AudioPlayer>().isPlaying = false;
            Application.LoadLevel("TransicaoFase3");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }


}
