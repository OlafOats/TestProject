using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float scopeSpread;
    public float noScopeSpread;
    public float spread;
    public float SPM;
    public GameObject bulletPrefab;
    public Transform shotPoint;
    public int buckshot;
    private float timeBtwShoot;

    public void Shoot()
    {
        if(timeBtwShoot <= 0)
        {
            for(int i = 0; i < buckshot; i ++)
            {
                float spreadX = Random.Range(-spread / 2, spread / 2);
                float spreadY = Random.Range(-spread / 2, spread / 2);
                Instantiate(bulletPrefab, shotPoint.position, Quaternion.Euler(shotPoint.rotation.x + spreadX, shotPoint.rotation.y + spreadY, 0));
            }
            timeBtwShoot = 60 / SPM;
        }
        else
        {
            timeBtwShoot -= Time.deltaTime;
        }
    }
}
