using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hand_moving : MonoBehaviour
{
    [SerializeField] private Vector2 offset;
    [SerializeField] private float moveS;

    private Vector2 startPosi;
    private Vector2 endPosi;
    private bool nowmoving = false;
    public AudioSource itai;


    // Start is called before the first frame update
    void Start()
    {
        startPosi = transform.position;
        endPosi = startPosi + offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (nowmoving == false && Input.GetMouseButtonDown(0))
            {
                StartCoroutine(GoAndBack());
            }
    }

    private IEnumerator GoAndBack()
    {
        nowmoving = true;
        yield return StartCoroutine(Move(endPosi));
        yield return StartCoroutine(Move(startPosi));
        nowmoving = false;
    }
    private IEnumerator Move(Vector2 destination)
    {
        while (Vector2.Distance((Vector2)transform.position, destination) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, moveS * Time.deltaTime);
            yield return null;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("death"))
        {
            itai.Play();
            GameManager.damage++;
            Debug.Log(GameManager.damage);
        }
    }

}
