using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inimigo - ", menuName ="Naves", order = 2)]
public class InimigosModel : ScriptableObject
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
