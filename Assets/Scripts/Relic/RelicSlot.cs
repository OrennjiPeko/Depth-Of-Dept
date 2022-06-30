using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RelicSlot : MonoBehaviour,IPointerClickHandler
{
    public RelicItem relic;
    public Transform RelicCopy;
    [HideInInspector] public int ID;
    [HideInInspector] public string type;
    [HideInInspector] public string description;
    [HideInInspector] public bool empty;
    [HideInInspector] public Sprite icon;
    [HideInInspector] public Transform RelicIconGo;

    private RelicInventory relicInventory;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(relic.Relic == "Beginner")
        {
            if (relicInventory.RelicBeginnerEquippedcheck == false)
            {
                useRelic();
                relicInventory.RelicBeginnerEquippedcheck = true;
                relicInventory.RelicBeginnerEquipped = null;
            }
        }

        if(relic.Relic== "BattleHarden")
        {
            if (relicInventory.RelicBattleHardenEquippedcheck == false)
            {
                useRelic();
                relicInventory.RelicBattleHardenEquippedcheck = true;
                relicInventory.RelicBattleHardenEquipped = null;
            }
        }

        if (relic.Relic == "Expert")
        {
            if (relicInventory.RelicExpertEquippedcheck == false)
            {
                useRelic();
                relicInventory.RelicExpertEquippedcheck = true;
                relicInventory.RelicExpertEquipped = null;
            }
        }
    }

   

    // Start is called before the first frame update
   private void Start()
    {
        RelicIconGo = transform.GetChild(0);
        RelicCopy = transform.GetChild(1);
        relicInventory = GameObject.Find("PlayerData").GetComponent<RelicInventory>();

    }

    public void UpdateRelicslot()
    {
        RelicIconGo.GetComponent<Image>().sprite = icon;
    }

    public void useRelic()
    {
        relic.Relicusage();
    }
    
    public void RemoveRelic()
    {
        relic.RemoveRelic();
    }

    public void CreateCopyRelic()
    {
        RelicCopy.GetComponent<RelicItem>().ID = relic.ID;
        RelicCopy.GetComponent<RelicItem>().Damage = relic.Damage;
        RelicCopy.GetComponent<RelicItem>().Relic = relic.Relic;
        RelicCopy.GetComponent<RelicItem>().description = relic.description;
        RelicCopy.GetComponent<RelicItem>().HPBonus = relic.HPBonus;
        RelicCopy.GetComponent<RelicItem>().MovementSpeedBonus = relic.MovementSpeedBonus;
        RelicCopy.GetComponent<RelicItem>().icon = relic.icon;
        RelicCopy.GetComponent<RelicItem>().BlockChanceBonus = relic.BlockChanceBonus;
        RelicCopy.GetComponent<RelicItem>().MultiAttackBonus = relic.MultiAttackBonus;
        RelicCopy.GetComponent<RelicItem>().AbilityDamage = relic.AbilityDamage;
        RelicCopy.GetComponent<RelicItem>().ArmourStats = relic.ArmourStats;
        RelicCopy.GetComponent<RelicItem>().StunChanceBonus = relic.StunChanceBonus;
        RelicCopy.GetComponent<RelicItem>().DodgeBonus = relic.DodgeBonus;
        RelicCopy.GetComponent<RelicItem>().CritDamageBonus = relic.CritDamageBonus;
        RelicCopy.GetComponent<RelicItem>().StaminaRegenBonus = relic.StaminaRegenBonus;
        RelicCopy.GetComponent<RelicItem>().CooldownReduction = relic.CooldownReduction;
        RelicCopy.GetComponent<RelicItem>().AOEchanceBonus = relic.AOEchanceBonus;
        RelicCopy.GetComponent<RelicItem>().CritChance = relic.CritChance;
        RelicCopy.GetComponent<RelicItem>().GoldBonus = relic.GoldBonus;
        RelicCopy.GetComponent<RelicItem>().Rareitydroprate = relic.Rareitydroprate;
        RelicCopy.GetComponent<RelicItem>().EXPbonus = relic.EXPbonus;
        RelicCopy.GetComponent<RelicItem>().HealthRegen = relic.HealthRegen;
    }
    
    public void DeleteRelic()
    {
        ID = 0;
        type = null;
        description = null;
        empty = true;
        icon = null;
        if (relic.Equipped)
        {
            relic.RemoveRelic();
        }

        UpdateRelicslot();
        GameObject.Find("PlayerData").GetComponent<RelicInventory>().CollectedRelics.Remove(relic);
        relic.ID = 0;
        relic.Damage = 0;
        relic.Relic = null;
        relic.description = null;
        relic.icon = null;
        relic.Data = null;
        relic.HPBonus = 0;
        relic.BlockChanceBonus = 0;
        relic.StaminaRegenBonus = 0;
        relic.AbilityDamage = 0;
        relic.HealthRegen = 0;
        relic.Rareitydroprate = 0;
        relic.AOEchanceBonus = 0;
        relic.ArmourStats = 0;
        relic.CooldownReduction = 0;
        relic.CritChance = 0;
        relic.CritDamageBonus = 0;
        relic.DodgeBonus = 0;
        relic.EXPbonus = 0;
        relic.StunChanceBonus = 0;
        relic.MovementSpeedBonus = 0;
        relic.MultiAttackBonus = 0;
        relic.GoldBonus = 0;
      


    }
}
