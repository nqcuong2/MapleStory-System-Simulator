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
    private const float ANIMATION_SPEED = 3;
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
		foldButton.onClick.AddListener(() => { StartCoroutine(FoldQuickSlots()); });
		expandButton.onClick.AddListener(() => { StartCoroutine(ExpandQuickSlots()); });

		foldButton.gameObject.SetActive(false);
		expandButton.gameObject.SetActive(true);
	}

	private IEnumerator FoldQuickSlots()
	{
        float time = 0;
        while (time < ANIMATION_TIME)
        {
            time += Time.deltaTime * ANIMATION_SPEED;
            rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, foldedPos, time);
            yield return null;
        }

        foldButton.gameObject.SetActive(false);
		expandButton.gameObject.SetActive(true);
	}

	private IEnumerator ExpandQuickSlots()
	{
		float time = 0;
		while (time < ANIMATION_TIME)
		{
            time += Time.deltaTime * ANIMATION_SPEED;
            rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, expandedPos, time);
			yield return null;
		}

		foldButton.gameObject.SetActive(true);
		expandButton.gameObject.SetActive(false);
	}
}
