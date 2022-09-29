using System;

public enum UpgradeTypes
{
	Ship = 0,
	Weapon = 1,
}

public enum ShipUpgradeTypes
{
	Warp,
	Decouple,
}

public enum WeaponUpgradeTypes
{
	RapidFire,
	DualShot,
	// BigBlaster,
}

public enum FireRate
{
	Single,
	Burst,
	FullAuto,
}

[Flags]
public enum EngineMode
{
	Standard = 0,
	Decoupled = 1 << 0,
	Warp = 1 << 1,
	
	DecoupledWarp = Decoupled | Warp,
}
