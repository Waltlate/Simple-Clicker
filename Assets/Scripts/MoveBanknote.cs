using System;
using System.Collections;
using UnityEngine;

public class MoveBanknote : MonoBehaviour
{
    [SerializeField] protected float delay = 0.1f;
    [SerializeField] protected float euler = 30f;
    [SerializeField] protected GameObject topFrontier = default;
    [SerializeField] protected GameObject bottomFrontier = default;

    protected float speed = 0.4f;

    protected virtual void OnEnable()
    {
        topFrontier = GameObject.Find("TopFrontier");
        bottomFrontier = GameObject.Find("BottomFrontier");
        StartCoroutine(StartMove());
        StartCoroutine(StartRotation());
        StartCoroutine(DestroyObject());
    }

    private IEnumerator StartMove()
    {
        Vector3 currentPosition = transform.position;
        Vector3 direction = new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(0.9f, 1f), 0);
        Debug.Log(direction);
        Debug.Log(Screen.height / 3f);
        while (isActiveAndEnabled && transform.position.y < topFrontier.transform.position.y) 
        {
            Debug.Log(direction);
            transform.position += direction * speed;
            yield return new WaitForSecondsRealtime(delay);
        }

    }

    private IEnumerator StartRotation()
    {
        while (isActiveAndEnabled)
        {
            transform.rotation = Quaternion.Euler(0, 0, euler);
            yield return new WaitForSecondsRealtime(delay);
            euler++;
        }
    }

    private IEnumerator DestroyObject()
    {
        while (isActiveAndEnabled)
        {
            Debug.Log(transform.position.y);
            Debug.Log("destroy");
            if(transform.position.y < bottomFrontier.transform.position.y)
            {
                Destroy(gameObject);
            }
            yield return new WaitForSecondsRealtime(delay);
        }
    }
}
