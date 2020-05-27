using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IMouseInteractable : MonoBehaviour
{
	[SerializeField] KeyConfigView.FunctionType functionType;

	public KeySlotView CurrentSlot
	{
		get;
		set;
	}

	private void Awake()
	{
		CurrentSlot = null;
	}

	public Sprite GetSprite()
	{
		return GetComponent<Image>().sprite;
	}

	//Empty function by default
	public virtual void Reset()
	{
		return; 
	}

	public KeyConfigView.FunctionType GetFunctionType()
	{
		return functionType;
	}
}
