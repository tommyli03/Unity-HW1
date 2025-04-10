using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAnimator : MonoBehaviour
{
    NavMeshAgent navMesh;
    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
        // animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetFloat("Velocity", navMesh.velocity.magnitude);
    }
}
