using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootBullet : MonoBehaviour
{
	[Header("Basic Paintball Management")]
	public Transform firePoint;
	public GameObject bulletPrefab;
	public AudioSource bulletShootSound;
	public Button shootButton;
	public PlayerMovement pm;

	[Header("Ammo Management")]
	public int ammo;
	public Slider ammoBar;
	public bool infiniteAmmo;

	public EventSystem eventSystem;

	// Start is called during the first frame
	void Start()
	{
		ammo = 25;
		ammoBar.value = ammo;

		eventSystem.SetSelectedGameObject(null);
	}

	// Update is called once per frame
	void Update()
	{
		//if (Input.GetKeyDown(KeyCode.E))
		//{
		//	Shoot();
		//}
	}

	public void Shoot()
	{
        if (pm.controlsOn)
        {
			if (ammo > 1 && infiniteAmmo == false)
			{
				ammo -= 1;
				ammoBar.value = ammo;
				bulletShootSound.Play();
				Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

				eventSystem.SetSelectedGameObject(null);
			}
			else if (infiniteAmmo)
			{
				bulletShootSound.Play();
				Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

				eventSystem.SetSelectedGameObject(null);
			}
			else if (ammo == 1)
			{
				ammo -= 1;
				ammoBar.value = ammo;
				bulletShootSound.Play();
				Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
				shootButton.interactable = false;

				eventSystem.SetSelectedGameObject(null);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("PowerupMoreAmmo"))
		{
			ammo = 25;
			ammoBar.value = ammo;
			shootButton.interactable = true;

			Destroy(collision.gameObject);
		}
	}
}
