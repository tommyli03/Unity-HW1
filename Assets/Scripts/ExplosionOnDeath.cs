using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionOnDeath : MonoBehaviour
{
    public GameObject particlePrefab;

    void Awake() {
        var life = GetComponent<Life>();
        life.onDeath.AddListener(onDeath);
    }

    void onDeath() {
        Instantiate(particlePrefab, transform.position, transform.rotation);
    }
}
