using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Relic : ScriptableObject
{
    [HideInInspector] public string relic;
    public string Name;

    public int ID;
    public string Description = "";
    public Sprite icon;

    // int that are floats for bigger numbers
  [HideInInspector]public float HPBonus;
  [HideInInspector]public float MovementSpeedBonus;
  [HideInInspector]public float Damage;
  [HideInInspector]public float BlockChanceBonus;
  [HideInInspector]public float MultiAttackBonus;
  [HideInInspector]public float AbilityDamage;
  [HideInInspector]public float ArmourStats;
    //percentage
    [HideInInspector] public float StunChanceBonus;
    [HideInInspector] public float DodgeBonus;
    [HideInInspector] public float CritDamageBonus;
    [HideInInspector] public float StaminaRegenBonus;
    [HideInInspector] public float CooldownReduction;
    [HideInInspector] public float AOEchanceBonus;
    [HideInInspector] public float CritChance;
    [HideInInspector] public float GoldBonus;
    [HideInInspector] public float Rareitydroprate;
    [HideInInspector] public float EXPbonus;
    [HideInInspector] public float HealthRegen;
    public float Gold;
    [HideInInspector] public RelicType RelicClass;
    
    private int NumOfRandomStats;

    public enum RelicType{
        Beginner,
        BattleHarden,
        Expert
    }
    public void Awake()
    {
        Gold = GameObject.Find("Player").GetComponent<PlayerStats>().Gold;
        RandomStats();
        relic = RelicClass.ToString();

    }


    public void RandomStats()
    {
        NumOfRandomStats = Random.Range(1,3);

        for (int i = 0; i < NumOfRandomStats; i++)
        {
            switch (Random.Range(0,17))
            {
                case 0:
                    //HP Bonnus and the amount gold 
                    if (Gold < 1000)
                        HPBonus = 50;
                    if (Gold > 1000)
                        HPBonus = 100;
                    if (Gold > 2000)
                        HPBonus = 200;
                    if (Gold > 3000)
                        HPBonus = 300;
                    if (Gold > 4000)
                        HPBonus = 400;
                    if (Gold > 5000)
                        HPBonus = 500;
                    if (Gold > 6000)
                        HPBonus = 600;
                    if (Gold > 7000)
                        HPBonus = 700;
                    if (Gold > 8000)
                        HPBonus = 800;
                    if (Gold > 9000)
                        HPBonus = 900;
                    if (Gold > 10000)
                        HPBonus = 1000;
                    if (Gold > 11000)
                        HPBonus = 1100;
                    if (Gold > 12000)
                        HPBonus = 1200;
                    if (Gold > 13000)
                        HPBonus = 1300;
                    if (Gold > 14000)
                        HPBonus = 1400;
                    if (Gold > 15000)
                        HPBonus = 1500;
                    if (Gold > 16000)
                        HPBonus = 1600;
                    if (Gold > 17000)
                        HPBonus = 1700;
                    if (Gold > 18000)
                    {
                        HPBonus = 1800;
                        if (Gold > 19000)
                            HPBonus += 1000;
                    }
                    break;
                case 1:
                    if (Gold < 1000)
                        MovementSpeedBonus = 1;
                    if (Gold > 1000)
                        MovementSpeedBonus = 2;
                    if (Gold > 2000)
                        MovementSpeedBonus = 3;
                    if (Gold > 3000)
                        MovementSpeedBonus = 4;
                    if (Gold > 4000)
                        MovementSpeedBonus= 5;
                    if (Gold > 5000)
                        MovementSpeedBonus = 6;
                    if (Gold > 6000)
                        MovementSpeedBonus = 7;
                    if (Gold > 7000)
                        MovementSpeedBonus = 8;
                    if (Gold > 8000)
                        MovementSpeedBonus = 9;
                    if (Gold > 9000)
                        MovementSpeedBonus = 10;
                    if (Gold > 10000)
                        MovementSpeedBonus = 11;
                    if (Gold > 11000)
                        MovementSpeedBonus = 12;
                    if (Gold > 12000)
                        MovementSpeedBonus = 13;
                    if (Gold > 13000)
                        MovementSpeedBonus = 14;
                    if (Gold > 14000)
                        MovementSpeedBonus = 15;
                    if (Gold > 15000)
                        MovementSpeedBonus = 16;
                    if (Gold > 16000)
                        MovementSpeedBonus = 17;
                    if (Gold > 17000)
                        MovementSpeedBonus = 18;
                    if (Gold > 18000)
                    {
                        MovementSpeedBonus = 19;
                        if (Gold > 19000)
                            HPBonus += 1;
                    }
                    break;
                case 2:
                   
                    if (Gold < 1000)
                        Damage = 1;
                    if (Gold > 1000)
                        Damage = 2;
                    if (Gold > 2000)
                        Damage = 3;
                    if (Gold > 3000)
                        Damage = 4;
                    if (Gold > 4000)
                       Damage = 5;
                    if (Gold > 5000)
                        Damage = 6;
                    if (Gold > 6000)
                        Damage = 7;
                    if (Gold > 7000)
                        Damage = 8;
                    if (Gold > 8000)
                       Damage = 9;
                    if (Gold > 9000)
                        Damage = 10;
                    if (Gold > 10000)
                        Damage = 11;
                    if (Gold > 11000)
                        Damage = 12;
                    if (Gold > 12000)
                        Damage = 13;
                    if (Gold > 13000)
                        Damage = 14;
                    if (Gold > 14000)
                        Damage = 15;
                    if (Gold > 15000)
                        Damage = 16;
                    if (Gold > 16000)
                        Damage = 17;
                    if (Gold > 17000)
                       Damage = 18;
                    if (Gold > 18000)
                    {
                        Damage = 19;
                        if (Gold > 19000)
                            Damage += 1;
                    }
                    break;
                case 3:
                    
                    if (Gold < 1000)
                        BlockChanceBonus = 0.01f;
                    if (Gold > 1000)
                        BlockChanceBonus = 0.02f;
                    if (Gold > 2000)
                        BlockChanceBonus = 0.03f;
                    if (Gold > 3000)
                        BlockChanceBonus =0.04f;
                    if (Gold > 4000)
                        BlockChanceBonus = 0.05f;
                    if (Gold > 5000)
                        BlockChanceBonus = 0.06f;
                    if (Gold > 6000)
                        BlockChanceBonus = 0.07f;
                    if (Gold > 7000)
                        BlockChanceBonus = 0.08f;
                    if (Gold > 8000)
                        BlockChanceBonus = 0.09f;
                    if (Gold > 9000)
                        BlockChanceBonus = 0.10f;
                    if (Gold > 10000)
                        BlockChanceBonus = 0.11f;
                    if (Gold > 11000)
                        BlockChanceBonus = 0.12f;
                    if (Gold > 12000)
                        BlockChanceBonus = 0.13f;
                    if (Gold > 13000)
                        BlockChanceBonus = 0.15f;
                    if (Gold > 14000)
                        BlockChanceBonus = 0.16f;
                    if (Gold > 15000)
                        BlockChanceBonus = 0.17f;
                    if (Gold > 16000)
                        BlockChanceBonus = 0.18f;
                    if (Gold > 17000)
                        BlockChanceBonus = 0.19f;
                    if (Gold > 18000)
                    {
                        BlockChanceBonus= 0.20f;
                        if (Gold > 19000)
                            BlockChanceBonus += 0.01f;
                    }
                    break;
                case 4:
                    
                    if (Gold < 1000)
                       MultiAttackBonus= 0.01f;
                    if (Gold > 1000)
                        MultiAttackBonus = 0.02f;
                    if (Gold > 2000)
                        MultiAttackBonus = 0.03f;
                    if (Gold > 3000)
                        MultiAttackBonus = 0.04f;
                    if (Gold > 4000)
                        MultiAttackBonus = 0.05f;
                    if (Gold > 5000)
                        MultiAttackBonus = 0.06f;
                    if (Gold > 6000)
                        MultiAttackBonus = 0.07f;
                    if (Gold > 7000)
                        MultiAttackBonus = 0.08f;
                    if (Gold > 8000)
                        MultiAttackBonus = 0.09f;
                    if (Gold > 9000)
                        MultiAttackBonus = 0.10f;
                    if (Gold > 10000)
                        MultiAttackBonus= 0.11f;
                    if (Gold > 11000)
                        MultiAttackBonus = 0.12f;
                    if (Gold > 12000)
                        MultiAttackBonus = 0.13f;
                    if (Gold > 13000)
                       MultiAttackBonus = 0.14f;
                    if (Gold > 14000)
                        MultiAttackBonus = 0.15f;
                    if (Gold > 15000)
                        MultiAttackBonus = 0.16f;
                    if (Gold > 16000)
                        MultiAttackBonus = 0.17f;
                    if (Gold > 17000)
                        MultiAttackBonus = 0.18f;
                    if (Gold > 18000)
                    {
                        MultiAttackBonus= 0.19f;
                        if (Gold > 19000)
                            MultiAttackBonus += 0.01f;
                    }
                    break;
                case 5:
                    AbilityDamage = 1;
                    if (Gold < 1000)
                       AbilityDamage = 0.01f;
                    if (Gold > 1000)
                        AbilityDamage = 0.02f;
                    if (Gold > 2000)
                        AbilityDamage = 0.03f;
                    if (Gold > 3000)
                        AbilityDamage = 0.04f;
                    if (Gold > 4000)
                        AbilityDamage = 0.05f;
                    if (Gold > 5000)
                        AbilityDamage = 0.06f;
                    if (Gold > 6000)
                        AbilityDamage = 0.07f;
                    if (Gold > 7000)
                        AbilityDamage = 0.08f;
                    if (Gold > 8000)
                        AbilityDamage = 0.09f;
                    if (Gold > 9000)
                        AbilityDamage = 0.10f;
                    if (Gold > 10000)
                        AbilityDamage = 0.11f;
                    if (Gold > 11000)
                        AbilityDamage = 0.12f;
                    if (Gold > 12000)
                        AbilityDamage = 0.13f;
                    if (Gold > 13000)
                        AbilityDamage = 0.14f;
                    if (Gold > 14000)
                        AbilityDamage = 0.15f;
                    if (Gold > 15000)
                        AbilityDamage = 0.16f;
                    if (Gold > 16000)
                        AbilityDamage = 0.17f;
                    if (Gold > 17000)
                        AbilityDamage = 0.18f;
                    if (Gold > 18000)
                    {
                        AbilityDamage = 0.19f;
                        if (Gold > 19000)
                            AbilityDamage += 0.01f;
                    }
                    break;
                case 6:
                    
                    if (Gold < 1000)
                        ArmourStats= 1;
                    if (Gold > 1000)
                        ArmourStats = 2;
                    if (Gold > 2000)
                        ArmourStats = 3;
                    if (Gold > 3000)
                        ArmourStats = 4;
                    if (Gold > 4000)
                        ArmourStats = 5;
                    if (Gold > 5000)
                        ArmourStats = 6;
                    if (Gold > 6000)
                        ArmourStats = 7;
                    if (Gold > 7000)
                        ArmourStats = 8;
                    if (Gold > 8000)
                        ArmourStats = 9;
                    if (Gold > 9000)
                        ArmourStats = 10;
                    if (Gold > 10000)
                        ArmourStats = 11;
                    if (Gold > 11000)
                        ArmourStats = 12;
                    if (Gold > 12000)
                        ArmourStats = 13;
                    if (Gold > 13000)
                       ArmourStats = 14;
                    if (Gold > 14000)
                        ArmourStats = 15;
                    if (Gold > 15000)
                        ArmourStats = 16;
                    if (Gold > 16000)
                        ArmourStats = 17;
                    if (Gold > 17000)
                        ArmourStats = 18;
                    if (Gold > 18000)
                    {
                        ArmourStats = 19;
                        if (Gold > 19000)
                            ArmourStats += 1f;
                    }
                    break;
                case 7:
                    
                    if (Gold < 1000)
                        StunChanceBonus = 0.01f;
                    if (Gold > 1000)
                       StunChanceBonus = 0.02f;
                    if (Gold > 2000)
                        StunChanceBonus = 0.03f;
                    if (Gold > 3000)
                        StunChanceBonus = 0.04f;
                    if (Gold > 4000)
                        StunChanceBonus = 0.05f;
                    if (Gold > 5000)
                        StunChanceBonus = 0.06f;
                    if (Gold > 6000)
                        StunChanceBonus = 0.07f;
                    if (Gold > 7000)
                        StunChanceBonus = 0.08f;
                    if (Gold > 8000)
                        StunChanceBonus = 0.09f;
                    if (Gold > 9000)
                        StunChanceBonus = 0.10f;
                    if (Gold > 10000)
                        StunChanceBonus = 0.11f;
                    if (Gold > 11000)
                        StunChanceBonus = 0.12f;
                    if (Gold > 12000)
                        StunChanceBonus = 0.13f;
                    if (Gold > 13000)
                        StunChanceBonus = 0.14f;
                    if (Gold > 14000)
                        StunChanceBonus = 0.15f;
                    if (Gold > 15000)
                        StunChanceBonus = 0.16f;
                    if (Gold > 16000)
                        StunChanceBonus = 0.17f;
                    if (Gold > 17000)
                        StunChanceBonus = 0.18f;
                    if (Gold > 18000)
                    {
                        StunChanceBonus= 0.19f;
                        if (Gold > 19000)
                            StunChanceBonus += 0.01f;
                    }
                    break;
                case 8:
                    
                    if (Gold < 1000)
                        DodgeBonus = 0.01f;
                    if (Gold > 1000)
                        DodgeBonus = 0.02f;
                    if (Gold > 2000)
                        DodgeBonus = 0.03f;
                    if (Gold > 3000)
                        DodgeBonus = 0.04f;
                    if (Gold > 4000)
                        DodgeBonus = 0.05f;
                    if (Gold > 5000)
                        DodgeBonus = 0.06f;
                    if (Gold > 6000)
                        DodgeBonus = 0.07f;
                    if (Gold > 7000)
                        DodgeBonus = 0.08f;
                    if (Gold > 8000)
                        DodgeBonus = 0.09f;
                    if (Gold > 9000)
                        DodgeBonus = 0.10f;
                    if (Gold > 10000)
                        DodgeBonus = 0.11f;
                    if (Gold > 11000)
                        DodgeBonus = 0.12f;
                    if (Gold > 12000)
                        DodgeBonus = 0.13f;
                    if (Gold > 13000)
                        DodgeBonus = 0.14f;
                    if (Gold > 14000)
                        DodgeBonus = 0.15f;
                    if (Gold > 15000)
                        DodgeBonus = 0.16f;
                    if (Gold > 16000)
                        DodgeBonus = 0.17f;
                    if (Gold > 17000)
                        DodgeBonus = 0.18f;
                    if (Gold > 18000)
                    {
                        DodgeBonus = 0.19f;
                        if (Gold > 19000)
                            DodgeBonus += 0.01f;
                    }
                    break;
                case 9:

                    if (Gold < 1000)
                        CritDamageBonus = 1;
                    if (Gold > 1000)
                        CritDamageBonus = 2;
                    if (Gold > 2000)
                        CritDamageBonus = 3;
                    if (Gold > 3000)
                        CritDamageBonus = 4;
                    if (Gold > 4000)
                        CritDamageBonus = 5;
                    if (Gold > 5000)
                        CritDamageBonus = 6;
                    if (Gold > 6000)
                        CritDamageBonus = 7;
                    if (Gold > 7000)
                        CritDamageBonus = 8;
                    if (Gold > 8000)
                        CritDamageBonus = 9;
                    if (Gold > 9000)
                        CritDamageBonus = 10;
                    if (Gold > 10000)
                        CritDamageBonus = 11;
                    if (Gold > 11000)
                        CritDamageBonus = 12;
                    if (Gold > 12000)
                        CritDamageBonus = 13;
                    if (Gold > 13000)
                        CritDamageBonus = 14;
                    if (Gold > 14000)
                        CritDamageBonus = 15;
                    if (Gold > 15000)
                        CritDamageBonus = 16;
                    if (Gold > 16000)
                        CritDamageBonus = 17;
                    if (Gold > 17000)
                        CritDamageBonus = 18;
                    if (Gold > 18000)
                    {
                        CritDamageBonus = 19;
                        if (Gold > 19000)
                            CritDamageBonus += 1;
                    }
                    break;
                case 10:
                    
                    if (Gold < 1000)
                        StaminaRegenBonus = 1;
                    if (Gold > 1000)
                        StaminaRegenBonus = 2;
                    if (Gold > 2000)
                        StaminaRegenBonus = 3;
                    if (Gold > 3000)
                        StaminaRegenBonus = 4;
                    if (Gold > 4000)
                        StaminaRegenBonus = 5;
                    if (Gold > 5000)
                        StaminaRegenBonus = 6;
                    if (Gold > 6000)
                        StaminaRegenBonus = 7;
                    if (Gold > 7000)
                        StaminaRegenBonus = 8;
                    if (Gold > 8000)
                        StaminaRegenBonus = 9;
                    if (Gold > 9000)
                        StaminaRegenBonus = 10;
                    if (Gold > 10000)
                        StaminaRegenBonus = 11;
                    if (Gold > 11000)
                        StaminaRegenBonus = 12;
                    if (Gold > 12000)
                        StaminaRegenBonus = 13;
                    if (Gold > 13000)
                        StaminaRegenBonus = 14;
                    if (Gold > 14000)
                        StaminaRegenBonus = 15;
                    if (Gold > 15000)
                        StaminaRegenBonus = 16;
                    if (Gold > 16000)
                        StaminaRegenBonus = 17;
                    if (Gold > 17000)
                        StaminaRegenBonus = 18;
                    if (Gold > 18000)
                    {
                        StaminaRegenBonus = 19;
                        if (Gold > 19000)
                            StaminaRegenBonus += 1;
                    }
                    break;
                case 11:
               
                    if (Gold < 1000)
                        CooldownReduction = 0.01f;
                    if (Gold > 1000)
                        CooldownReduction = 0.02f;
                    if (Gold > 2000)
                        CooldownReduction = 0.03f;
                    if (Gold > 3000)
                        CooldownReduction = 0.04f;
                    if (Gold > 4000)
                        CooldownReduction = 0.05f;
                    if (Gold > 5000)
                        CooldownReduction = 0.06f;
                    if (Gold > 6000)
                       CooldownReduction = 0.07f;
                    if (Gold > 7000)
                       CooldownReduction = 0.08f;
                    if (Gold > 8000)
                        CooldownReduction = 0.09f;
                    if (Gold > 9000)
                        CooldownReduction = 0.10f;
                    if (Gold > 10000)
                        CooldownReduction = 0.11f;
                    if (Gold > 11000)
                        CooldownReduction = 0.12f;
                    if (Gold > 12000)
                        CooldownReduction = 0.13f;
                    if (Gold > 13000)
                        CooldownReduction = 0.14f;
                    if (Gold > 14000)
                        CooldownReduction = 0.15f;
                    if (Gold > 15000)
                        CooldownReduction = 0.16f;
                    if (Gold > 16000)
                        CooldownReduction= 0.17f;
                    if (Gold > 17000)
                        CooldownReduction = 0.18f;
                    if (Gold > 18000)
                    {
                        CooldownReduction = 0.19f;
                        if (Gold > 19000)
                            CooldownReduction += 0.1f;
                    }
                    break;
                case 12:
                   
                    if (Gold < 1000)
                        AOEchanceBonus = 0.01f;
                    if (Gold > 1000)
                        AOEchanceBonus = 0.02f;
                    if (Gold > 2000)
                      AOEchanceBonus = 0.03f;
                    if (Gold > 3000)
                        AOEchanceBonus = 0.04f;
                    if (Gold > 4000)
                        AOEchanceBonus = 0.05f;
                    if (Gold > 5000)
                        AOEchanceBonus = 0.06f;
                    if (Gold > 6000)
                       AOEchanceBonus = 0.07f;
                    if (Gold > 7000)
                       AOEchanceBonus = 0.08f;
                    if (Gold > 8000)
                        AOEchanceBonus = 0.09f;
                    if (Gold > 9000)
                        AOEchanceBonus = 0.10f;
                    if (Gold > 10000)
                        AOEchanceBonus = 0.11f;
                    if (Gold > 11000)
                        AOEchanceBonus = 0.12f;
                    if (Gold > 12000)
                        AOEchanceBonus = 0.13f;
                    if (Gold > 13000)
                        AOEchanceBonus = 0.14f;
                    if (Gold > 14000)
                        AOEchanceBonus = 0.15f;
                    if (Gold > 15000)
                        AOEchanceBonus = 0.16f;
                    if (Gold > 16000)
                        AOEchanceBonus = 0.17f;
                    if (Gold > 17000)
                        AOEchanceBonus = 0.18f;
                    if (Gold > 18000)
                    {
                        AOEchanceBonus = 0.19f;
                        if (Gold > 19000)
                            AOEchanceBonus += 0.1f;
                    }
                    break;
                case 13:
                   
                    if (Gold < 1000)
                        CritChance = 0.01f;
                    if (Gold > 1000)
                        CritChance = 0.02f;
                    if (Gold > 2000)
                        CritChance = 0.03f;
                    if (Gold > 3000)
                        CritChance = 0.04f;
                    if (Gold > 4000)
                        CritChance = 0.05f;
                    if (Gold > 5000)
                        CritChance = 0.06f;
                    if (Gold > 6000)
                        CritChance = 0.07f;
                    if (Gold > 7000)
                        CritChance = 0.08f;
                    if (Gold > 8000)
                        CritChance = 0.09f;
                    if (Gold > 9000)
                        CritChance = 0.10f;
                    if (Gold > 10000)
                        CritChance = 0.11f;
                    if (Gold > 11000)
                        CritChance = 0.12f;
                    if (Gold > 12000)
                        CritChance = 0.13f;
                    if (Gold > 13000)
                        CritChance = 0.14f;
                    if (Gold > 14000)
                        CritChance = 0.15f;
                    if (Gold > 15000)
                       CritChance = 0.16f;
                    if (Gold > 16000)
                        CritChance = 0.17f;
                    if (Gold > 17000)
                        CritChance = 0.18f;
                    if (Gold > 18000)
                    {
                        CritChance = 0.19f;
                        if (Gold > 19000)
                            CritChance += 0.1f;
                    }
                    break;
                case 14:
                    
                    if (Gold < 1000)
                        GoldBonus= 1.0f;
                    if (Gold > 1000)
                        GoldBonus = 1.1f;
                    if (Gold > 2000)
                        GoldBonus = 1.2f;
                    if (Gold > 3000)
                        GoldBonus = 1.3f;
                    if (Gold > 4000)
                        GoldBonus = 1.4f;
                    if (Gold > 5000)
                        GoldBonus = 1.5f;
                    if (Gold > 6000)
                        GoldBonus = 1.6f;
                    if (Gold > 7000)
                        GoldBonus = 1.7f;
                    if (Gold > 8000)
                        GoldBonus = 1.8f;
                    if (Gold > 9000)
                        GoldBonus = 1.9f;
                    if (Gold > 10000)
                        GoldBonus = 2.0f;
                    if (Gold > 11000)
                        GoldBonus = 2.1f;
                    if (Gold > 12000)
                        GoldBonus = 2.2f;
                    if (Gold > 13000)
                        GoldBonus = 2.3f;
                    if (Gold > 14000)
                        GoldBonus = 2.4f;
                    if (Gold > 15000)
                        GoldBonus = 2.5f;
                    if (Gold > 16000)
                        GoldBonus = 2.6f;
                    if (Gold > 17000)
                        GoldBonus = 2.7f;
                    if (Gold > 18000)
                    {
                        GoldBonus = 2.8f;
                        if (Gold > 19000)
                            GoldBonus += 0.1f;
                    }
                    break;
                case 15:
                   
                    if (Gold < 1000)
                        Rareitydroprate = 0.01f;
                    if (Gold > 1000)
                        Rareitydroprate = 0.02f;
                    if (Gold > 2000)
                        Rareitydroprate = 0.03f;
                    if (Gold > 3000)
                        Rareitydroprate = 0.04f;
                    if (Gold > 4000)
                        Rareitydroprate = 0.05f;
                    if (Gold > 5000)
                        Rareitydroprate = 0.06f;
                    if (Gold > 6000)
                        Rareitydroprate = 0.07f;
                    if (Gold > 7000)
                        Rareitydroprate = 0.08f;
                    if (Gold > 8000)
                        Rareitydroprate = 0.09f;
                    if (Gold > 9000)
                        Rareitydroprate = 0.10f;
                    if (Gold > 10000)
                        Rareitydroprate = 0.11f;
                    if (Gold > 11000)
                        Rareitydroprate = 0.12f;
                    if (Gold > 12000)
                       Rareitydroprate = 0.13f;
                    if (Gold > 13000)
                        Rareitydroprate = 0.14f;
                    if (Gold > 14000)
                        Rareitydroprate = 0.15f;
                    if (Gold > 15000)
                       Rareitydroprate = 0.16f;
                    if (Gold > 16000)
                       Rareitydroprate = 0.17f;
                    if (Gold > 17000)
                        Rareitydroprate = 0.18f;
                    if (Gold > 18000)
                    {
                        Rareitydroprate = 0.19f;
                        if (Gold > 19000)
                            Rareitydroprate += 0.1f;
                    }
                    break;
                case 16:
                    
                    if (Gold < 1000)
                        EXPbonus = 0.01f;
                    if (Gold > 1000)
                        EXPbonus = 0.02f;
                    if (Gold > 2000)
                        EXPbonus = 0.03f;
                    if (Gold > 3000)
                        EXPbonus = 0.04f;
                    if (Gold > 4000)
                        EXPbonus = 0.05f;
                    if (Gold > 5000)
                        EXPbonus = 0.06f;
                    if (Gold > 6000)
                        EXPbonus = 0.07f;
                    if (Gold > 7000)
                        EXPbonus = 0.08f;
                    if (Gold > 8000)
                        EXPbonus = 0.09f;
                    if (Gold > 9000)
                        EXPbonus = 0.10f;
                    if (Gold > 10000)
                        EXPbonus = 0.11f;
                    if (Gold > 11000)
                        EXPbonus = 0.12f;
                    if (Gold > 12000)
                        EXPbonus = 0.13f;
                    if (Gold > 13000)
                        EXPbonus = 0.14f;
                    if (Gold > 14000)
                        EXPbonus = 0.15f;
                    if (Gold > 15000)
                        EXPbonus = 0.16f;
                    if (Gold > 16000)
                        EXPbonus = 0.17f;
                    if (Gold > 17000)
                        EXPbonus = 0.18f;
                    if (Gold > 18000)
                    {
                        EXPbonus = 0.19f;
                        if (Gold > 19000)
                           EXPbonus += 0.1f;
                    }
                    break;
                case 17:
                  
                    if (Gold < 1000)
                        HealthRegen = 10;
                    if (Gold > 1000)
                        HealthRegen = 20;
                    if (Gold > 2000)
                        HealthRegen = 30;
                    if (Gold > 3000)
                        HealthRegen = 40;
                    if (Gold > 4000)
                        HealthRegen = 50;
                    if (Gold > 5000)
                        HealthRegen = 60;
                    if (Gold > 6000)
                       HealthRegen = 70;
                    if (Gold > 7000)
                        HealthRegen = 80;
                    if (Gold > 8000)
                        HealthRegen = 90;
                    if (Gold > 9000)
                        HealthRegen = 100;
                    if (Gold > 10000)
                        HealthRegen = 110;
                    if (Gold > 11000)
                        HealthRegen = 120;
                    if (Gold > 12000)
                        HealthRegen = 130;
                    if (Gold > 13000)
                       HealthRegen = 140;
                    if (Gold > 14000)
                        HealthRegen = 150;
                    if (Gold > 15000)
                       HealthRegen = 160;
                    if (Gold > 16000)
                        HealthRegen = 170;
                    if (Gold > 17000)
                        HealthRegen = 180;
                    if (Gold > 18000)
                    {
                        HealthRegen = 190;
                        if (Gold > 19000)
                            HealthRegen += 10;
                    }
                    break;

            }
        }
    }

}
