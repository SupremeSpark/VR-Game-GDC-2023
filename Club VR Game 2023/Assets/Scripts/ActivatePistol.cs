using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivatePistol : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;
    public float bulletSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
       XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
       grabbable.activated.AddListener(FireWeapon); 
    }

    public void FireWeapon(ActivateEventArgs arg){
        GameObject spawnedBullet = Instantiate(bulletPrefab);
        spawnedBullet.transform.position = bulletSpawnPoint.transform.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.transform.forward * bulletSpeed;
        UnityEngine.Object.Destroy(spawnedBullet, 5);
    }
}
