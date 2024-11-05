using System;
using System.Collections;
using UnityEngine;

public class MoveBanknote : MonoBehaviour
{
    [SerializeField] protected float delay = 0.1f;
    [SerializeField] protected float euler = 30f;
    protected Rigidbody rb = default;
    protected float speed = 0.5f;

    protected virtual void OnEnable()
    {
        //rb = GetComponent<Rigidbody>();
        StartCoroutine(StartMove());
        StartCoroutine(StartRotation());
        StartCoroutine(DestroyObject());
    }

    private IEnumerator StartMove()
    {
        Vector3 currentPosition = transform.position;
        Vector3 direction = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(0.5f, 1f), 0);
        //direction.Normalize();
        Debug.Log(direction);
        Debug.Log(Screen.height / 3f);
        while (isActiveAndEnabled && transform.position.y < Screen.height * 2f / 3f) 
        {
            Debug.Log(direction);
            transform.position += direction * speed;
            //Debug.Log(Vector3.Distance(currentPosition, transform.position));
            yield return new WaitForSecondsRealtime(delay);
            //transform.position = Vector3.Lerp(transform.position, currentPosition + direction * Screen.height/3f, 0.01f);

            //if ((Vector3.Distance(currentPosition, transform.position) > Screen.height / 3f)) break;
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
            if(transform.position.y < -1 * Screen.height / 2f)
            {
                Destroy(gameObject);
            }
            yield return new WaitForSecondsRealtime(delay);
        }
    }
}
