using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyConfigView : MonoBehaviour
{
	public static KeyConfigView Instance { get; private set; }

	public enum FunctionType
	{
		NONE,
		MAIN_MENU,
		SAY,
		EQUIPMENT,
		ITEMS,
		CHAR_INFO,
		STATS,
		SKILLS,
		QUEST,
		MENU,
		QUICK_SLOTS,
		PICKUP,
		SIT,
		ATTACK,
		JUMP,
		INTERACT,
		SOUL_WEAPON,
		WORLD_MAP,
		MINIMAP,
		KEY_BINDING,
		MONSTER_BOOK,
		EXPRESSION
	}

	[SerializeField] KeyConfigFunctionKeyView[] keyConfigFunctionKeyViews;

	[SerializeField] KeySlotView leftShiftSlot;
	[SerializeField] KeySlotView rightShiftSlot;
	[SerializeField] KeySlotView leftControlSlot;
	[SerializeField] KeySlotView rightControlSlot;
	[SerializeField] KeySlotView leftAltSlot;
	[SerializeField] KeySlotView rightAltSlot;

	[SerializeField] Button defaultSetup;
	[SerializeField] Button clearAll;
	[SerializeField] Button ok;
	[SerializeField] Button cancel;

	private KeyConfigController keyConfigController;

	private void Awake()
	{
		Instance = this;
		keyConfigController = new KeyConfigController();
	}

	// Start is called before the first frame update
	void Start()
    {
		SetupButtons();
	}

	private void SetupButtons()
	{
		
	}

	// Update is called once per frame
	public void UpdateKey(KeySlotView selectedSlot, InteractableSprite functionKey)
	{
		var previousSlot = functionKey.CurrentSlot;
		if (previousSlot)
		{
			HideFunctionKeyOfSlot(previousSlot);
		}

		ShowFunctionKeyOfSlot(selectedSlot, functionKey);

		InputManager.Instance.UpdateKeyMapping(selectedSlot.GetKeyCode(), functionKey.GetFunctionType());
		selectedSlot.AssignedFunctionKey.gameObject.SetActive(false);
	}

	private void HideFunctionKeyOfSlot(KeySlotView slot)
	{
		slot.Reset();
		HideFunctionKeyOfOtherModifierSlot(slot.GetKeyCode());
	}

	private void HideFunctionKeyOfOtherModifierSlot(KeyCode keyCode)
	{
		switch (keyCode)
		{
			case KeyCode.LeftShift:
				rightShiftSlot.Reset();
				break;
			case KeyCode.RightShift:
				leftShiftSlot.Reset();
				break;
			case KeyCode.LeftControl:
				rightControlSlot.Reset();
				break;
			case KeyCode.RightControl:
				leftControlSlot.Reset();
				break;
			case KeyCode.LeftAlt:
				rightAltSlot.Reset();
				break;
			case KeyCode.RightAlt:
				leftAltSlot.Reset();
				break;
		}
	}

	private void ShowFunctionKeyOfSlot(KeySlotView slot, InteractableSprite functionKey)
	{
		slot.UpdateFunctionKey(functionKey);
		ShowFunctionKeyOfOtherModifierSlot(slot.GetKeyCode(), functionKey);
	}

	private void ShowFunctionKeyOfOtherModifierSlot(KeyCode keyCode, InteractableSprite functionKey)
	{
		switch (keyCode)
		{
			case KeyCode.LeftShift:
				rightShiftSlot.UpdateFunctionKey(functionKey);
				break;
			case KeyCode.RightShift:
				leftShiftSlot.UpdateFunctionKey(functionKey);
				break;
			case KeyCode.LeftControl:
				rightControlSlot.UpdateFunctionKey(functionKey);
				break;
			case KeyCode.RightControl:
				leftControlSlot.UpdateFunctionKey(functionKey);
				break;
			case KeyCode.LeftAlt:
				rightAltSlot.UpdateFunctionKey(functionKey);
				break;
			case KeyCode.RightAlt:
				leftAltSlot.UpdateFunctionKey(functionKey);
				break;
		}
	}

	public void ResetFunctionKey(InteractableSprite functionKey)
	{
		if (functionKey.CurrentSlot)
		{
			InputManager.Instance.UpdateKeyMapping(functionKey.CurrentSlot.GetKeyCode(), FunctionType.NONE);
			HideFunctionKeyOfSlot(functionKey.CurrentSlot);
			functionKey.Reset();
		}
	}
}
