using System.Collections.Generic;
using UnityEngine;

public class SaveInventoryRelic : MonoBehaviour
{
    public List<int> CollectedBeginnerID = new List<int>();
    public List<int> CollectedBattleHardenID = new List<int>();
    public List<int> CollectedExpertID = new List<int>();
    public List<string>BeginnerDescription = new List<string>();
    public List<string>BattlehardenDescription = new List<string>();
    public List<string>ExpertDescription = new List<string>();
    public Sprite icon;
    public List<string>Beginnertype=new List<string>();
    public List<string>Battlehardentype = new List<string>();
    public List<string>Experttype = new List<string>();

    // int that are floats for bigger numbers
    public List<float> BeginnerHPBonus=new List<float>();
    public List<float> BattleHardenHPBonus = new List<float>();
    public List<float> ExpertHPBonus = new List<float>();
    public List<float> BeginnerMovementSpeedBonus= new List<float>();
    public List<float> BattleHardenMovementSpeedBonus = new List<float>();
    public List<float> ExpertMovementSpeedBonus = new List<float>();
    public List<float> BeginnerDamage=new List<float>();
    public List<float> BattleHardenDamage = new List<float>();
    public List<float> ExpertDamage = new List<float>();
    public List<float> BeginnerBlockChanceBonus=new List<float>();
    public List<float> BattlehardenBlockChanceBonus = new List<float>();
    public List<float> ExpertBlockChanceBonus = new List<float>();
    public List<float> BeginnerMultiAttackBonus=new List<float>();
    public List<float> BattlehardenMultiAttackBonus = new List<float>();
    public List<float> ExpertMultiAttackBonus = new List<float>();
    public List<float> BeginnerAbilityDamage=new List<float>();
    public List<float> BattlehardenAbilityDamage = new List<float>();
    public List<float> ExpertAbilityDamage = new List<float>();
    public List<float> BeginnerArmourStats=new List<float>();
    public List<float> BattleHardenArmourStats = new List<float>();
    public List<float> ExpertArmourStats = new List<float>();
    //percentage
    public List<float>BeginnerStunChanceBonus =new List<float>();
    public List<float> BattlehardenStunChanceBonus = new List<float>();
    public List<float> ExpertStunChanceBonus = new List<float>();
    public List<float> BeginnerDodgeBonus=new List<float>();
    public List<float> BattlehardenDodgeBonus = new List<float>();
    public List<float> ExpertDodgeBonus = new List<float>();
    public List<float> BeginnerCritDamageBonus =new List<float>();
    public List<float> BattlehardenCritDamageBonus = new List<float>();
    public List<float> ExpertCritDamageBonus = new List<float>();
    public List<float>BeginnerStaminaRegenBonus= new List<float>();
    public List<float>BattlehardenStaminaRegenBonus = new List<float>();
    public List<float>ExpertStaminaRegenBonus = new List<float>();
    public List<float>BeginnerCooldownReduction = new List<float>();
    public List<float>BattlehardenCooldownReduction = new List<float>();
    public List<float>ExpertCooldownReduction = new List<float>();
    public List<float>BeginnerAOEchanceBonus = new List<float>();
    public List<float>BattlehardenAOEchanceBonus = new List<float>();
    public List<float>ExpertAOEchanceBonus = new List<float>();
    public List<float>BeginnerCritChance = new List<float>();
    public List<float>BattlehardenCritChance = new List<float>();
    public List<float>ExpertCritChance = new List<float>();
    public List<float>BeginnerGoldBonus = new List<float>();
    public List<float>BattlehardenGoldBonus = new List<float>();
    public List<float>ExpertGoldBonus = new List<float>();
    public List<float>BeginnerRareitydroprate= new List<float>();
    public List<float>BattlehardenRareitydroprate = new List<float>();
    public List<float>ExpertRareitydroprate = new List<float>();
    public List<float>BeginnerEXPbonus=new List<float>();
    public List<float>BattlehardenEXPbonus = new List<float>();
    public List<float>ExpertEXPbonus = new List<float>();
    public List<float>BeginnerHealthRegen=new List<float>();
    public List<float>BattlehardenHealthRegen = new List<float>();
    public List<float>ExpertHealthRegen = new List<float>();

