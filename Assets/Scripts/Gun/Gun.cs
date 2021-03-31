using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{


	[SerializeField] private GameObject bulletPrefab;
	[SerializeField] private float bulletSpeed = 5.0f;
	[SerializeField] private Vector3 bulletDirection = Vector3.right;


	[SerializeField] private float bulletSpawnDelay = 1.0f;
	[SerializeField] private GameObject gunPoint;

	private bool _canSpawn = true;
	private float _lastSpawnTime;


	private void Update()
	{
		if (_canSpawn && (Time.time - _lastSpawnTime) >= bulletSpawnDelay )
		{
			SpawnBullet();
		}
	}


	private void SpawnBullet()
	{
		GameObject bullet = Instantiate(bulletPrefab, gunPoint.transform.position, Quaternion.identity);
		bullet.transform.SetParent(this.gameObject.transform, true);
		bullet.transform.localScale = bulletPrefab.transform.localScale;
		BulletBase bulletBase = bullet.GetComponent<BulletBase>();
		bulletBase.SetUp(bulletSpeed, bulletDirection);
		_lastSpawnTime = Time.time;
	}




}
