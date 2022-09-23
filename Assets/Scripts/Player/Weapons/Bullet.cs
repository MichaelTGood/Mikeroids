using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
	#region Editor Variables

	[SerializeField]
	private Rigidbody2D _rigidbody;

	[SerializeField]
	private float _speed = 500f;

	[SerializeField]
	private float _maxLifetime = 10f;

	#endregion

	public void Project(Vector2 direction)
	{
		_rigidbody.AddForce(direction * _speed);

		Destroy(gameObject, _maxLifetime);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(gameObject);
	}

}