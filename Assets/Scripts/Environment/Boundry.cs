using UnityEngine;

public class Boundry : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D trigger)
	{
		if(trigger.TryGetComponent(out UpgradeView upgradeView))
		{
			Destroy(trigger.gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.TryGetComponent(out Asteroid asteroid))
		{
			Destroy(asteroid.gameObject);
		}
	}
}