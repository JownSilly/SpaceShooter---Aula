using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    [CreateAssetMenu(fileName = "Nave - ", menuName = "Inimigos", order =1)]
public class NavesModel : ScriptableObject
{
    [SerializeField]
    private int lifePoints;
    [SerializeField]
    private int speedPoints;
    [SerializeField]
    private int damagePoints;
    [SerializeField]
    private MonoBehaviour hability;
    public int GetLifePoints()
    {
        return lifePoints;
    }
    public int GetSpeedPoints()
    {
        return speedPoints;
    }
    public int GetDamagePoints()
    {
        return damagePoints;
    }
    public MonoBehaviour GetHability()
    {
        return hability;
    }
}