    public GameObject BlankRelic;

    public void FillRelicLists()
    {
        List<RelicItem> CollectedRelics = GameObject.Find("PlayerData").GetComponent<RelicInventory>().CollectedRelics;

        foreach(RelicItem relic in CollectedRelics)
        {
            switch (relic.Relic)
            {
                case "Beginner":
                    CollectedBeginnerID.Add(relic.ID);
                    BeginnerHPBonus.Add(relic.HPBonus);
                    BeginnerMovementSpeedBonus.Add(relic.MovementSpeedBonus);
                    BeginnerDamage.Add(relic.Damage);
                    BeginnerBlockChanceBonus.Add(relic.BlockChanceBonus);
                    BeginnerMultiAttackBonus.Add(relic.MultiAttackBonus);
                    BeginnerAbilityDamage.Add(relic.AbilityDamage);
                    BeginnerArmourStats.Add(relic.ArmourStats);
                    BeginnerStunChanceBonus.Add(relic.StunChanceBonus);
                    BeginnerDodgeBonus.Add(relic.DodgeBonus);
                    BeginnerCritDamageBonus.Add(relic.CritDamageBonus);
                    BeginnerStaminaRegenBonus.Add(relic.StaminaRegenBonus);
                    BeginnerCooldownReduction.Add(relic.CooldownReduction);
                    BeginnerAOEchanceBonus.Add(relic.AOEchanceBonus);
                    BeginnerCritChance.Add(relic.CritChance);
                    BeginnerGoldBonus.Add(relic.GoldBonus);
                    BeginnerRareitydroprate.Add(relic.Rareitydroprate);
                    BeginnerEXPbonus.Add(relic.EXPbonus);
                    BeginnerHealthRegen.Add(relic.HealthRegen);
                    BeginnerDescription.Add(relic.description);
                    Beginnertype.Add (relic.Relic);
                    
                    break;
                case "BattleHarden":
                    CollectedBattleHardenID.Add(relic.ID);
                    BattleHardenHPBonus.Add(relic.HPBonus);
                    BattleHardenMovementSpeedBonus.Add(relic.MovementSpeedBonus);
                    BattleHardenDamage.Add(relic.Damage);
                    BattlehardenBlockChanceBonus.Add(relic.BlockChanceBonus);
                    BattlehardenMultiAttackBonus.Add(relic.MultiAttackBonus);
                    BattlehardenAbilityDamage.Add(relic.AbilityDamage);
                    BattleHardenArmourStats.Add(relic.ArmourStats);
                    BattlehardenStunChanceBonus.Add(relic.StunChanceBonus);
                    BattlehardenDodgeBonus.Add(relic.DodgeBonus);
                    BattlehardenCritDamageBonus.Add(relic.CritDamageBonus);
                    BattlehardenStaminaRegenBonus.Add(relic.StaminaRegenBonus);
                    BattlehardenCooldownReduction.Add(relic.CooldownReduction);
                    BattlehardenAOEchanceBonus.Add(relic.AOEchanceBonus);
                    BattlehardenCritChance.Add(relic.CritChance);
                    BattlehardenGoldBonus.Add(relic.GoldBonus);
                    BattlehardenRareitydroprate.Add(relic.Rareitydroprate);
                    BattlehardenEXPbonus.Add(relic.EXPbonus);
                    BattlehardenHealthRegen.Add(relic.HealthRegen);
                    BattlehardenDescription.Add(relic.description);
                    Battlehardentype.Add(relic.Relic);
                    break;
                case "Expert":
                    CollectedExpertID.Add(relic.ID);
                    ExpertHPBonus.Add(relic.HPBonus);
                    ExpertMovementSpeedBonus.Add(relic.MovementSpeedBonus);
                    ExpertDamage.Add(relic.Damage);
                    ExpertBlockChanceBonus.Add(relic.BlockChanceBonus);
                    ExpertMultiAttackBonus.Add(relic.MultiAttackBonus);
                    ExpertAbilityDamage.Add(relic.AbilityDamage);
                    ExpertArmourStats.Add(relic.ArmourStats);
                    ExpertStunChanceBonus.Add(relic.StunChanceBonus);
                    ExpertDodgeBonus.Add(relic.DodgeBonus);
                    ExpertCritDamageBonus.Add(relic.CritDamageBonus);
                    ExpertStaminaRegenBonus.Add(relic.StaminaRegenBonus);
                    ExpertCooldownReduction.Add(relic.CooldownReduction);
                    ExpertAOEchanceBonus.Add(relic.AOEchanceBonus);
                    ExpertCritChance.Add(relic.CritChance);
                    ExpertGoldBonus.Add(relic.GoldBonus);
                    ExpertRareitydroprate.Add(relic.Rareitydroprate);
                    ExpertEXPbonus.Add(relic.EXPbonus);
                    ExpertHealthRegen.Add(relic.HealthRegen);
                    ExpertDescription.Add(relic.description);
                    Experttype.Add(relic.Relic);
                    break;
            }
        }

        CollectedBeginnerID.Clear();
        CollectedBattleHardenID.Clear();
        CollectedExpertID.Clear();
        //cleans out the Beginner relics to not duplicate items
        BeginnerDamage.Clear();
        BeginnerHPBonus.Clear();
        BeginnerMovementSpeedBonus.Clear();
        BeginnerBlockChanceBonus.Clear();
        BeginnerMultiAttackBonus.Clear();
        BeginnerAbilityDamage.Clear();
        BeginnerArmourStats.Clear();
        BeginnerStunChanceBonus.Clear();
        BeginnerDodgeBonus.Clear();
        BeginnerCritDamageBonus.Clear();
        BeginnerStaminaRegenBonus.Clear();
        BeginnerCooldownReduction.Clear();
        BeginnerAOEchanceBonus.Clear();
        BeginnerCritChance.Clear();
        BeginnerGoldBonus.Clear();
        BeginnerRareitydroprate.Clear();
        BeginnerEXPbonus.Clear();
        BeginnerHealthRegen.Clear();
        BeginnerDescription.Clear();
        Beginnertype.Clear();

        BattleHardenHPBonus.Clear();
        BattleHardenMovementSpeedBonus.Clear();
        BattleHardenDamage.Clear();
        BattlehardenBlockChanceBonus.Clear();
        BattlehardenMultiAttackBonus.Clear();
        BattlehardenAbilityDamage.Clear();
        BattleHardenArmourStats.Clear();
        BattlehardenStunChanceBonus.Clear();
        BattlehardenDodgeBonus.Clear();
        BattlehardenCritDamageBonus.Clear();
        BattlehardenStaminaRegenBonus.Clear();
        BattlehardenCooldownReduction.Clear();
        BattlehardenAOEchanceBonus.Clear();
        BattlehardenCritChance.Clear();
        BattlehardenGoldBonus.Clear();
        BattlehardenRareitydroprate.Clear();
        BattlehardenEXPbonus.Clear();
        BattlehardenHealthRegen.Clear();
        BattlehardenDescription.Clear();
        Battlehardentype.Clear();

        ExpertHPBonus.Clear();
        ExpertMovementSpeedBonus.Clear();
        ExpertDamage.Clear();
        ExpertBlockChanceBonus.Clear();
        ExpertMultiAttackBonus.Clear();
        ExpertAbilityDamage.Clear();
        ExpertArmourStats.Clear();
        ExpertStunChanceBonus.Clear();
        ExpertDodgeBonus.Clear();
        ExpertCritDamageBonus.Clear();
        ExpertStaminaRegenBonus.Clear();
        ExpertCooldownReduction.Clear();
        ExpertAOEchanceBonus.Clear();
        ExpertCritChance.Clear();
        ExpertGoldBonus.Clear();
        ExpertRareitydroprate.Clear();
        ExpertEXPbonus.Clear();
        ExpertHealthRegen.Clear();
        ExpertDescription.Clear();
        Experttype.Clear();

    }


