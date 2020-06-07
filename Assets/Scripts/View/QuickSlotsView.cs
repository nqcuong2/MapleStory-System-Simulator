using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuickSlotsView : MonoBehaviour
{
	[SerializeField] private Button toggleButton;
    [SerializeField] private SlotView[] slots;

    public static QuickSlotsView Instance
	{
		get;
		private set;
	}

	private RectTransform rectTransform;
	private Vector2 foldedPos;
	private Vector2 expandedPos;
	private const float ANIMATION_TIME = 1.5f;
    private const float ANIMATION_SPEED = 2.5f;

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
        toggleButton.onClick.AddListener(() => { StartCoroutine(ToggleQuickSlots()); });
	}

	private IEnumerator ToggleQuickSlots()
	{
        Vector2 dest = (Mathf.RoundToInt(rectTransform.anchoredPosition.x) == (int)(foldedPos.x)) ? expandedPos : foldedPos;
        float time = 0;
        while (time < ANIMATION_TIME)
        {
            time += Time.deltaTime * ANIMATION_SPEED;
            rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, dest, time);
            yield return null;
        }
    }

    public bool IsSlotInQuickSlots(SlotView slot)
    {
        foreach (SlotView currSlot in slots)
        {
            if (slot == currSlot)
                return true;
        }

        return false;
    }

    public SlotView[] GetSlots()
    {
        return slots;
    }
}
