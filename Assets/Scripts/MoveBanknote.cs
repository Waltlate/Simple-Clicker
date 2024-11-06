using System.Collections;
using UnityEngine;

public class MoveBanknote : MonoBehaviour
{
    [SerializeField] protected float delay = 0.1f;
    [SerializeField] protected float euler = 30f;
    [SerializeField] protected FrontierData frontierData = default;

    protected float speed = 0.4f;
    protected Vector3 direction = Vector3.zero;

    protected virtual void OnEnable()
    {
        StartCoroutine(StartMove());
        StartCoroutine(StartRotation());
        StartCoroutine(DestroyObject());
    }

    private IEnumerator StartMove()
    {
        direction = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(0.9f, 1f), 0);
        while (isActiveAndEnabled && transform.position.y < frontierData.TopFrontier)
        {
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
            if (transform.position.y < frontierData.BottomFrontier)
            {
                Destroy(gameObject);
            }
            yield return new WaitForSecondsRealtime(delay);
        }
    }
}
