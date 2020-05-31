using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyConfigFunctionKeyView : IMouseInteractable
{
	public override void Reset()
	{
		gameObject.SetActive(true);
	}
}
