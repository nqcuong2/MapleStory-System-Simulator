using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuickSlotsView : MonoBehaviour
{
	[SerializeField] Button foldButton;
	[SerializeField] Button expandButton;

	public QuickSlotsView Instance
	{
		get;
		private set;
	}

	private RectTransform rectTransform;
	private Vector2 foldedPos;
	private Vector2 expandedPos;
	private const float ANIMATION_TIME = 1.5f;
	private bool isAnimationRunning;

	private QuickSlotsView() {}

	private void Awake()
	{
		Instance = this;
		rectTransform = GetComponent<RectTransform>();
		foldedPos = rectTransform.anchoredPosition;
		expandedPos = foldedPos - new Vector2(211, 0);
	}

	private void Start()
	{
		SetupButtons();
	}

	private void SetupButtons()
	{
		foldButton.onClick.AddListener(() => { isAnimationRunning = true; });//StartCoroutine(FoldQuickSlots()));
		expandButton.onClick.AddListener(() => { isAnimationRunning = true; }); //StartCoroutine(ExpandQuickSlots()));

		foldButton.gameObject.SetActive(false);
		expandButton.gameObject.SetActive(true);
	}

	private IEnumerator FoldQuickSlots()
	{
		float startTime = Time.deltaTime;
		while (Time.time < startTime + ANIMATION_TIME)
		{
			rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, foldedPos, (Time.time - startTime) / ANIMATION_TIME);
			yield return null;
		}

		foldButton.gameObject.SetActive(false);
		expandButton.gameObject.SetActive(true);
	}

	private IEnumerator ExpandQuickSlots()
	{
		float startTime = 0;
		while (startTime < ANIMATION_TIME)
		{
			rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, expandedPos, (Time.time - startTime) / ANIMATION_TIME);
			yield return null;
		}

		//rectTransform.anchoredPosition = expandedPos;

		foldButton.gameObject.SetActive(true);
		expandButton.gameObject.SetActive(false);
	}

	private void Update()
	{
		if (isAnimationRunning)
		{
			if (foldButton.gameObject.activeSelf)
			{
				rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, foldedPos, Time.deltaTime * 600f);

				if (rectTransform.anchoredPosition.x >= foldedPos.x)
				{
					isAnimationRunning = false;
					foldButton.gameObject.SetActive(false);
					expandButton.gameObject.SetActive(true);
				}
			}
			else
			{
				rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, expandedPos, Time.deltaTime * 600f);

				if (rectTransform.anchoredPosition.x <= expandedPos.x)
				{
					isAnimationRunning = false;
					foldButton.gameObject.SetActive(true);
					expandButton.gameObject.SetActive(false);
				}
			}
		}
	}
}
