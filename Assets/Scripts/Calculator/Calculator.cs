using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Calculator : MonoBehaviour
{
    public static float MyRound(float value) {
        if (value % 0.5f == 0)
            return Mathf.Ceil(value);
        else
            return Mathf.Floor(value);
    }
    public List<AttackValues> Attackers = new List<AttackValues>();
    public List<DefenseValues> Defenders = new List<DefenseValues>();
    void Start()
    {

    }
    [Serializable]
    public struct AttackValues
    {
        public float AttackVal;
        public float AttackHealth;
        public float AttackMax;
    }
    [Serializable]
    public struct DefenseValues
    {
        public float DefenseVal;
        public float DefenseHealth;
        public float DefenseMax;
        public float DefenseBonus;
    }
    float CalcAttackForce(AttackValues attackValues)
    {
        //Debug.Log("ATTACK FORCE IS: " + attackValues.AttackVal * (attackValues.AttackHealth /attackValues.AttackMax));
        return attackValues.AttackVal * (attackValues.AttackHealth /attackValues.AttackMax);
    }
    float CalcDefenseForce(DefenseValues defenseValues)
    {
        return defenseValues.DefenseVal * ( defenseValues.DefenseHealth /defenseValues.DefenseMax ) * defenseValues.DefenseBonus;
    }

    float AttackDamage(AttackValues attackValues, DefenseValues defenseValues)
    {   
        float attackForce = CalcAttackForce(attackValues);
        float defenseForce = CalcDefenseForce(defenseValues);
        float totalDamage = attackForce + defenseForce;

        float RawAttack = attackForce / totalDamage * attackValues.AttackVal * 4.5f;
        Debug.Log("Raw Attack Damage is: " + RawAttack + "\n" + 
                "Rounded is: " + Mathf.Round(RawAttack));

        return Mathf.Round((attackForce / totalDamage) * attackValues.AttackVal * 4.5f);
    }
    float DefenseDamage(AttackValues attackValues, DefenseValues defenseValues)
    {   
        float attackForce = CalcAttackForce(attackValues);
        float defenseForce = CalcDefenseForce(defenseValues);
        float totalDamage = attackForce + defenseForce;

        float RawDefense = (defenseForce / totalDamage) * defenseValues.DefenseVal * 4.5f;
        Debug.Log("Raw Defense Damage is: " + RawDefense + "\n" + 
                "Rounded is: " + Mathf.Floor(RawDefense)); 
        /*Debug.Log("DF: " + defenseForce + "\n" +
                    "AF: " + attackForce + "\n" +
                    "totalD: " + totalDamage);
        */
        return Mathf.Floor((defenseForce / totalDamage) * defenseValues.DefenseVal * 4.5f);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Damage Dealt " + AttackDamage(Attackers[0], Defenders[0]));
            Debug.Log("Damage Recieved " + DefenseDamage(Attackers[0], Defenders[0]));
        };
        /*if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("0.5 is " + Mathf.Round(0.5f));
            Debug.Log("-0.5 is " + Mathf.Round(-0.5f));
            Debug.Log("0.4 is " + Mathf.Round(0.4f));
            Debug.Log("1.4 is " + Mathf.Round(1.4f));
            Debug.Log("1.6 is " + Mathf.Round(1.6f));
            Debug.Log("1.5 is " + Mathf.Round(1.5f));


        }*/
    }
}

