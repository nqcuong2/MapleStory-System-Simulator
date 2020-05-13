using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : Button
{
	public override void OnPointerClick(PointerEventData eventData)
	{
		base.OnPointerClick(eventData);
		GameObjectUtils.UnfocusButton();
	}
}
