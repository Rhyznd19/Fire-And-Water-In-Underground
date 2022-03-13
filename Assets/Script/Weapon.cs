using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bulletPrefab;

	// Update is called once per frame
	void Update()
	{
		//jika tekan tombol spasi menjalankan method shoot
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
	}

	void Shoot()
	{
		// mengiinisiasi bullet
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
