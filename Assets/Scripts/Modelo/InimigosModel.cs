using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inimigo - ", menuName ="Inimigos", order = 2)]
public class InimigosModel : ScriptableObject
{
    [SerializeField]
    private int lifePoints;
    [SerializeField]
    private int speedPoints;
    [SerializeField]
    private int damagePoints;
    [SerializeField]
    private int scoreValue;
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
    public int GetScoreValue()
    {
        return scoreValue;
    }
}
