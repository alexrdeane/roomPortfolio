using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public int damage = 10;
    public float attackRate = 1f;
    public float attackRange = 2f;
    protected Player currentPlayer;

    private float attackTimer = 0f;

    public Material enemyMaterial;
    public GameObject body;

    void OnDrawGizmosSelected()
    {
        // Draw the attack sphere around
        Gizmos.color = Color.green;
        // Cube Range - Change Detect Enemies too
        Gizmos.DrawWireCube(transform.position + transform.forward, new Vector3(attackRange, 1, 2.5f));
        // Circle Range
        //Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    // Aims at a given enemy every frame
    public virtual void Aim(Player e)
    {
        print("I am aiming at '" + e.name + "'");
    }
    // Attacks at a given enemy only when 'attacking'
    public virtual void Attack(Player e)
    {
        print("I am attacking '" + e.name + "'");
    }

    void DetectEnemies()
    {
        // Reset current enemy
        currentPlayer = null;
        // Perform OverlapSphere and get the hits
        // Cube Range - Change OnDrawGizmosSelected too
        Collider[] hits = Physics.OverlapBox(transform.position + transform.forward, new Vector3(attackRange, 1, 2.5f));
        // Circle Range
        //Collider[] hits = Physics.OverlapSphere(transform.position, attackRange);
        // Loop through everything we hit
        foreach (var hit in hits)
        {
            // If the thing we hit is an enemy
            Player player = hit.GetComponent<Player>();
            if (player)
            {
                // Set current enemy to that one
                currentPlayer = player;
            }
        }
    }

    protected virtual void Update()
    {
        body.GetComponent<Renderer>().material = enemyMaterial;
        // Detect enemies before performing attack logic
        DetectEnemies();
        // Count up the timer
        attackTimer += Time.deltaTime;
        // if there's an enemy
        if (currentPlayer)
        {
            // Aim at the enemy
            Aim(currentPlayer);
            // Is attack timer ready?
            if (attackTimer >= attackRate)
            {
                // Attack the enemy!
                Attack(currentPlayer);
                // Reset timer
                attackTimer = 0f;
            }
        }
    }
}
