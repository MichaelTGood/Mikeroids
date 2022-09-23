using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeView : MonoBehaviour
{


		#region Editor Variables

		[SerializeField]
		private TextMeshPro _letter;

		[SerializeField]
		private SpriteRenderer _capsule;

		[SerializeField]
		private Rigidbody2D _rigidbody;

		[Header("Upgrade Object Settings")]
		[SerializeField]
		private float _movementSpeed = 66f;

		#endregion

		#region Variables

		private readonly Dictionary<ShipUpgradeTypes, string> _shipUpgradeLetters = new Dictionary<ShipUpgradeTypes, string>() {
			{ ShipUpgradeTypes.Decouple, "D" },
			{ ShipUpgradeTypes.Warp, "W" },
		};

		private readonly Dictionary<WeaponUpgradeTypes, string> _weaponUpgradeLetters = new Dictionary<WeaponUpgradeTypes, string>() {
			{ WeaponUpgradeTypes.RapidFire, "R" },
			{ WeaponUpgradeTypes.DualShot, "D" },
			{ WeaponUpgradeTypes.BigBlaster, "B" },
		};

		private Upgrade _upgrade;

		private readonly Color _capsuleWeaponColor = new Color(1f, 0.75f, 0.75f, 0.5f);
		private readonly Color _letterWeaponColor = new Color(1f, 0.5f, 0.5f, 1f);

		private readonly Color _capsuleShipColor = new Color(0.75f, 0.75f, 1f, 0.5f);
		private readonly Color _letterShipColor = new Color(0.5f, 0.5f, 1f, 1f);

		#endregion

		private void Awake()
		{
			_upgrade = new Upgrade();

			switch(_upgrade.UpgradeType)
			{
				case UpgradeTypes.Ship:
					_capsule.color = _capsuleShipColor;
					_letter.color = _letterShipColor;
					if(_shipUpgradeLetters.TryGetValue(_upgrade.ShipUpgradeType, out string shipLetter))
					{
						_letter.text = shipLetter;
					}
					break;

				case UpgradeTypes.Weapon:
					_capsule.color = _capsuleWeaponColor;
					_letter.color = _letterWeaponColor;
					if(_weaponUpgradeLetters.TryGetValue(_upgrade.WeaponUpgradeType, out string weaponLetter))
					{
						_letter.text = weaponLetter;
					}
					break;
			}
		}

		#region Public Methods

		public void SetTrajectory(Vector2 direction)
		{
			Transform playerTransform= FindObjectOfType<Player>().transform;
			Vector2 trajectory = playerTransform.position - transform.position;
			_rigidbody.AddForce(trajectory.normalized * _movementSpeed);
			
		}

		#endregion

		#region Private Methods

		private void OnTriggerEnter2D(Collider2D col)
		{
			throw new NotImplementedException();
		}

		#endregion
	}