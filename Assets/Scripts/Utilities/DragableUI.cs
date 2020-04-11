using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragableUI : MonoBehaviour, IPointerDownHandler, IDragHandler
{

	[SerializeField] RectTransform dragableArea;

	private RectTransform rectTransform;
	private Vector3 distanceToMouse;
	private bool canDrag;

	private void Awake()
	{
		rectTransform = GetComponentInParent<RectTransform>();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (IsPointerInDragableArea(eventData.position))
		{
			distanceToMouse = (Vector3)eventData.position - rectTransform.position;
			canDrag = true;
		}
		else
		{
			canDrag = false;
		}
	}

	private bool IsPointerInDragableArea(Vector2 pointerPos)
	{
		float minDragableXPos = rectTransform.position.x - rectTransform.sizeDelta.x / 2;
		float maxDragableXPos = rectTransform.position.x + rectTransform.sizeDelta.x / 2;
		float minDragableYPos = rectTransform.position.y + rectTransform.sizeDelta.y / 2 - dragableArea.sizeDelta.y;
		float maxDragableYPos = rectTransform.position.y + rectTransform.sizeDelta.y / 2;

		bool isInXRange = minDragableXPos < pointerPos.x && pointerPos.x < maxDragableXPos;
		bool isInYRange = minDragableYPos < pointerPos.y && pointerPos.y < maxDragableYPos;
		return isInXRange && isInYRange;
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (canDrag)
		{
			Vector3 newPos = (Vector3)eventData.position - distanceToMouse;
			if (IsNewPositionInScreen(newPos))
			{
				rectTransform.position = newPos;
			}
		}
	}

	private bool IsNewPositionInScreen(Vector3 newPos)
	{
		return newPos.x > 0 &&
			   newPos.x < Camera.main.pixelWidth &&
			   newPos.y < Camera.main.pixelHeight - rectTransform.sizeDelta.y / 2 &&
			   newPos.y > 0;
	}
}
