using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    //Sets variables that will be needed throughout the script
  [HideInInspector]  public float EnemyHealth;
    NavMeshAgent MoveToPlayer;

    //Burning variables
   [HideInInspector] public bool IsBurning;
   [HideInInspector] public int BurningDamage;
   [HideInInspector] public int BurningDuration;
    int BurningCheck;
    public GameObject Player;
   [HideInInspector] public bool IsStunned;
   [HideInInspector] public int StunDuration;
   [HideInInspector] public bool IsFrozen;
   [HideInInspector] public bool CanMove;

    //Used for movement when enemy isn't in range
    private float Speed;
    private bool IsRight;
    private bool PlayerInRange;
    private bool NotStunned;

    //Used to alter the size of the enemy's collider
    private BoxCollider EnemyHitBox;
    private Vector3 HitBoxSize;

    private bool PlayerNotFound;

    public GameObject[] DestinationPoints;
    private GameObject CurrentDestination;

    private void Awake()
    {
        CanMove = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        //finds the player and starts to chase after them
        Player = GameObject.Find("Player");
        MoveToPlayer = GetComponent<NavMeshAgent>();
        Speed = MoveToPlayer.speed;
        PlayerInRange = false;
        EnemyHealth = GetComponent<EnemyStates>().EnemyHealth;
        IsBurning = false;
        IsFrozen = false;
        BurningCheck = 0;
        NotStunned = true;
        EnemyHitBox = this.GetComponent<BoxCollider>();
        HitBoxSize = EnemyHitBox.size;
        if(Player == null)
        {
            PlayerNotFound = true;
        }

        DestinationPoints = GameObject.FindGameObjectsWithTag("EnemySpawnPoint");
        CurrentDestination = null;
        SearchForDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerNotFound == true)
        {
            Player = GameObject.Find("Player");
            PlayerNotFound = false;
        }

        if(PlayerInRange == false)
        {
            if((this.transform.position.x == CurrentDestination.transform.position.x) && (this.transform.position.z == CurrentDestination.transform.position.z))
            {
                SearchForDestination();
            }
        }

        //Checks if the player is in range, if so it'll move towards them
        if ((Player.transform.position - this.transform.position).sqrMagnitude < 10 * 10)
        {
            PlayerInRange = true;
            MoveToPlayer.destination = Player.transform.position;
        }
        //Continuously checks the players postion so the enemy can follow them correctly
        if(PlayerInRange == true)
        {
            MoveToPlayer.destination = Player.transform.position; 
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
    }

    void SearchForDestination()
    {
        Vector3 Position = this.transform.position;
        float Distance = Mathf.Infinity;
        GameObject closest = null;
        foreach (GameObject Location in DestinationPoints)
        {
            if(Location != CurrentDestination)
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

    private void OnTriggerEnter(Collider other)
    {
        //Increase the size of the collider when collided with the player to prevent them from accidently falling out
        if(other.tag == "Player")
        {
            EnemyHitBox.size = new Vector3(2, 1, 2);
        }

        //Changes the enemy's movement if they hit a wall
        if(other.tag == "Wall")
        {
            if(IsRight == true)
            {
                IsRight = false;
            }
            else if(IsRight == false)
            {
                IsRight = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if the player leaves the collider the enemy can move again
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<NavMeshAgent>().isStopped = false;
            CanMove = true;
            //Resets the enemy hit box to original size
            EnemyHitBox.size = HitBoxSize;
        }
    }

    void Burning()
    {
        //if burning check is lower or equal to 5
        if(BurningCheck <= BurningDuration)
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
        //stops the enemy from moving
        MoveToPlayer.isStopped = true;
        //stops the enemy from attacking
        GetComponent<EnemyCombat>().CanAttack = false;
        //the enemy is stunned
        NotStunned = false;
    }

    void CancelStun()
    {
        //if the player isn't touching the enemy once stun deactivates it can move
        if(CanMove == true)
        {
            MoveToPlayer.isStopped = false;
        }
        NotStunned = true;
        //Lets the enemy attack again
        GetComponent<EnemyCombat>().CanAttack = true;
        //Sets stunned and frozen states back to normal
        IsStunned = false;
        IsFrozen = false;
    }

    private void OnDestroy()
    {
        Player = null;
    }
}
