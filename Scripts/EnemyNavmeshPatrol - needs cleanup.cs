
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //important

//if you use this code you are contractually obligated to like the YT video
public class eManager : MonoBehaviour //don't forget to change the script name if you haven't
{
    [Header("Patrol Data")]
    public NavMeshAgent agent;
    public float range; //radius of sphere
    public eAttack distanceCheck; 
    public eHealth healthCheck;
    public Transform centrePoint; //centre of the area the agent wants to move around in
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area
    [Header("Chase Data")]
    public float chaseRange;

    [Header("Animation")]
    public Animator eAnim;
    public bool died;
    public bool attacked;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (!distanceCheck.chase)
        {
            if (agent.remainingDistance <= agent.stoppingDistance) //done with path
            {
                Vector3 point;
                if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                    agent.SetDestination(point);
                }
            }
        } else if (distanceCheck.chase)
        {
            if (agent.remainingDistance <= agent.stoppingDistance) //done with path
            {
                agent.destination = distanceCheck.chaseObject.position;
            }

        }
        AnimationSetter(); 


    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    private void AnimationSetter()
    {
        if (!distanceCheck.attackHold && !attacked && !died  )
        {
            if (agent.velocity == Vector3.zero)
            {
                eAnim.SetInteger("Movement", 0);
            }
            if (agent.velocity.z != 0)
            {
                eAnim.SetInteger("Movement", 1);
            }
        }
        if (distanceCheck.attackHold && !attacked)
        {
            eAnim.SetInteger("Movement", 8);
        }
        if (attacked && !died)
        {
            if (healthCheck.health >= healthCheck.maxHealth/2)
            {
                eAnim.SetInteger("Movement", 5);
            } 
            else
            {
                eAnim.SetInteger("Movement", 6);
            }
        }
        if (died)
        {
            eAnim.SetInteger("Movement", 7);
        }
     
    }


}
