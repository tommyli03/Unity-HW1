using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint;
    // Update is called once per frame

    public void OnFire() {
        GameObject clone = Instantiate(prefab);
        clone.transform.position = shootPoint.transform.position;
        clone.transform.rotation = shootPoint.transform.rotation;
    }
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Mouse0)) {
    //         GameObject clone = Instantiate(prefab);
    //         clone.transform.position = shootPoint.transform.position;
    //         clone.transform.rotation = shootPoint.transform.rotation;
    //     }
    // }
}
