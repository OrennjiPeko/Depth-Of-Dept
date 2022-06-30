using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    // used to pull the player prefab to be used for the spawn point that uses vector 3
    public GameObject Player;
    public Vector3 spawn;

    void Start ()
    {
        // Go used to spawn the player at the spawn location
        GameObject go= Instantiate(Player,spawn, Quaternion.identity);
        // changes the go name from clone player to player name to stop errors with searching for the player name 
        go.name = Player.name;

        // finds the Global Data and checks if the bool set as false and invoke the PlayerNotFound to get the Data from chooseskills
        if (GameObject.Find("GlobalData").GetComponent<ChooseSkills>().PlayerIsFound == false)
        {
            GameObject.Find("GlobalData").GetComponent<ChooseSkills>().Invoke("PlayerNotFound",0);
        }
        // finds the player data and check if the bool set as false, then update from NoPlayerFound
        if (GameObject.Find("PlayerData").GetComponent<PlayerData>().NoPlayer == false)
        {
            GameObject.Find("PlayerData").GetComponent<PlayerData>().NoPlayerFound();

        }
        // finds Player Data and check if No Floor is set as false and updates the Floor Managerment 
        if (GameObject.Find("PlayerData").GetComponent<PlayerData>().NoFloor == false)
        {
            GameObject.Find("PlayerData").GetComponent<PlayerData>().NoFloorManagerment();
        }
        GameObject.Find("Canvas").GetComponent<ResetMechanics>().Floorcheck();
      
      

        //Reapplies the player's equipment buffs once the level has been loaded and all other stats have been reapplied
        Invoke("ReApply", 0.0001f);
    }

    void ReApply()
    {
        GameObject.Find("PlayerData").GetComponent<Inventory>().ReApplyBuffs();
    }

}
