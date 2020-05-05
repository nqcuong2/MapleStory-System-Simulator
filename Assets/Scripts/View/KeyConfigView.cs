using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyConfigView : MonoBehaviour
{
	public static KeyConfigView Instance { get; private set; }

	public enum FunctionType
	{
		STATS,
		JUMP,
		ATTACK,
		MAIN_MENU,
		MENU
	}

	[SerializeField] GameObject keySlotHolder;
	[SerializeField] GameObject[] keySlots;
	[SerializeField] KeyConfigFunctionKeyView[] keyConfigFunctionKeyViews;

	private KeyConfigController keyConfigController;

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
		if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
		{
			keyConfigController.ExecuteActionFromPressedKey(KeyCode.LeftShift);
		}
	}

	// Update is called once per frame
	void OnGUI()
    {
		Event e = Event.current;
		if (e.type == EventType.KeyDown && e.keyCode != KeyCode.None)
		{
			//if (e.keyCode == KeyCode.LeftAlt || e.keyCode == KeyCode.RightAlt)
			//{
			//	keyConfigController.ExecuteActionFromPressedKey(KeyCode.LeftAlt);
			//}
			//else if (e.keyCode == KeyCode.LeftControl || e.keyCode == KeyCode.RightControl)
			//{
			//	keyConfigController.ExecuteActionFromPressedKey(KeyCode.LeftControl);
			//}
			//else if ()
			//{
				keyConfigController.ExecuteActionFromPressedKey(e.keyCode);
			//}
		}
	}

	public void UpdateKey(KeySlotView selectedKey, KeyConfigFunctionKeyView function)
	{
		function.transform.localPosition = selectedKey.transform.localPosition;
		keyConfigController.MapFunctionToKeyboardSlot(function.GetFunctionType(), selectedKey.GetKeyCode());
	}
}
