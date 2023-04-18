using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public int damage = 10;
    public float attackRange = 2f;
    public float attackDelay = 1f;
    public float moveSpeed = 3f;
    public float gravity = 9.81f;
    public int health = 50;

    private Transform playerTransform;
    private bool canAttack = true;
    private CharacterController controller;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Animator anim;

    Vector3 velocity;
    bool isGrounded;

    public SpawnManager spawnManager;



    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        controller = GetComponent<CharacterController>();

        anim = GetComponent<Animator>();

    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (playerTransform == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= attackRange)
        {
            if (canAttack)
            {
                Attack();
            }
        }
        else
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {   //Moving
        Vector3 direction = playerTransform.position - transform.position;
        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction.normalized * moveSpeed * Time.deltaTime);
        transform.LookAt(playerTransform);


    }

    void Attack()
    {
        canAttack = false;
        Invoke("ResetAttack", attackDelay);


        // Deal damage to the player
        PlayerHealth playerHealth = playerTransform.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    void ResetAttack()
    {
        canAttack = true;
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }


    public void SetSpawnManager(SpawnManager spawnManager)
    {
        this.spawnManager = spawnManager;
    }
}
