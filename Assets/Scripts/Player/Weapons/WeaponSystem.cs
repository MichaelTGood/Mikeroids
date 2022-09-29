using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSystem : MonoBehaviour
	{
		#region Editor Variables

		[Header("Game Objects")]
		[SerializeField]
		private AudioSource _audioSource;

		[SerializeField]
		private GameObject _dualBarrels;

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

		#region Events

		public delegate void FireRateUpdatedEventHander(FireRate newFireRate);
		public event FireRateUpdatedEventHander FireRateUpdatedEvent;
		private void FireFireRateUpdatedEvent()
		{
			FireRateUpdatedEvent?.Invoke(_fireRate);
		}

		#endregion

		#region Lifecycle

		private void Awake()
		{
			_cooldownWait = new WaitForSeconds(_fireCooldown);
			_burstWait = new WaitForSeconds(_burstTiming);
			_dualBurstWait = new WaitForSeconds(_burstTiming / 2);
		}

		private void OnEnable()
		{
			HandleSubscriptions(true);
		}
		private void OnDisable()
		{
			HandleSubscriptions(false);

			if(_firingRoutine != null)
			{
				StopCoroutine(_firingRoutine);
			}
		}

		#region Public Methods

		public void Initialize()
		{
			_fireRate = 0;
			FireFireRateUpdatedEvent();

			_dualShotEnabled = false;
			_dualBarrels.SetActive(_dualShotEnabled);

			_barrelTips.Clear();
			_barrelTips.Enqueue(_frontBarrelTip);

			_firingRoutine = null;
		}

		public void Upgrade(WeaponUpgradeTypes upgrade)
		{
			switch(upgrade)
			{
				case WeaponUpgradeTypes.RapidFire:
					if(_fireRate != FireRate.FullAuto)
					{
						// A bad way to determine if the ship is going full auto.
						// Handled this way so that we only subscribe once,
						// and not every time an upgrade is picked up after achieving full auto.
						if(_fireRate == FireRate.Burst)
						{
							InputManager.WeaponsSystem.Fire.canceled += OnStopAutoFire;
						}

						_fireRate++;
						FireFireRateUpdatedEvent();
					}
					break;
				
				case WeaponUpgradeTypes.DualShot:
					_dualShotEnabled = true;
					_dualBarrels.SetActive(_dualShotEnabled);
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

			_audioSource.Play();
		}

		protected virtual void HandleSubscriptions(bool subscribe)
		{
			if(subscribe)
			{
				InputManager.WeaponsSystem.Enable();
				InputManager.WeaponsSystem.Fire.started += OnFire;
			}
			else
			{
				InputManager.WeaponsSystem.Disable();
				InputManager.WeaponsSystem.Fire.started -= OnFire;
				InputManager.WeaponsSystem.Fire.canceled -= OnStopAutoFire;
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
