using UnityEngine;
using UnityEngine.UI;

public class SkillsTooltipManager : MonoBehaviour
{
    public GameObject SkillTooltip;
    public Text SkillToolText;
    

    public void Start()
    {
        SkillTooltip = GameObject.Find("SkillToolTip");
        SkillToolText = SkillTooltip.GetComponentInChildren<Text>();
        SkillTooltip.SetActive(false);
        
    }

    //Almost all below functions make the tooltip visable and change the text of the tool tip to match the skill

    public void ShowRage(Vector3 position)
    {
      
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Rage \n Increase Damage Dealt for a \n period of time\n Cost is 1 skill point";
    }

    public void ShowHuntingInstinct(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Hunting Instinct \n Increase Critical Chance for a \n period of time \n Cost is 1 skill point";
    }

    public void ShowPresenceOfPain(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Presence Of Pain \n Small AOE attack\n Cost is 1 skill point";
    }
    public void ShowBreathOfLife(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Breath Of Life \n Heals a percentage of health \n Cost is 1 skill point";
    }

    public void ShowSurvivalInstinct(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Survival Instinct \n Increases dodge chance for a \n short amount of time \n Cost is 1 skill point";
    }
    public void ShowPetrifyingPresence(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Petrifying Presence \n Stops enemy movement and \n activates small AOE \n Cost is 1 skill point";
    }

    public void ShowSteelBody(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Steel Body \n Improves player's armour for \n a short time\n Cost is 1 skill point";
    }

    public void ShowBobAndWeave(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Bob And Weave \n Increases dodge chance\n Cost is 1 skill point";
    }

    public void ShowMageArmour(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = " Mage Armour stacking Armour when hit,stacking multiple \n times(up to 3-5 stacks)\n Cost is 1 skill point";
    }

    public void ShowBiggerArms(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Bigger Arms \n Increases damage\n Cost is 1 skill point";
    }

    public void ShowTargetPractice(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Target Practice \n Increases critical damage\n Cost is 1 skill point";
    }

    public void ShowForceOfWill(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Force Of Will \n Increase ability damage\n Cost is 1 skill point";
    }

    public void ShowThornSkin(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Thorn Skin \n Damage reflection chance\n Cost is 1 skill point";
    }

    public void ShowRiposte(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Riposte \n Block Chance increase\n Cost is 1 skill point";
    }

    public void ShowImprovedMemory(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Improved Memory \n Reduces Cooldown\n Cost is 1 skill point";
    }

    public void ShowCleave(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Cleave \n  AOE hit chance increased\n Cost is 1 skill point";
    }

    public void ShowMultipleHands(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Multiple Hands \n MultiAttack chance increase\n Cost is 1 skill point";
    }

    public void ShowQuickRecharge(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Quick Recharge \n Increase stamina recharge rate\n Cost is 1 skill point";
    }

    public void ShowStunningQuake(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Stunning Quake \n AOE stun and pull enemies closer\n Cost is 1 skill point";
    }

    public void ShowGhostlyTime(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Ghostly Time \n Hide from enemies for 5-10 seconds\n Cost is 1 skill point";
    }

    public void ShowConeOfTundra(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Cone Of Tundra \n Freeze enemies it hits\n Cost is 1 skill point";
    }

    public void ShowLimbHarvest(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Limb Harvest \n Increases damage with \n each kill while active\n Cost is 1 skill point";
    }

    public void ShowBurnBaby(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Burn Baby \n Fire based AOE with a chance of \n burning the enemy\n Cost is 1 skill point";
    }

    public void ShowConeOfUnlife(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Cone Of Unlife \n Damage enemies in a cone and if it \n kills the enemy it can be a minion\n Cost is 1 skill point";
    }

    public void ShowArtOfTraining(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Art Of Training \n Increases exp gain\n Cost is 1 skill point";
    }

    public void ShowPennies(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Pennies \n Increases gold gain\n Cost is 1 skill point";
    }

    public void ShowRollTheDice(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Roll The Dice \n Random spell comes of cooldown\n Cost is 1 skill point";
    }

    public void ShowFlurryOfAttacks(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Flurry Of Attacks \n Random chance of skill activating twice\n Cost is 1 skill point";
    }

    public void ShowTrainingThief(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Training Thief \n Steal item from the enemy\n Cost is 1 skill point";
    }

    public void ShowFrostbite(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Frostbite \n Chance of freezing enemy\n Cost is 1 skill point";
    }

