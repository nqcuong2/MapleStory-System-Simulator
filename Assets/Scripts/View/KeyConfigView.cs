using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyConfigView : MonoBehaviour
{
	public static KeyConfigView Instance { get; private set; }

    [SerializeField] SlotView[] slots;
	[SerializeField] KeyConfigFunctionKeyView[] keyConfigFunctionKeyViews;

	[SerializeField] SlotView leftShiftSlot;
	[SerializeField] SlotView rightShiftSlot;
	[SerializeField] SlotView leftControlSlot;
	[SerializeField] SlotView rightControlSlot;
	[SerializeField] SlotView leftAltSlot;
	[SerializeField] SlotView rightAltSlot;

	[SerializeField] Button defaultSetup;
	[SerializeField] Button clearAll;
	[SerializeField] Button ok;
	[SerializeField] Button cancel;

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
        UpdateAllSlots();
        UpdateAllFunctionItems();
        gameObject.SetActive(false);
	}

	private void OnOkClicked()
	{
		keyConfigController.SaveNewChanges();
		gameObject.SetActive(false);
	}

    private void OnClearAllClicked()
    {
        keyConfigController.DisableAllKeys();
        UpdateAllSlots();
        UpdateAllFunctionItems();
    }

    private void UpdateAllSlots()
    {
        foreach (SlotView slot in slots)
        {
            Sprite sprite = keyConfigController.GetSlotItem(slot.GetKeyCode())?.SlotSprite;
            slot.UpdateSprite(sprite);
        }
    }

    private void UpdateAllFunctionItems()
    {
        foreach (KeyConfigFunctionKeyView keyConfigFunctionKeyView in keyConfigFunctionKeyViews)
        {
            if (keyConfigController.IsTypeAssigned(keyConfigFunctionKeyView.GetType()))
            {
                keyConfigFunctionKeyView.gameObject.SetActive(false);
            }
            else
            {
                keyConfigFunctionKeyView.Reset();
            }
        }
    }

	public void MapSlot(SlotView selectedSlot, SlotItem selectedItem)
	{
        SlotItem oldSlotItem = keyConfigController.GetSlotItem(selectedSlot.GetKeyCode());
        if (selectedItem != oldSlotItem)
        {
            keyConfigController.MapFunctionToKeyboardSlot(selectedSlot.GetKeyCode(), selectedItem);
            UpdateAllSlots();
            UpdateAllFunctionItems();
        }
    }

	public void ResetFunctionKey(SlotItem selectedItem)
	{
		//if (selectedItem.CurrentSlot)
		//{
  //          //SaveUnchangedKeyStatus(selectedItem);
  //          keyConfigController.MapFunctionToKeyboardSlot(functionKey.CurrentSlot.GetKeyCode(), FunctionType.NONE);
  //          HideFunctionKeyOfSlot(selectedItem.CurrentSlot);
  //          selectedItem.Reset();
		//}
	}

	public void ExecuteActionFromPressedKey(KeyCode keyCode)
	{
        keyConfigController.ExecuteActionFromPressedKey(keyCode);
	}

    public bool IsSlotInKeyConfig(SlotView slot)
    {
        foreach (SlotView currSlot in slots)
        {
            if (slot == currSlot)
                return true;
        }

        return false;
    }

    public SlotItem GetSelectedSlotItem(SlotView slot)
    {
        return keyConfigController.GetSlotItem(slot.GetKeyCode());
    }
    #endregion

}
