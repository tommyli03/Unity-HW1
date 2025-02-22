using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Life : MonoBehaviour
{
    public float amount;
    public UnityEvent onDeath = new UnityEvent();
    // Start is called before the first frame update
    void Update()
    {
        if (amount <= 0) {
            onDeath.Invoke();
            Destroy(gameObject);
        }
    }
}
