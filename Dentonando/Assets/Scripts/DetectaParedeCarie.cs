using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaParedeCarie : MonoBehaviour
{
    public GameObject carie;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plataformas") || collision.gameObject.CompareTag("Carie"))
        {
            carie.transform.Rotate(new Vector3(0, 180, 0));
            carie.GetComponent<Carie>().movimento *= -1;
        }
    }
}
