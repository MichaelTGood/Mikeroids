using DG.Tweening;
using UnityEngine;

	public class Lightning : MonoBehaviour
	{
		#region Consts

		private const string TweenId = "LightningTween";
		private const float TweenAnimationTime = 0.2f;

		#endregion

		#region Editor Variables

		[SerializeField]
		private LineRenderer _lineRenderer;

		[SerializeField]
		private EdgeCollider2D _edgeCollider;

		[SerializeField]
		private Transform _asteroid0;

		[SerializeField]
		private Transform _asteroid1;

		#endregion

		#region Variables

		private bool _initialized;
		private Sequence _sequence;
		private readonly Color2 _firstColor = new Color2(new Color(1f, 1f, 0f, 0.75f), new Color(1f, 0.75f, 0.25f, 0.15f));
		private readonly Color2 _secondColor = new Color2(new Color(1f, 0.75f, 0.25f, 0.15f), new Color(1f, 1f, 0f, 0.75f));

		#endregion

		public void Initialize(Transform asteroid0, Transform asteroid1)
		{
			_asteroid0 = asteroid0;
			_asteroid1 = asteroid1;

			_initialized = true;
			_sequence = DOTween.Sequence().SetId(TweenId).SetLoops(-1, LoopType.Yoyo);
			_sequence.Append(_lineRenderer.DOColor(_firstColor, _secondColor, TweenAnimationTime));
		}

		#region Lifecycle

		private void Update()
		{
			if(!_initialized)
			{
				return;
			}

			if(_asteroid0 && _asteroid1)
			{
				SetPositions();
			}
			else
			{
				DOTween.Kill(TweenId);
				Destroy(gameObject);
			}
		}

		#endregion

		#region Private Methods

		private void SetPositions()
		{
			_lineRenderer.SetPosition(0, _asteroid0.transform.position);
			_lineRenderer.SetPosition(1, _asteroid1.transform.position);
			_edgeCollider.points = new Vector2[]
			{
				_asteroid0.transform.position,
				_asteroid1.transform.position
			};
		}

		#endregion

		#region Cheater

		[ContextMenu("Set Points")]
		private void CheaterSetPositions()
		{
			SetPositions();
		}

		#endregion
	}
