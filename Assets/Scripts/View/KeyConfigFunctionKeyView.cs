using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyConfigFunctionKeyView : InteractableSprite
{
	public override void Reset()
	{
		gameObject.SetActive(true);
		CurrentSlot = null;
	}
}
