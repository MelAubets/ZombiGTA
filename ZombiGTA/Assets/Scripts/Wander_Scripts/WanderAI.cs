using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderAI : MonoBehaviour
{
    private enum State
    {
        Roaming,
        Run,
        Dead,
    }
    private Vector3 startingPosition;
    public float walkRadius;

    public NavMeshAgent agent;
    //public GameObject target;

    public float range = 50f;
    public float speed = 1f;
    public float maxDistance = 15f;
    public float SpeedChangeRate = 10.0f;

    public Animator animator;

    public FieldOfView fow;

    private State state;
    private float _animationBlend;

    private void Awake()
    {
        state = State.Roaming;
    }
    private void Start()
    {
        startingPosition = transform.position;
    }
    private void Update()
    {
        WanderHealth wanHealth = agent.GetComponent<WanderHealth>();
        switch (state)
        {
            default:
            case State.Roaming:
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    agent.SetDestination(GetRoamingPosition());
                    agent.speed = speed;
                    _animationBlend = Mathf.Lerp(_animationBlend, agent.speed, Time.deltaTime * SpeedChangeRate);
                }

                if (FindTarget())
                    state = State.Run;
                if (wanHealth.health <= 0)
                    state = State.Dead;
                break;
            case State.Run:
                if (!FindTarget())
                    state = State.Roaming;
                else
                {
                    float distance = Vector3.Distance(agent.transform.position, fow.visibleTargets[0].position);

                    if (distance < maxDistance)
                    {
                        Vector3 dirToTarget = agent.transform.position - fow.visibleTargets[0].position;
                        Vector3 newPos = agent.transform.position + dirToTarget;
                        agent.SetDestination(newPos);
                        agent.speed = speed * 2.5f;
                        _animationBlend = Mathf.Lerp(_animationBlend, agent.speed, Time.deltaTime * SpeedChangeRate);
                    }
                    else
                    {
                        state = State.Roaming;
                    }
                }
                if (wanHealth.health <= 0)
                    state = State.Dead;
                break;
            case State.Dead:
                agent.SetDestination(agent.transform.position);
                agent.speed = 0f;
                break;
        }

        animator.SetFloat("Speed", _animationBlend);
    }

    private Vector3 GetRoamingPosition()
    {
        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;
        randomPosition += transform.position;
        if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, walkRadius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    private bool FindTarget()
    {
        if (fow.visibleTargets.Count != 0)
        {
            return true;
        }

        return false;
    }

}
