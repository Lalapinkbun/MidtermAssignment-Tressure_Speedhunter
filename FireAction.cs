using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAction : MonoBehaviour
{
    public GameObject _bullet;
    public Transform _firePoint;

    public void Shoot()
    {
        Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
    }
}