    public void ShowReflectiveArmour(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Reflective Armour \n Chance to stun enemies when hit\n Cost is 1 skill point";
    }

    public void ShowBackAtYou(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Back At You \n Chance to counter enemy when hit\n Cost is 1 skill point";
    }

    public void ShowGateOfChaos(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Gates Of Chaos \n Can teleport to random location in the room\n Cost is 1 skill point";
    }

    public void ShowMassacre(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Massacre \n Chance to trigger effects twice\n Cost is 1 skill point";
    }

    public void ShowEcho(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Echo \n Chance to trigger spell twice\n Cost is 1 skill point";
    }

    public void ShowHeavyLanding(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Heavy Landing \n Chance to stun enemies when entering a floor\n Cost is 1 skill point";
    }

    public void ShowDisarmingPresence(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Disarming Presence \n Enemies drop weapon\n Cost is 1 skill point";
    }

    public void ShowShieldStorm(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Shield Storm \n Stuns enemy if attacked after 5 seconds of activation, \n no damage until skill deactivates\n Cost is 1 skill point";
    }

    public void ShowMirrorOfIce(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Mirror Of Ice \n Reflects 100% of damage\n Cost is 1 skill point";
    }

    public void ShowDeathGrip(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Death Grip \n Pulls enemies in front of you and \n restrains them while deal damage over time\n Cost is 1 skill point";
    }

    public void ShowBurstOfGore(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Burst Of Gore \n Deals massive damage to one target \n and if it kills activates large AOE attack\n Cost is 1 skill point";
    }

    public void ShowGiftGiver(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Gift Giver \n Minion will blow up, dealing \n massive damage but killing the minion\n Cost is 1 skill point";
    }

    public void ShowDiamondBody(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Diamond Body \n Increases block chance for 20 seconds\n Cost is 1 skill point";
    }

    public void ShowMasterOfPennies(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Master Of Pennies \n Increases gold gained by 20% for 60 seconds\n Cost is 1 skill point";
    }

    public void ShowSoulCollector(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Soul Collector \n Increases exp gain by 20% for 60 seconds\n Cost is 1 skill point";

    }

    public void ShowMoreGore(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "More Gore \n Chance to start dealing double damage \n when hit by an enemy\n Cost is 1 skill point";
    }

    public void ShowStealthCut(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Stealth Cut \n Chance to stun an enemy when performing this attack\n Cost is 1 skill point";
    }

    public void ShowFireWall(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Fire Wall \n Creates a fire wall around you which \n blocks all damage for a short time\n Cost is 1 skill point";
    }

    public void ShowWhyAreYouRunning(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Why Are You Running \n Chance to stun ranged enemies\n Cost is 1 skill point";
    }

    public void ShowFreeGoods(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Free Goods \n Increases chances to get better body armour pieces\n Cost is 1 skill point";
    }

    public void ShowBangWeapon(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Bang Weapon \n Increases chances to get better waeapons\n Cost is 1 skill point";
    }

    public void ShowImAngry(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "I'm Angry \n When you've lost 30% of your health multi-attack \n damage will increase by 20%\n Cost is 1 skill point";
    }

    public void ShowThrowThings(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Throw Thing \n A chance to throw items at \n enemies which also increases base damage\n Cost is 1 skill point";
    }

    public void ShowHumanShields(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Human Shield \n A chance to summon humans that act as a shield\n Cost is 1 skill point";
    }

    public void ShowBlindRage(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Blind Rage \n Increases damage output and reduce damage taken\n Cost is 1 skill point";
    }

    public void ShowImCalm(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "I'm Calm \n Increases dodge and critical hit chance\n Cost is 1 skill point";
    }

    public void ShowSoulEater(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Soul Eater \n Absorbs enemies health, \n damaging the enemy and healing yourself\n Cost is 1 skill point";
    }

    public void ShowRampage(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Rampage \n Large AOE attack that reduces in size\n Cost is 1 skill point";
    }

    public void ShowWallOfSpears(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Wall Of Spheres \n Large cone AOE that reduces in size\n Cost is 1 skill point";
    }

    public void ShowElementalOverload(Vector3 position)
    {
        SkillTooltip.SetActive(true);
        SkillTooltip.transform.position = new Vector3(position.x, position.y, position.z);
        SkillToolText.text = "Elemental Overload \n Casts random abilties every 5 seconds for 60 seconds\n Cost is 1 skill point";
    }








    //Hides the tool tip and removes the text
    public void Hide()
    {
        SkillTooltip.SetActive(false);
        SkillToolText.text = "";
        
    }




}