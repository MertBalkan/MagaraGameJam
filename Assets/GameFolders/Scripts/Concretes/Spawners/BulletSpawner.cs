using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Concretes.Controllers;
using MagaraGameJam.Concretes.Managers;
using UnityEngine;

namespace MagaraGameJam.Concretes.Spawners
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _bulletSpawnTime;
        [SerializeField] private float _bulletSpawnRate;
        [SerializeField] private AudioClip _gunFireClip;
        [SerializeField] private BulletController _bullet;
        [SerializeField] private EnemyController _enemy;

        private void Start()
        {
            SoundManager.Instance.SoundControllers[3].SetClip(_gunFireClip);
            InvokeRepeating("SpawnBullet", _bulletSpawnTime, _bulletSpawnRate);
        }

        public void SpawnBullet()
        {
            SoundManager.Instance.GunFireSound();
            Vector3 rotVec = new Vector3(this.transform.localRotation.x, this.transform.localRotation.y, this.transform.localRotation.z);
            Quaternion newQua = Quaternion.Euler(rotVec);

            GameObject bullet = Instantiate(_bullet.gameObject, transform.position, newQua) as GameObject;
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * _bulletSpeed;
        }
    }
}