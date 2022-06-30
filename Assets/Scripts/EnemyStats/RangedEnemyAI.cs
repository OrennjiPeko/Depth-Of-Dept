using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemyAI : MonoBehaviour
{
    //Sets variables that will be needed throughout the script
    public float EnemyHealth;
    NavMeshAgent MoveToPlayer;
    Vector3 PlayerPos;
    //Burning variables
    [HideInInspector]public bool IsBurning;
    [HideInInspector]public int BurningDamage;
    [HideInInspector] public int BurningDuration;
    int BurningCheck;
    [HideInInspector] public bool IsStunned;
    [HideInInspector] public int StunDuration;
    [HideInInspector] public bool IsFrozen;
    [HideInInspector] public bool CanMove;
    [HideInInspector] public bool CanAttack;
    [HideInInspector] public int floor;
   [HideInInspector] public float Itemdroprate;

    //Sets variables used to calculate when the player should attack
    public float DistanceUntilAttack;
    float DistanceFromPlayer;
    bool IsAttacking;

    //Stores the projectile gameobject, the force in which it starts moving and the damage it'll do
    public Rigidbody Projectile;
    public float ProjectileImpulse;
    public float ProjectileDamage;

    //Variable to store player to make it simpler for the system to track the player
    public GameObject Player;
    //Prefabs for gold and items
    public GameObject GoldPrefab;
    public GameObject []Item;

    //Experiance the enemy will give when killed
    public int EXPGivenToPlayer;

    //Used for movement when enemy isn't in range
    private float Speed;
    private bool IsRight;
    private bool PlayerInRange;
    private bool NotStunned;

    bool PlayerNotFound;

    public GameObject[] DestinationPoints;
    private GameObject CurrentDestination;

    private float StoppingDistance;

    private void Awake()
    {
        CanMove = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        //finds the player and starts to chase after them
        Player = GameObject.Find("Player");
        PlayerPos = Player.transform.position;
        MoveToPlayer = GetComponent<NavMeshAgent>();
        Speed = MoveToPlayer.speed;
        PlayerInRange = false;
        IsBurning = false;
        BurningCheck = 0;
        IsFrozen = false;
        MoveToPlayer.stoppingDistance = DistanceUntilAttack;
        CanAttack = true;
        NotStunned = true;
        floor = GameObject.Find("FloorDisplay").GetComponent<FloorManagerment>().Floor;

        //Starts the attacking function straight away
        InvokeRepeating("Attacking", 0, 1);
        Item = Player.GetComponent<PlayerCombat>().Item;

        if(Player == null)
        {
            PlayerNotFound = true;
        }

        if (floor > 10)
        {
            StatsIncrease();
        }else if (floor > 201)
        {
            EnemyHealth += 15;
            ProjectileDamage += 15;
            EXPGivenToPlayer += 15;
        }
        Itemdroprate = Player.GetComponent<PlayerStats>().ItemDroprate;

        StoppingDistance = MoveToPlayer.stoppingDistance;
        MoveToPlayer.stoppingDistance = 0;

        DestinationPoints = GameObject.FindGameObjectsWithTag("EnemySpawnPoint");
        CurrentDestination = null;
        SearchForDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange == false)
        {
            if ((this.transform.position.x == CurrentDestination.transform.position.x) && (this.transform.position.z == CurrentDestination.transform.position.z))
            {
                SearchForDestination();
            }
        }

        if(PlayerNotFound == true)
        {
            Player = GameObject.Find("Player");
            PlayerNotFound = false;
        }

        if (PlayerInRange == false)
        {
            //Checks if the player is in range, if so it'll move towards them
            if ((Player.transform.position - this.transform.position).sqrMagnitude < 10 * 10)
            {
                PlayerInRange = true;
                MoveToPlayer.stoppingDistance = StoppingDistance;
                MoveToPlayer.destination = Player.transform.position;
            }
        }
        //Continuously checks the players postion so the enemy can follow them correctly
        if (PlayerInRange == true)
        {
            MoveToPlayer.destination = Player.transform.position;
        }

        //Calculates the distance from the player
        DistanceFromPlayer = Vector3.Distance(transform.position, Player.transform.position);

        //If this distance from the player is lower then attack range then attack
        if(DistanceFromPlayer < DistanceUntilAttack && CanAttack == true)
        {
            //changes the IsAttacking boolean to true
            IsAttacking = true;
            //Faces the player position in order to aim correctly
            transform.LookAt(Player.transform);
        }
        //if the player moves out of the enemy's range then it will stop attacking
        else
        {
            IsAttacking = false;
        }

        //checks to see if the enemy is effected by DOT damage
        if (IsBurning == true)
        {
            InvokeRepeating("Burning", 2, 2);

        }
        //checks to see if the enemy is stunned
        if (IsStunned == true)
        {
            Invoke("Stun", 0);
            Invoke("CancelStun", StunDuration);
        }

        if(EnemyHealth <= 0)
        {
            //Reactivates the navmesh for the player to start moving
            Player.GetComponent<NavMeshAgent>().isStopped = false;
            //Spawn Gold
            Instantiate(GoldPrefab, transform.position, Quaternion.identity);
            //Unlocks the player's postion
            Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            //Empty the enemy variable
            Player.GetComponent<PlayerCombat>().Enemy = null;

            if (!Player.GetComponent<PlayerStats>().MaxLevel)
            {
                //Adds experiance
                Player.GetComponent<PlayerStats>().exp += EXPGivenToPlayer;
            }
            //Allows player to start regening health and stamina
            Player.GetComponent<PlayerStats>().Rest = true;
            //Death sound plays
            Player.GetComponentInChildren<PlayerAudio>().EnemyDeath.Play();
            //Spanws a item 40% of the time
            if (Random.value > Itemdroprate)
            {
                Instantiate(Item[Random.Range(0, Item.Length)], transform.position, Quaternion.identity);
            }
            //if the player's limbharvest ability is activated then the player's attack will be increased on death
            if (Player.GetComponent<PlayerCombat>().LimbHarvestActivated == true)
            {
                Player.GetComponent<PlayerCombat>().AttackDamage += 5;
            }
            Player = null;
            //Destroys itself
            Destroy(this.gameObject);
        }
    }

    void SearchForDestination()
    {
        Vector3 Position = this.transform.position;
        float Distance = Mathf.Infinity;
        GameObject closest = null;
        foreach (GameObject Location in DestinationPoints)
        {
            if (Location != CurrentDestination)
            {
                Vector3 diff = Location.transform.position - Position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < Distance)
                {
                    closest = Location;
                    Distance = curDistance;
                }
            }
        }
        CurrentDestination = closest;
        MoveToPlayer.destination = CurrentDestination.transform.position;
    }

    void MovementWhenPlayerNotInRange()
    {
        //Makes the enemy go back and forth if the player isn't in range
        if (IsRight == true && NotStunned == true)
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
        else if (IsRight == false && NotStunned == true)
        {
            transform.Translate(-Vector3.right * Speed * Time.deltaTime);
        }
        //Lets the enemy know what direction it needs to go in
        if (transform.position.x >= 4.00f)
        {
            IsRight = false;
        }
        if (transform.position.x <= -4)
        {
            IsRight = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Changes the enemy's movement if they hit a wall
        if (other.tag == "Wall")
        {
            if (IsRight == true)
            {
                IsRight = false;
            }
            else if (IsRight == false)
            {
                IsRight = true;
            }
        }
    }
    void Attacking()
    {
        //If IsAttacking is true then the enemy will fire projectiles
        if (IsAttacking == true)
        {
            //Spawns the projectile in front of the enemy
            Rigidbody Bullet = (Rigidbody)Instantiate(Projectile, transform.position + transform.forward, transform.rotation);
            //Sets the damage the projectile will do
            Bullet.GetComponent<Projectile>().Damage = ProjectileDamage;
            //Sets how fast the projectile will go
            Bullet.GetComponent<Projectile>().ProjectileImpulse = ProjectileImpulse;
            //Destroys the bullet after 10 seconds
            Destroy(Bullet.gameObject, 10);
        }
    }

    void Burning()
    {
        //if burning check is lower or equal to 5
        if (BurningCheck <= BurningDuration)
        {
            //Adds burning damage
            EnemyHealth -= BurningDamage;
            //Adds 1 to the burning check
            BurningCheck += 1;
        }
        else
        {
            //sets is burning to false
            IsBurning = false;
            //resets the burn check
            BurningCheck = 0;
        }

    }

    void Stun()
    {
        //If stun is activated the enemy can no longer move or attack
        GetComponent<NavMeshAgent>().isStopped = true;
        CanAttack = false;
        NotStunned = false;
    }

    void CancelStun()
    {
        //if the player isn't touching the enemy once stun deactivates it can move
        if (CanMove == true)
        {
            GetComponent<NavMeshAgent>().isStopped = false;
        }
        NotStunned = true;
        //Lets the enemy attack again
        CanAttack = true;
        //Sets stunned and frozen states back to normal
        IsStunned = false;
        IsFrozen = false;
    }

    private void OnDestroy()
    {
        Player = null;
    }

    public void StatsIncrease()
    {
        switch (floor)
        {
            case 11:
                EnemyHealth *=2;
                ProjectileDamage *=2;
                EXPGivenToPlayer *=2;
                break;
            case 21:
                EnemyHealth *=2;
                ProjectileDamage *=2;
                EXPGivenToPlayer *=2;
                break;
            case 31:
                EnemyHealth *=2;
                ProjectileDamage *=2;
                EXPGivenToPlayer *=2;
                break;
            case 41:
                EnemyHealth *=2;
                ProjectileDamage *=2;
                EXPGivenToPlayer *=2;
                break;
            case 51:
                EnemyHealth *=2;
                ProjectileDamage *=2;
                EXPGivenToPlayer *=2;
                break;
            case 61:
                EnemyHealth *=2;
                ProjectileDamage *=2;
                EXPGivenToPlayer *=2;
                break;
            case 71:
                EnemyHealth *=2;
                ProjectileDamage *=2;
                EXPGivenToPlayer *=2;
                break;
            case 81:
                EnemyHealth *=2;
                ProjectileDamage *=2;
                EXPGivenToPlayer *=2;
                break;
            case 91:
                EnemyHealth *=2;
                ProjectileDamage *=2;
                EXPGivenToPlayer *=2;
                break;
            case 101:
                EnemyHealth *=2;
                ProjectileDamage *=2;
                EXPGivenToPlayer *=2;
                break;
            case 111:
                EnemyHealth *=2;
                ProjectileDamage *=2;
                EXPGivenToPlayer *=2;
                break;
            case 121:
                EnemyHealth *=2;
                ProjectileDamage *=2;
                EXPGivenToPlayer *=2;
                break;
            case 131:
                EnemyHealth *=2;
                ProjectileDamage *=2;
                EXPGivenToPlayer *=2;
                break;
            case 141:
                EnemyHealth *=2;
                ProjectileDamage *=2;
                EXPGivenToPlayer *=2;
                break;
            case 151:
                EnemyHealth *=2;
                ProjectileDamage *=2;
                EXPGivenToPlayer *=2;
                break;
            case 161:
                EnemyHealth *=2;
                ProjectileDamage *=2;
                EXPGivenToPlayer *=2;
                break;
            case 171:
                EnemyHealth *=2;
                ProjectileDamage *=2;
                EXPGivenToPlayer *=2;
                break;
            case 181:
                EnemyHealth *=2;
                ProjectileDamage *=2;
                EXPGivenToPlayer *=2;
                break;
            case 191:
                EnemyHealth *=2;
                ProjectileDamage *=2;
                EXPGivenToPlayer *=2;
                break;
            case 201:
                EnemyHealth *=2;
                ProjectileDamage *=2;
                EXPGivenToPlayer *=2;
                break;

        }

    }
}
