using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float AttackVal;
    public float DefenseVal;
    public float DefenseBonus;
    public float CurrentHP;
    public float MaxHP;
    
    public bool Veteran; //Full HP +5 extra
    public bool Boosted; //Attack +0.5
    public bool Poisoned; //DefenseBonus = 0.7
    public bool DefenseBuff; //DefenseBonus = 1.5
    public bool Wall; // DefenseBonus = 4

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
