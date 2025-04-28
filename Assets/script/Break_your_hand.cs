using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Break_your_hand : MonoBehaviour
{
    [SerializeField] private Vector2 offset;
    [SerializeField] private float move;
    [SerializeField] private float wait;

    private Vector2 startPosi;
    private Vector2 endPosi;

    // Start is called before the first frame update
    void Start()
    {
        startPosi = transform.position;
        endPosi = startPosi + offset;
        StartCoroutine(GoAndBack(wait));
 
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator GoAndBack(float stop)
    {
        for (float i = 1; i < 31; i++)
        {
            float boost = i * 5;
            if (boost < move)
            {
                yield return StartCoroutine(Move(endPosi, boost));
                yield return StartCoroutine(Move(startPosi, boost));
                yield return new WaitForSeconds(stop);
            } else{
                yield return StartCoroutine(Move(endPosi, move));
                yield return StartCoroutine(Move(startPosi, move));
                if (i == 20)
                {
                    yield return new WaitForSeconds(0.6f);
                }
                else
                {
                    yield return new WaitForSeconds(stop);
                }
            }
        }

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("End");

    }
    private IEnumerator Move(Vector2 destination, float moveS)
    {
        while (Vector2.Distance((Vector2)transform.position, destination) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, moveS * Time.deltaTime);
            yield return null;
        }

    }

}
