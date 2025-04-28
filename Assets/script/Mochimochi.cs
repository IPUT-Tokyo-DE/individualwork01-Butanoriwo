using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mochimochi : MonoBehaviour
{
    [SerializeField] private bool mochi = false;
    public AudioSource pettan;
    public AudioSource men;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && mochi == true)
        {
            men.Play();
            GameManager.umami++;
            Debug.Log(GameManager.umami);
            mochi = false;
        }
        else if (other.gameObject.CompareTag("death") && mochi == false)
        {
            pettan.Play();
            mochi = true;
        }
        else if (other.gameObject.CompareTag("death") && mochi == true)
        {
            pettan.Play();
            GameManager.katame++;
        }

    }

}
