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
        UpdateKeyConfig();
        gameObject.SetActive(false);
    }

    private void UpdateKeyConfig()
    {
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

    private void OnOkClicked()
	{
		keyConfigController.SaveNewChanges();
		gameObject.SetActive(false);
	}

    private void OnClearAllClicked()
    {
        keyConfigController.DisableAllKeys();
        UpdateKeyConfig();
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

            foreach (KeyConfigFunctionKeyView keyConfigFunctionKeyView in keyConfigFunctionKeyViews)
            {
                if (keyConfigFunctionKeyView.GetType() == selectedItem.SlotType)
                {
                    keyConfigFunctionKeyView.gameObject.SetActive(false);
                }
            }

            if (oldSlotItem != null)
            {
                ResetFunctionKey(oldSlotItem.SlotType);
            }
        }
    }

    private void ResetFunctionKey(SlotItem.Type type)
    {
        foreach (KeyConfigFunctionKeyView keyConfigFunctionKeyView in keyConfigFunctionKeyViews)
        {
            if (keyConfigFunctionKeyView.GetType() == type)
            {
                keyConfigFunctionKeyView.Reset();
            }
        }
    }

	public void ResetSlot(SlotItem selectedItem)
	{
        keyConfigController.ResetSlotItem(selectedItem);
        UpdateAllSlots();
        ResetFunctionKey(selectedItem.SlotType);
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
