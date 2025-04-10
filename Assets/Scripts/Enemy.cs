using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Start()
    {
        if (EnemiesManager.instance != null)
        {
            EnemiesManager.instance.AddEnemy(this);
        }
        else
        {
            Debug.LogWarning("EnemiesManager instance not found in Start()");
        }
    }

    private void OnDestroy()
    {
        if (EnemiesManager.instance != null)
        {
            EnemiesManager.instance.RemoveEnemy(this);
        }
    }

}
