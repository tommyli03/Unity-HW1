using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class WavesManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static WavesManager instance;
    public List<WaveSpawner> waves;
    public UnityEvent onChanged = new UnityEvent();

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Debug.LogError("Duplicated WavesManager, ignoring this one", gameObject);
        }
    }

    public void AddWave(WaveSpawner wave) {
        waves.Add(wave);
        onChanged.Invoke();
    }

    public void RemoveWave(WaveSpawner wave) {
        waves.Remove(wave);
        onChanged.Invoke();
    }
}