    public void LoadRelicInventory()
    {
        SaveSystem data = SaveBinaryInventoryRelic.LoadRelicInventory();
        CollectedBeginnerID = data.BeginnerColltecID;
        CollectedBattleHardenID = data.BattlehardenCollectedID;
        CollectedExpertID = data.ExpertCollectedID;

        BeginnerHPBonus = data.BeginnerHPBonus;
        BattleHardenHPBonus = data.BattleHardenHPBonus;
        ExpertHPBonus = data.ExpertHPBonus;

        BeginnerMovementSpeedBonus = data.BeginnerMovementSpeedBonus;
        BattleHardenMovementSpeedBonus = data.BattleHardenMovementSpeedBonus;
        ExpertMovementSpeedBonus = data.ExpertMovementSpeedBonus;

        BeginnerDamage = data.BeginnerDamage;
        BattleHardenDamage = data.BattleHardenDamage;
        ExpertDamage = data.ExpertDamage;

        BeginnerBlockChanceBonus = data.BeginnerBlockChanceBonus;
        BattlehardenBlockChanceBonus = data.BattlehardenBlockChanceBonus;
        ExpertBlockChanceBonus = data.ExpertBlockChanceBonus;

        BeginnerMultiAttackBonus = data.BeginnerMultiAttackBonus;
        BattlehardenMultiAttackBonus = data.BattlehardenMultiAttackBonus;
        ExpertMultiAttackBonus = data.ExpertMultiAttackBonus;

        BeginnerAbilityDamage = data.BeginnerAbilityDamage;
        BattlehardenAbilityDamage = data.BattlehardenAbilityDamage;
        ExpertAbilityDamage = data.ExpertAbilityDamage;

        BeginnerArmourStats = data.BeginnerArmourStats;
        BattleHardenArmourStats = data.BattleHardenArmourStats;
        ExpertArmourStats = data.ExpertArmourStats;

        BeginnerStunChanceBonus = data.BeginnerStunChanceBonus;
        BattlehardenStunChanceBonus = data.BattlehardenStunChanceBonus;
        ExpertStunChanceBonus = data.ExpertStunChanceBonus;

        BeginnerDodgeBonus = data.BeginnerDodgeBonus;
        BattlehardenDodgeBonus = data.BattlehardenDodgeBonus;
        ExpertDodgeBonus = data.ExpertDodgeBonus;

        BeginnerCritDamageBonus = data.BeginnerCritDamageBonus;
        BattlehardenCritDamageBonus = data.BattlehardenCritDamageBonus;
        ExpertCritDamageBonus = data.ExpertCritDamageBonus;

        BeginnerStaminaRegenBonus = data.BeginnerStaminaRegenBonus;
        BattlehardenStaminaRegenBonus = data.BattlehardenStaminaRegenBonus;
        ExpertStaminaRegenBonus = data.ExpertStaminaRegenBonus;

        BeginnerCooldownReduction = data.BeginnerCooldownReduction;
        BattlehardenCooldownReduction = data.BattlehardenCooldownReduction;
        ExpertCooldownReduction = data.ExpertCooldownReduction;

        BeginnerAOEchanceBonus = data.BeginnerAOEchanceBonus;
        BattlehardenAOEchanceBonus = data.BattlehardenAOEchanceBonus;
        ExpertAOEchanceBonus = data.ExpertAOEchanceBonus;

        BeginnerCritChance = data.BeginnerCritChance;
        BattlehardenCritChance = data.BattlehardenCritChance;
        ExpertCritChance = data.ExpertCritChance;

        BeginnerGoldBonus = data.BeginnerGoldBonus;
        BattlehardenGoldBonus = data.BattlehardenGoldBonus;
        ExpertGoldBonus = data.ExpertGoldBonus;

        BeginnerRareitydroprate = data.BeginnerRareitydroprate;
        BattlehardenRareitydroprate = data.BattlehardenRareitydroprate;
        ExpertRareitydroprate = data.ExpertRareitydroprate;

        BeginnerEXPbonus = data.BeginnerEXPbonus;
        BattlehardenEXPbonus = data.BattlehardenEXPbonus;
        ExpertEXPbonus = data.ExpertEXPbonus;

        BeginnerHealthRegen = data.BeginnerHealthRegen;
        BattlehardenHealthRegen = data.BattlehardenHealthRegen;
        ExpertHealthRegen = data.ExpertHealthRegen;

        BeginnerDescription = data.BeginnerDescription;
        BattlehardenDescription = data.BattlehardenDescription;
        ExpertDescription = data.ExpertDescription;

        Beginnertype = data.Beginnertype;
        Battlehardentype = data.Battlehardentype;
        Experttype = data.Experttype;

        if (CollectedBeginnerID != null)
        {
            Relic[] AllBeginnerRelic = Resources.FindObjectsOfTypeAll<Relic>();
            for(int i = 0; i < CollectedBeginnerID.Count; i++)
            {
                int AllBeginnerID = CollectedBeginnerID[i];
                foreach(Relic BeginnerRelic in AllBeginnerRelic)
                {
                    if (BeginnerRelic.ID == AllBeginnerID)
                    {
                        Relic RelicItem = BeginnerRelic;
                        GameObject RelicBeginner = Instantiate(BlankRelic, new Vector3(0, 0, 0), Quaternion.identity);
                        RelicBeginner.GetComponent<RelicItem>().Data = RelicItem;
                        RelicBeginner.GetComponent<RelicItem>().description = BeginnerDescription[i];
                        RelicBeginner.GetComponent<RelicItem>().type = Beginnertype[i];
                        RelicBeginner.GetComponent<RelicItem>().HPBonus = BeginnerHPBonus[i];
                        RelicBeginner.GetComponent<RelicItem>().MovementSpeedBonus = BeginnerMovementSpeedBonus[i];
                        RelicBeginner.GetComponent<RelicItem>().Damage = BeginnerDamage[i];
                        RelicBeginner.GetComponent<RelicItem>().BlockChanceBonus = BeginnerBlockChanceBonus[i];
                        RelicBeginner.GetComponent<RelicItem>().MultiAttackBonus = BeginnerMultiAttackBonus[i];
                        RelicBeginner.GetComponent<RelicItem>().AbilityDamage = BeginnerAbilityDamage[i];
                        RelicBeginner.GetComponent<RelicItem>().ArmourStats = BeginnerArmourStats[i];
                        RelicBeginner.GetComponent<RelicItem>().StunChanceBonus = BeginnerStunChanceBonus[i];
                        RelicBeginner.GetComponent<RelicItem>().DodgeBonus = BeginnerDodgeBonus[i];
                        RelicBeginner.GetComponent<RelicItem>().CritDamageBonus = BeginnerCritDamageBonus[i];
                        RelicBeginner.GetComponent<RelicItem>().StaminaRegenBonus = BeginnerStaminaRegenBonus[i];
                        RelicBeginner.GetComponent<RelicItem>().CooldownReduction = BeginnerCooldownReduction[i];
                        RelicBeginner.GetComponent<RelicItem>().AOEchanceBonus = BeginnerAOEchanceBonus[i];
                        RelicBeginner.GetComponent<RelicItem>().CritChance = BeginnerCritChance[i];
                        RelicBeginner.GetComponent<RelicItem>().GoldBonus = BeginnerGoldBonus[i];
                        RelicBeginner.GetComponent<RelicItem>().Rareitydroprate = BeginnerRareitydroprate[i];
                        RelicBeginner.GetComponent<RelicItem>().EXPbonus = BeginnerEXPbonus[i];
                        RelicBeginner.GetComponent<RelicItem>().HealthRegen = BeginnerHealthRegen[i];

                        RelicBeginner.GetComponent<RelicItem>().FromSaveFile = true;



                    }
                }
            }

        }
        if (CollectedBattleHardenID != null)
        {
            Relic[] AllBattlehardenRelic = Resources.FindObjectsOfTypeAll<Relic>();
            for(int i = 0; i < CollectedBattleHardenID.Count; i++)
            {
                int AllBattleHardenID = CollectedBattleHardenID[i];
                foreach(Relic BattlehardenRelic in AllBattlehardenRelic)
                {
                    if (BattlehardenRelic.ID == AllBattleHardenID)
                    {
                        Relic RelicItem = BattlehardenRelic;
                        GameObject RelicBattleharden = Instantiate(BlankRelic, new Vector3(0, 0, 0), Quaternion.identity);
                        RelicBattleharden.GetComponent<RelicItem>().Data = RelicItem;
                        RelicBattleharden.GetComponent<RelicItem>().description = BattlehardenDescription[i];
                        RelicBattleharden.GetComponent<RelicItem>().type = Battlehardentype[i];
                        RelicBattleharden.GetComponent<RelicItem>().HPBonus = BattleHardenHPBonus[i];
                        RelicBattleharden.GetComponent<RelicItem>().MovementSpeedBonus = BattleHardenMovementSpeedBonus[i];
                        RelicBattleharden.GetComponent<RelicItem>().Damage = BattleHardenDamage[i];
                        RelicBattleharden.GetComponent<RelicItem>().BlockChanceBonus = BattlehardenBlockChanceBonus[i];
                        RelicBattleharden.GetComponent<RelicItem>().MultiAttackBonus = BattlehardenMultiAttackBonus[i];
                        RelicBattleharden.GetComponent<RelicItem>().AbilityDamage = BattlehardenAbilityDamage[i];
                        RelicBattleharden.GetComponent<RelicItem>().ArmourStats = BattleHardenArmourStats[i];
                        RelicBattleharden.GetComponent<RelicItem>().StunChanceBonus = BattlehardenStunChanceBonus[i];
                        RelicBattleharden.GetComponent<RelicItem>().DodgeBonus = BattlehardenDodgeBonus[i];
                        RelicBattleharden.GetComponent<RelicItem>().CritDamageBonus = BattlehardenCritDamageBonus[i];
                        RelicBattleharden.GetComponent<RelicItem>().StaminaRegenBonus = BattlehardenStaminaRegenBonus[i];
                        RelicBattleharden.GetComponent<RelicItem>().CooldownReduction = BattlehardenCooldownReduction[i];
                        RelicBattleharden.GetComponent<RelicItem>().AOEchanceBonus = BattlehardenAOEchanceBonus[i];
                        RelicBattleharden.GetComponent<RelicItem>().CritChance = BattlehardenCritChance[i];
                        RelicBattleharden.GetComponent<RelicItem>().GoldBonus = BattlehardenGoldBonus[i];
                        RelicBattleharden.GetComponent<RelicItem>().Rareitydroprate = BattlehardenRareitydroprate[i];
                        RelicBattleharden.GetComponent<RelicItem>().EXPbonus = BattlehardenEXPbonus[i];
                        RelicBattleharden.GetComponent<RelicItem>().HealthRegen = BattlehardenHealthRegen[i];

                        RelicBattleharden.GetComponent<RelicItem>().FromSaveFile = true;
                    }
                }

            }

        }
        if (CollectedExpertID != null)
        {
            Relic[] AllExpertRelic = Resources.FindObjectsOfTypeAll<Relic>();
            for(int i = 0; i < CollectedExpertID.Count; i++)
            {
                int AllExpertID=CollectedExpertID[i];
                foreach(Relic ExpertRelic in AllExpertRelic)
                {
                    Relic RelicItem = ExpertRelic;
                    GameObject RelicExpert = Instantiate(BlankRelic, new Vector3(0, 0, 0), Quaternion.identity);
                    RelicExpert.GetComponent<RelicItem>().Data = RelicItem;
                    RelicExpert.GetComponent<RelicItem>().description = ExpertDescription[i];
                    RelicExpert.GetComponent<RelicItem>().type = Experttype[i];
                    RelicExpert.GetComponent<RelicItem>().HPBonus = ExpertHPBonus[i];
                    RelicExpert.GetComponent<RelicItem>().MovementSpeedBonus = ExpertMovementSpeedBonus[i];
                    RelicExpert.GetComponent<RelicItem>().Damage = ExpertDamage[i];
                    RelicExpert.GetComponent<RelicItem>().BlockChanceBonus = ExpertBlockChanceBonus[i];
                    RelicExpert.GetComponent<RelicItem>().MultiAttackBonus = ExpertMultiAttackBonus[i];
                    RelicExpert.GetComponent<RelicItem>().AbilityDamage = ExpertAbilityDamage[i];
                    RelicExpert.GetComponent<RelicItem>().ArmourStats = ExpertArmourStats[i];
                    RelicExpert.GetComponent<RelicItem>().StunChanceBonus = ExpertStunChanceBonus[i];
                    RelicExpert.GetComponent<RelicItem>().DodgeBonus = ExpertDodgeBonus[i];
                    RelicExpert.GetComponent<RelicItem>().CritDamageBonus = ExpertCritDamageBonus[i];
                    RelicExpert.GetComponent<RelicItem>().StaminaRegenBonus = ExpertStaminaRegenBonus[i];
                    RelicExpert.GetComponent<RelicItem>().CooldownReduction = ExpertCooldownReduction[i];
                    RelicExpert.GetComponent<RelicItem>().AOEchanceBonus = ExpertAOEchanceBonus[i];
                    RelicExpert.GetComponent<RelicItem>().CritChance = ExpertCritChance[i];
                    RelicExpert.GetComponent<RelicItem>().GoldBonus = ExpertGoldBonus[i];
                    RelicExpert.GetComponent<RelicItem>().Rareitydroprate = ExpertRareitydroprate[i];
                    RelicExpert.GetComponent<RelicItem>().EXPbonus = ExpertEXPbonus[i];
                    RelicExpert.GetComponent<RelicItem>().HealthRegen = ExpertHealthRegen[i];

                    RelicExpert.GetComponent<RelicItem>().FromSaveFile = true;

                }
            }
        }

        BeginnerDamage.Clear();
        BeginnerHPBonus.Clear();
        BeginnerMovementSpeedBonus.Clear();
        BeginnerBlockChanceBonus.Clear();
        BeginnerMultiAttackBonus.Clear();
        BeginnerAbilityDamage.Clear();
        BeginnerArmourStats.Clear();
        BeginnerStunChanceBonus.Clear();
        BeginnerDodgeBonus.Clear();
        BeginnerCritDamageBonus.Clear();
        BeginnerStaminaRegenBonus.Clear();
        BeginnerCooldownReduction.Clear();
        BeginnerAOEchanceBonus.Clear();
        BeginnerCritChance.Clear();
        BeginnerGoldBonus.Clear();
        BeginnerRareitydroprate.Clear();
        BeginnerEXPbonus.Clear();
        BeginnerHealthRegen.Clear();
        BeginnerDescription.Clear();
        Beginnertype.Clear();

        BattleHardenHPBonus.Clear();
        BattleHardenMovementSpeedBonus.Clear();
        BattleHardenDamage.Clear();
        BattlehardenBlockChanceBonus.Clear();
        BattlehardenMultiAttackBonus.Clear();
        BattlehardenAbilityDamage.Clear();
        BattleHardenArmourStats.Clear();
        BattlehardenStunChanceBonus.Clear();
        BattlehardenDodgeBonus.Clear();
        BattlehardenCritDamageBonus.Clear();
        BattlehardenStaminaRegenBonus.Clear();
        BattlehardenCooldownReduction.Clear();
        BattlehardenAOEchanceBonus.Clear();
        BattlehardenCritChance.Clear();
        BattlehardenGoldBonus.Clear();
        BattlehardenRareitydroprate.Clear();
        BattlehardenEXPbonus.Clear();
        BattlehardenHealthRegen.Clear();
        BattlehardenDescription.Clear();
        Battlehardentype.Clear();

        ExpertHPBonus.Clear();
        ExpertMovementSpeedBonus.Clear();
        ExpertDamage.Clear();
        ExpertBlockChanceBonus.Clear();
        ExpertMultiAttackBonus.Clear();
        ExpertAbilityDamage.Clear();
        ExpertArmourStats.Clear();
        ExpertStunChanceBonus.Clear();
        ExpertDodgeBonus.Clear();
        ExpertCritDamageBonus.Clear();
        ExpertStaminaRegenBonus.Clear();
        ExpertCooldownReduction.Clear();
        ExpertAOEchanceBonus.Clear();
        ExpertCritChance.Clear();
        ExpertGoldBonus.Clear();
        ExpertRareitydroprate.Clear();
        ExpertEXPbonus.Clear();
        ExpertHealthRegen.Clear();
        ExpertDescription.Clear();
        Experttype.Clear();


    }
}
