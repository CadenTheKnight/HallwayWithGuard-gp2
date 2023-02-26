using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemy : MonoBehaviour
{
public NavMeshAgent agent;

public Transform player;

public float speed;

public LayerMask WhatIsGround, WhatIsPlayer;

 public AudioSource audioSource;

    public Transform firepoint;

    // ranging attacks
    public GameObject Projectile;

 //patroling
    public Vector3 walkpoint;
    bool WalkPointSet;
    public AudioClip Patrolclip;
   
 // chasing
    public AudioClip chaseclip;
    bool IsChasing;
//attacking
    public float RateOfAttacks;
    bool Attacked;
    public AudioClip attackclip;
    bool IsAttacking;
//states
public float SightRange, AttackRange;
public bool PlayerInSightRange, PlayerInAttackRange;
// walkpoints
public Transform[] waypoints;
private int waypointIndex;
private float distance;


void Start()
    {
      waypointIndex = 0;
      transform.LookAt(waypoints[waypointIndex].position);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Patrolclip;
        audioSource.Play();
    }
    

    private void Awake()
{
    player = GameObject.Find("Player Controller").transform;
    agent = GetComponent<NavMeshAgent>();
}
    private void Update()
    {
       //checks for if the player is within sight and attack range
       PlayerInSightRange = Physics.CheckSphere(transform.position, SightRange, WhatIsPlayer);
       PlayerInAttackRange = Physics.CheckSphere(transform.position, AttackRange, WhatIsPlayer);

       if (!PlayerInSightRange && !PlayerInAttackRange) Patrolling();
       if (PlayerInSightRange && !PlayerInAttackRange) Chasing();
       if (PlayerInSightRange && PlayerInAttackRange) Attacking();

       distance = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
       if(distance < 1f)
       {
        IncreaseIndex();
       }
    }

    private void Patrolling()
    {
       transform.Translate(Vector3.forward * speed * Time.deltaTime);
       
        
    }
    void IncreaseIndex()
    {
      waypointIndex++;
      if (waypointIndex >= waypoints.Length) 
      {
        waypointIndex = 0;
      }
      transform.LookAt(waypoints[waypointIndex].position);
    }

    private void Chasing()
    {
      agent.SetDestination(player.position);
        if (IsChasing != true)
        {
            IsChasing = true;
            audioSource.clip = chaseclip;
            audioSource.Play();
            
        }
        
    }
    private void Attacking()
    {
      agent.SetDestination(transform.position);

      transform.LookAt(player);
        if (IsAttacking != true)
        {
          //attack code here
          Rigidbody rb = Instantiate(Projectile, firepoint.position, firepoint.rotation).GetComponent<Rigidbody>();
          rb.AddForce(transform.forward * 32f, ForceMode.Impulse);

          //
          Invoke(nameof(ResetAttack),RateOfAttacks);
            IsAttacking = true;
            audioSource.clip = attackclip;
            audioSource.Play();
            IsChasing = false;
        }

    }

    private void ResetAttack()
    {
      IsAttacking = false;
    }
}
