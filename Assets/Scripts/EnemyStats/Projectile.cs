using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    //Sets variables that will be needed for damage and speed of the bullet
    [HideInInspector] public float Damage;
    public float ProjectileImpulse;
    public float Armour;
    //Variable to check if the bullet has been reflected so it won't do damage to enemies before that
    bool IsReflected = false;
    //Stores the rigibody needed to change the movement of the projectile
    Rigidbody RB;
    public GameObject Player;

    private void Start()
    {
        //Sets the rigibody variable to store the rigibody on the projectile
        RB = this.gameObject.GetComponent<Rigidbody>();
        //Makes the bullet start mobing forward
        RB.AddForce(transform.forward * ProjectileImpulse, ForceMode.Impulse);
        //Projectile destroys itself if it hasn't collided with anything in 20 seconds
        Invoke("DestroyMe", 20);
        Player = GameObject.Find("Player");
        Armour = Player.GetComponent<PlayerStats>().armour;
    }

    public void Update()
    {
        if (Player.GetComponent<PlayerStats>().armour > 0)
        {
            Armour = Player.GetComponent<PlayerStats>().armour;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Stores the player in a variable to make it easier to access information
            GameObject Player = other.gameObject;
            //Checks if the player can reflect projectiles
            if(Player.GetComponent<PlayerCombat>().CanReflect == true)
            {
                //Sets the IsReflected boolean to true, making it do damage to enemies
                IsReflected = true;
                //Reverses the direcion the projectile was going in
                RB.AddForce((transform.forward * -2) * ProjectileImpulse, ForceMode.Impulse);
            }
            //Is the player can't reflect projectiles then the projectile will do damage
            else
            {
                Damage -= Armour;
                Damage= Mathf.Clamp(Damage, 0, int.MaxValue);
                //Lowers the player's health

                Player.GetComponent<PlayerStats>().Health -= Damage;
                //If the player's health reaches 0 then the game will head to a game over
                if (Player.GetComponent<PlayerStats>().Health <= 0)
                {
                    GameObject.Find("InGameUI").SetActive(false);
                    SceneManager.LoadScene("GameOver");
                }
                //Projectile destorys itself
                Destroy(this.gameObject);
            }
        }

        //If the projectile hits an enemy after being reflected
        if(other.gameObject.tag == "Enemy" && IsReflected == true)
        {
            //Stores the enemy in a variable to make it easter to access information
            GameObject Enemy = other.gameObject;
            //checks if the enemy is a ranged enemy or not to make sure it's accessing the correct script to lower health
            if(Enemy.GetComponent<EnemyAI>() == null)
            {
                //Lowers the enemy's health
                Enemy.GetComponent<RangedEnemyAI>().EnemyHealth -= Damage;
                //Projectile destroys itself
                Destroy(this.gameObject);
            }
            else
            {
                //Lowers the enemy's health
                Enemy.GetComponent<EnemyAI>().EnemyHealth -= Damage;
                //checks if the enemy's health is 0 or bellow
                if(Enemy.GetComponent<EnemyAI>().EnemyHealth <= 0)
                {
                    //Finds the player to start the death routine
                    GameObject Player = GameObject.Find("Player");
                    //Sets store the enemy with 0 health in the player's enemy variable which is used to delete it
                    Player.GetComponent<PlayerCombat>().DeadEnemy = Enemy;
                    //Tells the player to perform a death check which will delete the enemy, add experiance to the player, etc.
                    Player.GetComponent<PlayerCombat>().EnemyDeathCheck();
                }
                //Projectile destroys itself
                Destroy(this.gameObject);
            }
        }

        //If a reflected projectile hits a boss
        if(other.gameObject.tag == "Boss" && IsReflected)
        {
            //Stores the script that holds the bosses information
            Boss1 Boss = other.GetComponent<Boss1>();

            //Lowers the bosses health
            Boss.Health -= Damage;

            //Destroys the projectile
            Destroy(this.gameObject);
        }

        //Destroys the projectile if it touches a wall
        if (other.tag == "Wall")
            Destroy(this.gameObject);
    }

    //What do you think this does
    private void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}
