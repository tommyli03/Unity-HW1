using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    // Animator animator;
    public enum EnemyState { GoToBase, AttackBase, ChasePlayer, AttackPlayer }
    public EnemyState currentState;
    public Sight sightSensor;
    public Transform baseTransform;
    public float baseAttackDistance;
    public float playerAttackDistance;
    private UnityEngine.AI.NavMeshAgent agent;
    public float lastShootTime;
    public GameObject bulletPrefab;
    public float fireRate;

    public ParticleSystem muzzleEffect;
    void Shoot() {
        // animator.SetBool("Shooting", true);
        var timeSinceLastShoot = Time.time - lastShootTime;
        if (timeSinceLastShoot > fireRate) {
            lastShootTime = Time.time;
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
        muzzleEffect.Play();
    }

    private void Awake()
    {
        baseTransform = GameObject.Find("BaseDamagePoint").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        // animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == EnemyState.GoToBase) {
            GoToBase();
        } else if (currentState == EnemyState.AttackBase) {
            AttackBase();
        } else if (currentState == EnemyState.ChasePlayer) {
            ChasePlayer();
        } else {
            AttackPlayer();
        }
    }

    void GoToBase() {
        // animator.SetBool("Shooting", false);
        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);
        if (sightSensor.detectedObject != null) {
            currentState = EnemyState.ChasePlayer;
        }
        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);
        if (distanceToBase < baseAttackDistance) {
            currentState = EnemyState.AttackBase;
        }
    }

    void AttackBase() {
        agent.isStopped = true;
        LookTo(baseTransform.position);
        Shoot();
    }

    void ChasePlayer() {
        // animator.SetBool("Shooting", false);
        agent.isStopped = false;
        if (sightSensor.detectedObject == null) {
            currentState = EnemyState.GoToBase;
            return;
        }
        agent.SetDestination(sightSensor.detectedObject.transform.position);
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if (distanceToPlayer <= playerAttackDistance) {
            currentState = EnemyState.AttackPlayer;
        }   
    }

    void AttackPlayer() {
        agent.isStopped = true;
        if (sightSensor.detectedObject == null) {
            currentState = EnemyState.GoToBase;
            return;
        }
        LookTo(sightSensor.detectedObject.transform.position);
        Shoot();
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if (distanceToPlayer > playerAttackDistance * 1.1f) {
            currentState = EnemyState.ChasePlayer;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);
    }

    void LookTo(Vector3 targetPosition) {
        Vector3 directionToPosition = Vector3.Normalize(targetPosition - transform.position);
        directionToPosition.y = 0;
        transform.parent.forward = directionToPosition;
    }
}
