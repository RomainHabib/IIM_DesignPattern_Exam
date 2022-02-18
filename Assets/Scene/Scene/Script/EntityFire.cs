using System.Collections;
using System.Collections.Generic;
using Codice.CM.Triggers;
using UnityEngine;

public class EntityFire : MonoBehaviour
{
    [SerializeField] Transform _spawnPoint;
    [SerializeField] private ObjectPoolReference bulletPool;
    // [SerializeField] Bullet _bulletPrefab;

    private bool canShoot = true;

    // Check if the player can shoot or not
    public bool CanShoot { get { return canShoot; } set { canShoot = value; } }
    
    public void FireBullet(int power)
    {
        if (!canShoot) return;

        // Get a bullet from the bullet pool and reset it's position and direction
        var bullet = bulletPool.Instance.GetObjectFromPool().GetComponent<Bullet>();
        bullet.transform.position = _spawnPoint.position;
        bullet.Init(_spawnPoint.TransformDirection(Vector3.right), power);

        // var b = Instantiate(_bulletPrefab, _spawnPoint.transform.position, Quaternion.identity, null)
        //     .Init(_spawnPoint.TransformDirection(Vector3.right), power);
    }

}
