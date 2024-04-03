using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Unit : MonoBehaviour
{
    
    public float AttackVal;
    public float DefenseVal;
    public float DefenseBonus;
    public float CurrentHP;
    public float MaxHP;
    
    public static float BoostBonus = 0.5f;
    public static float TerrainBonus = 1.5f ;
    public static float WallBonus = 4f; 
    public static float PoisonBonus = 0.7f;
    
    public bool Territory; // 4 healing
    public bool Veteran; // full HP +5 extra
    public bool Boosted; // 0.5 more attack
    public bool Poisoned; // 0.7 defense bonus
    public bool Terrain; // 1.5 defense bonus
    public bool Wall; // 4 defense bonus

    public void PoisonThis()
    {
        DefenseBonus = PoisonBonus;
    }
    public void UnPoisonThis()
    {
        if(Terrain)
            DefenseBonus = TerrainBonus;
        else if(Wall)
            DefenseBonus = WallBonus;
        else DefenseBonus = 1f;
    }
    public void HealThis()
    {
        if(Poisoned)
            Poisoned = false;
        else
        {
            if(Territory)
                CurrentHP += 4f;
            else CurrentHP += 2f;

            if(CurrentHP > MaxHP)
                CurrentHP = MaxHP;
        }
    }

    public void Veteranise()
    {
        if(!Veteran)
        {
            Veteran = true;
            MaxHP += 5f;
            CurrentHP = MaxHP;
        }
    }

    public void BoostThis()
    {
        if(!Boosted)
        {
            Boosted = true;
            AttackVal += 0.5f;
        }
    }
    public void UnBoostThis()
    {
        if(Boosted)
        {
            Boosted = false;
            AttackVal -= 0.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
