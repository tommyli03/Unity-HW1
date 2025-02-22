using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Start()
    {
        EnemiesManager.instance.AddEnemy(this);
    }

    private void OnDestroy()
    {
        EnemiesManager.instance.RemoveEnemy(this);

    }
}
