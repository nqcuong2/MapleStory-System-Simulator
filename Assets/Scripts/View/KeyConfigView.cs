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

    [SerializeField] KeySlotView[] keySlotViews;
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

	private Dictionary<IMouseInteractable, KeySlotView> tempSlotSpritePairs = new Dictionary<IMouseInteractable, KeySlotView>();
	private KeyConfigController keyConfigController;

    #region Methods
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
		cancel.onClick.AddListener(() => OnCancelClicked());
		ok.onClick.AddListener(() => OnOkClicked());
        clearAll.onClick.AddListener(() => OnClearAllClicked());
	}

	private void OnCancelClicked()
	{
		keyConfigController.ClearChanges();
		ResetChangedKeyBinding();
		gameObject.SetActive(false);
	}

	private void ResetChangedKeyBinding()
	{
		foreach (IMouseInteractable functionKey in tempSlotSpritePairs.Keys)
		{
			if (functionKey.CurrentSlot)
			{
				HideFunctionKeyOfSlot(functionKey.CurrentSlot);
			}

			if (tempSlotSpritePairs[functionKey])
			{
				ShowFunctionKeyOfSlot(tempSlotSpritePairs[functionKey], functionKey);
			}
			else
			{
				functionKey.Reset();
			}
		}

		tempSlotSpritePairs.Clear();
	}

	private void OnOkClicked()
	{
		keyConfigController.SaveNewChanges();
		tempSlotSpritePairs.Clear();
		gameObject.SetActive(false);
	}

    private void OnClearAllClicked()
    {
        foreach (KeySlotView slot in keySlotViews)
        {
            if (slot.AssignedFunctionKey)
            {
                SaveUnchangedKeyStatus(slot.AssignedFunctionKey);
            }
            slot.Reset();
        }

        keyConfigController.DisableAllKeys();
    }

	public void UpdateKey(KeySlotView selectedSlot, IMouseInteractable functionKey)
	{
		SaveUnchangedKeyStatus(functionKey);

		var previousSlot = functionKey.CurrentSlot;
		if (previousSlot)
		{
			HideFunctionKeyOfSlot(previousSlot);
		}

		ShowFunctionKeyOfSlot(selectedSlot, functionKey);

		keyConfigController.MapFunctionToKeyboardSlot(selectedSlot.GetKeyCode(), functionKey.GetFunctionType());
	}

	private void SaveUnchangedKeyStatus(IMouseInteractable functionKey)
	{
		if (!tempSlotSpritePairs.ContainsKey(functionKey))
		{
			tempSlotSpritePairs.Add(functionKey, functionKey.CurrentSlot);
		}
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

	private void ShowFunctionKeyOfSlot(KeySlotView slot, IMouseInteractable functionKey)
	{
		slot.UpdateFunctionKey(functionKey);
		functionKey.gameObject.SetActive(false);
		ShowFunctionKeyOfOtherModifierSlot(slot.GetKeyCode(), functionKey);
	}

	private void ShowFunctionKeyOfOtherModifierSlot(KeyCode keyCode, IMouseInteractable functionKey)
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

	public void ResetFunctionKey(IMouseInteractable functionKey)
	{
		if (functionKey.CurrentSlot)
		{
			SaveUnchangedKeyStatus(functionKey);
			keyConfigController.MapFunctionToKeyboardSlot(functionKey.CurrentSlot.GetKeyCode(), FunctionType.NONE);
			HideFunctionKeyOfSlot(functionKey.CurrentSlot);
			functionKey.Reset();
		}
	}

	public void ExecuteActionFromPressedKey(KeyCode keyCode)
	{
        keyConfigController.ExecuteActionFromPressedKey(keyCode);
	}
    #endregion

}
