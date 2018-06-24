using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralStats : MonoBehaviour {

    public int strength;
    public int baseStrength;
    public int magic;
    public int baseMagic;
    public int spirit;
    public int baseSpirit;
    public int defense;
    public int baseDefense;
    public float criticalChance;
    public float baseCriticalChance;
    public int criticalDamage;
    public int baseCriticalDamage;
    public float accuracy;
    public float baseAccuracy;
    public List<float> statusResistance = new List<float>(5);
    public List<float> baseStatusResistance = new List<float>(5);
    public int health;
    public int baseHealth;
    public int speed;
    public int baseSpeed;
    public float evasion;
    public float baseEvasion;
    public float timeNeeded;
    public float actionTimer;
    public new string name;

    //public List<StatusEffect> statusEffectList;

    private void Start()
    {
        strength = baseStrength;
        magic = baseMagic;
        spirit = baseSpirit;
        defense = baseDefense;
        criticalChance = baseCriticalChance;
        criticalDamage = baseCriticalDamage;
        accuracy = baseAccuracy;
        statusResistance = baseStatusResistance;
        health = baseHealth;
        speed = baseSpeed;
        evasion = baseEvasion;
    }
}
