using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSystem : MonoBehaviour
	{
		#region Editor Variables

		[Header("Game Objects")]
		[SerializeField]
		private SpriteRenderer _spriteRenderer;

		[SerializeField]
		private Sprite _originalShipSprite;

		[SerializeField]
		private Sprite _upgradedShipSprite;

		[SerializeField]
		private Transform _frontBarrelTip;

		[SerializeField]
		private Transform[] _wingBarrelTips;

		[SerializeField]
		private Bullet _bulletPrefab;

		[Header("Weapons System Settings")]
		[SerializeField]
		private float _fireCooldown;

		[SerializeField]
		private float _burstTiming;

		#endregion

		#region Variables

		private Coroutine _firingRoutine;
		private Queue<Transform> _barrelTips = new Queue<Transform>();

		private FireRate _fireRate;
		private bool _dualShotEnabled;

		private WaitForSeconds _cooldownWait;
		private WaitForSeconds _burstWait;
		private WaitForSeconds _dualBurstWait;
		
		#endregion

		#region Lifecycle

		private void Awake()
		{
			_cooldownWait = new WaitForSeconds(_fireCooldown);
			_burstWait = new WaitForSeconds(_burstTiming);
			_dualBurstWait = new WaitForSeconds(_burstTiming / 2);
		}

		private void OnDisable()
		{
			InputManager.WeaponsSystem.Fire.started -= OnFire;

			InputManager.WeaponsSystem.Fire.canceled -= OnStopAutoFire;
		}

		#region Public Methods

		public void Initialize()
		{
			_fireRate = 0;
			_dualShotEnabled = false;
			_spriteRenderer.sprite = _originalShipSprite;
			_barrelTips.Clear();
			_barrelTips.Enqueue(_frontBarrelTip);
			
			InputManager.WeaponsSystem.Fire.started += OnFire;
		}

		public void Upgrade(WeaponUpgradeTypes upgrade)
		{
			switch(upgrade)
			{
				case WeaponUpgradeTypes.RapidFire:
					if(_fireRate != FireRate.FullAuto)
					{
						if(_fireRate == FireRate.Burst)	// A bad way to determine if the ship is going full auto.
                     	{
                     		InputManager.WeaponsSystem.Fire.canceled += OnStopAutoFire;
                     	}

						_fireRate++;
					}
					break;
				
				case WeaponUpgradeTypes.DualShot:
					_dualShotEnabled = true;
					_spriteRenderer.sprite = _upgradedShipSprite;
					_barrelTips.Clear();
					_barrelTips.EnqueueRange(_wingBarrelTips);
					break;
			}
		}

		#endregion

		#endregion

		private void OnFire(InputAction.CallbackContext ctx)
		{
			if(_firingRoutine == null)
			{
				_firingRoutine = _fireRate == FireRate.FullAuto ? StartCoroutine(FullAutoFireRoutine()) : StartCoroutine(SingleAndBurstFireRoutine());
			}
		}

		private IEnumerator SingleAndBurstFireRoutine()
		{
			FireShot();

			if(_fireRate == FireRate.Single)
			{
				yield return _cooldownWait;

				_firingRoutine = null;

				yield break;
			}

			yield return _dualShotEnabled ? _dualBurstWait : _burstWait;

			FireShot();

			yield return _dualShotEnabled ? _dualBurstWait : _burstWait;

			FireShot();

			yield return _cooldownWait;
			_firingRoutine = null;
		}

		private IEnumerator FullAutoFireRoutine()
		{
			while(true)
			{
				FireShot();
				yield return _dualShotEnabled ? _dualBurstWait : _burstWait;
			}
		}

		private void OnStopAutoFire(InputAction.CallbackContext ctx)
		{
			StopCoroutine(_firingRoutine);
			_firingRoutine = null;
		}

		private void FireShot()
		{
			Transform barrelTip = _barrelTips.CycleItem();
			Bullet bullet = Instantiate(_bulletPrefab, barrelTip.position, barrelTip.rotation);
			bullet.Project(barrelTip.up);
		}

		private void UpdateInputSubscriptions()
		{
			InputManager.WeaponsSystem.Fire.started += OnFire;

			if(_fireRate == FireRate.FullAuto)
			{
				InputManager.WeaponsSystem.Fire.canceled += OnStopAutoFire;
			}
		}

		#region Cheater

		[ContextMenu("Switch to Single Shot")]
		private void CheaterSwitchToSingleShot()
		{
			InputManager.WeaponsSystem.Fire.canceled -= OnStopAutoFire;
			_fireRate = FireRate.Single;
		}

		[ContextMenu("Switch to Burst Shot")]
		private void CheaterSwitchToBurstShot()
		{
			InputManager.WeaponsSystem.Fire.canceled -= OnStopAutoFire;
			_fireRate = FireRate.Burst;
		}

		[ContextMenu("Switch to FullAuto")]
		private void CheaterSwitchToFullAuto()
		{
			_fireRate = FireRate.FullAuto;
			InputManager.WeaponsSystem.Fire.canceled += OnStopAutoFire;
		}

		[ContextMenu("Switch to Dual Shot")]
		private void CheaterSetDualShot()
		{
			Upgrade(WeaponUpgradeTypes.DualShot);
		}

		#endregion

	}
