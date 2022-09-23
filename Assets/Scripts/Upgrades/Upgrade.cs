using System;
using Random = UnityEngine.Random;

public class Upgrade
{
	#region Properties

	public UpgradeTypes UpgradeType { get; }

	public ShipUpgradeTypes ShipUpgradeType { get; }

	public WeaponUpgradeTypes WeaponUpgradeType { get; }

	#endregion

	public Upgrade()
	{
		UpgradeType = (UpgradeTypes)Random.Range(0, Enum.GetValues(typeof(UpgradeTypes)).Length);
		ShipUpgradeType = (ShipUpgradeTypes)Random.Range(0, Enum.GetValues(typeof(ShipUpgradeTypes)).Length);
		WeaponUpgradeType = (WeaponUpgradeTypes)Random.Range(0, Enum.GetValues(typeof(WeaponUpgradeTypes)).Length);
	}
}