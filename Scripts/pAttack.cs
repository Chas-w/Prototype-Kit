using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pAttack : MonoBehaviour
{
    [Header("DamangeStats")]
    public float attackDamage;
    float attackCooldown;
    [SerializeField] float attackCooldownMax;
    [SerializeField] float attackRange; 

    [Header("Other")]
    [SerializeField] LayerMask attackable;
    public eHealth enemyAttacked;
    bool attacking;

    GameObject theHitObject; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (attacking)
        {
            DamageLogic(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        TriggerAttack();
            
    }

    private void DamageLogic()
    {
        enemyAttacked = theHitObject.GetComponent<eHealth>();
        enemyAttacked.health -= attackDamage * Time.deltaTime; 
    }

    private void TriggerAttack()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, attackRange, attackable))
        {
            theHitObject = hit.collider.gameObject;
            if (Input.GetMouseButton(0))
            {
                attacking = true;
            }
            if (!Input.GetMouseButton(0))
            {
                attacking = false;
            }
        }
        else
        {
            attacking = false;
        }
    }
}

