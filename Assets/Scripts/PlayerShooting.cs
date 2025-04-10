using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShooting : MonoBehaviour
{
    Animator animator;
    public GameObject prefab;
    public GameObject shootPoint;
    public ParticleSystem muzzleEffect;
    public AudioSource shootSound;
    public int bulletsAmount;
    public float fireRate;
    // Update is called once per frame

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    public void OnFire(InputValue value) {
        animator.SetBool("Shooting", value.isPressed);
        if (value.isPressed) {
            InvokeRepeating("Shoot", fireRate, fireRate);
        } else {
            CancelInvoke();
        }
    }

    private void Shoot() {
        if (bulletsAmount > 0 && Time.timeScale > 0) {
            bulletsAmount--;
            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;
            if (muzzleEffect != null) {
            muzzleEffect.Play();
            } else {
                Debug.LogWarning("muzzleEffect is not assigned or has been destroyed.");
            }
            shootSound.Play();
        }
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
