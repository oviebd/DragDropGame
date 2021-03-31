using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : DamagerBase
{
	private float _speed = 5.0f;
	private Vector3 _direction = Vector3.right;

	[SerializeField] private GameObject graphicsObj;


	private Collider2D _collider2D;
	private bool _canMove = true;

	private void Start()
	{
		_collider2D = GetComponent<Collider2D>();
	}

	public void SetUp(float speed, Vector3 direction)
	{
		this._direction = direction;
		this._speed = speed;
		_canMove = true;
	}

	private void Update()
	{
		if (_canMove)
			transform.position = transform.position + _direction * _speed * Time.deltaTime;

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{	
		InActiveBullet();
	}

	private void InActiveBullet()
	{
		graphicsObj.SetActive(false);
		_canMove = false;
		_collider2D.enabled = false;

		Invoke("DestroyBullet", .5f);
	}

	void DestroyBullet()
	{
		Destroy(this.gameObject);
	}
}
