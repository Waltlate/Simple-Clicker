using UnityEngine;

public class InitFrontier : MonoBehaviour
{
    [SerializeField] protected FrontierData frontierData = default;
    [SerializeField] protected GameObject topFrontier = default;
    [SerializeField] protected GameObject bottomFrontier = default;

    protected virtual void Start()
    {
        frontierData.SetTopFrontier(topFrontier.transform.position.y);
        frontierData.SetBottomFrontier(bottomFrontier.transform.position.y);
    }
}
