using UnityEngine;

[CreateAssetMenu(fileName = "FrontierData", menuName = "FrontierData")]
public class FrontierData : ScriptableObject
{
    protected double topFrontier = 0;
    protected double bottomFrontier = 0;

    public double TopFrontier => topFrontier;
    public double BottomFrontier => bottomFrontier;

    /// <summary>
    /// set top frontier
    /// </summary>
    /// <param name="frontier"></param>
    public void SetTopFrontier(double frontier) => topFrontier = frontier;

    /// <summary>
    /// set bottom frontier
    /// </summary>
    /// <param name="frontier"></param>
    public void SetBottomFrontier(double frontier) => bottomFrontier = frontier;
}
