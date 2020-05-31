using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IMouseInteractable : MonoBehaviour
{
	[SerializeField] SlotItem.Type type;

	public Sprite GetSprite()
	{
		return GetComponent<Image>().sprite;
	}

	//Empty function by default
	public virtual void Reset()
	{
		return; 
	}

	public new SlotItem.Type GetType()
	{
		return type;
	}
}
