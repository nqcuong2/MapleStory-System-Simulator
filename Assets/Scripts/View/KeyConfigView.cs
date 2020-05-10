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
		STATS,
		JUMP,
		ATTACK,
		MAIN_MENU,
		MENU
	}

	[SerializeField] KeyConfigFunctionKeyView[] keyConfigFunctionKeyViews;

	[SerializeField] KeySlotView leftShiftSlot;
	[SerializeField] KeySlotView rightShiftSlot;
	[SerializeField] KeySlotView leftControlSlot;
	[SerializeField] KeySlotView rightControlSlot;
	[SerializeField] KeySlotView leftAltSlot;
	[SerializeField] KeySlotView rightAltSlot;

	private KeyConfigController keyConfigController;

	private Color TRANSPARENT_COLOR = new Color(255, 255, 255, 0);
	private Color OPAQUE_COLOR = new Color(255, 255, 255, 255);

	private void Awake()
	{
		Instance = this;
		keyConfigController = new KeyConfigController();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			keyConfigController.ExecuteActionFromPressedKey(KeyCode.LeftShift);
		}
		else if (Input.GetKeyDown(KeyCode.RightShift))
		{
			keyConfigController.ExecuteActionFromPressedKey(KeyCode.RightShift);
		}
	}

	// Update is called once per frame
	void OnGUI()
    {
		Event e = Event.current;
		if (e.type == EventType.KeyDown && e.keyCode != KeyCode.None)
		{
			keyConfigController.ExecuteActionFromPressedKey(e.keyCode);
		}
	}

	public void UpdateKey(KeySlotView selectedSlot, InteractableSprite functionKey)
	{
		var previousSlot = functionKey.CurrentSlot;
		if (previousSlot)
		{
			var prevSlotKeyCode = previousSlot.GetKeyCode();
			if (prevSlotKeyCode == KeyCode.LeftShift)
			{
				HideFunctionKeyOfSlot(rightShiftSlot);
			}
			else if (prevSlotKeyCode == KeyCode.RightShift)
			{
				HideFunctionKeyOfSlot(leftShiftSlot);
			}
			else if (prevSlotKeyCode == KeyCode.LeftControl)
			{
				HideFunctionKeyOfSlot(rightControlSlot);
			}
			else if (prevSlotKeyCode == KeyCode.RightControl)
			{
				HideFunctionKeyOfSlot(leftControlSlot);
			}
			else if (prevSlotKeyCode == KeyCode.LeftAlt)
			{
				HideFunctionKeyOfSlot(rightAltSlot);
			}
			else if (prevSlotKeyCode == KeyCode.RightAlt)
			{
				HideFunctionKeyOfSlot(leftAltSlot);
			}

			HideFunctionKeyOfSlot(previousSlot);
		}

		ShowFunctionKeyOfSlot(selectedSlot, functionKey);
		ShowFunctionKeyOfOtherModifierSlot(selectedSlot.GetKeyCode(), functionKey);

		keyConfigController.MapFunctionToKeyboardSlot(selectedSlot.GetKeyCode(), functionKey.GetFunctionType());
		selectedSlot.AssignedFunctionKey.gameObject.SetActive(false);
	}

	private void HideFunctionKeyOfSlot(KeySlotView slot)
	{
		slot.GetComponent<Image>().color = TRANSPARENT_COLOR;
		slot.AssignedFunctionKey = null;
	}

	private void ShowFunctionKeyOfSlot(KeySlotView slot, InteractableSprite functionKey)
	{
		slot.GetComponent<Image>().color = OPAQUE_COLOR;
		slot.GetComponent<Image>().sprite = functionKey.GetSprite();
		slot.AssignedFunctionKey = functionKey;
		functionKey.CurrentSlot = slot;
	}

	private void ShowFunctionKeyOfOtherModifierSlot(KeyCode keyCode, InteractableSprite functionKey)
	{
		if (keyCode == KeyCode.LeftShift)
		{
			ShowFunctionKeyOfSlot(rightShiftSlot, functionKey);
		}
		else if (keyCode == KeyCode.RightShift)
		{
			ShowFunctionKeyOfSlot(leftShiftSlot, functionKey);
		}
		else if (keyCode == KeyCode.LeftControl)
		{
			ShowFunctionKeyOfSlot(rightControlSlot, functionKey);
		}
		else if (keyCode == KeyCode.RightControl)
		{
			ShowFunctionKeyOfSlot(leftControlSlot, functionKey);
		}
		else if (keyCode == KeyCode.LeftAlt)
		{
			ShowFunctionKeyOfSlot(rightAltSlot, functionKey);
		}
		else if (keyCode == KeyCode.RightAlt)
		{
			ShowFunctionKeyOfSlot(leftAltSlot, functionKey);
		}
	}
}
