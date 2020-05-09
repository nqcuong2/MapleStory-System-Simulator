using System;
using System.Collections.Generic;
using UnityEngine;

public class KeyConfigController
{
	Dictionary<KeyCode, KeyConfigView.FunctionType> inputKeyToFunctionTypeMap;
	Dictionary<KeyConfigView.FunctionType, Action> functionTypeToFunctionMap;

	public KeyConfigController()
	{
		IntializeFunctionTypeToFunctionMap();
		InitializeKeyToFunctionMap();
	}

	private void IntializeFunctionTypeToFunctionMap()
	{
		functionTypeToFunctionMap = new Dictionary<KeyConfigView.FunctionType, Action>();
		functionTypeToFunctionMap.Add(KeyConfigView.FunctionType.STATS, () => ToggleStatsWindow());
		//functionMap.Add(KeyConfigView)
	}

	private void InitializeKeyToFunctionMap()
	{
		inputKeyToFunctionTypeMap = new Dictionary<KeyCode, KeyConfigView.FunctionType>();
	}

	private void ToggleStatsWindow()
	{
		GameObjectUtils.ToggleWindow(MainStatsView.Instance.gameObject);
	}

	public void MapFunctionToKeyboardSlot(KeyCode keyCode, KeyConfigView.FunctionType functionType)
	{
		RemoveFunctionFromPreviousSlot(functionType);
		AddFunctionToNewSlot(keyCode, functionType);
	}

	private void RemoveFunctionFromPreviousSlot(KeyConfigView.FunctionType functionType)
	{
		foreach (KeyCode key in inputKeyToFunctionTypeMap.Keys)
		{
			if (inputKeyToFunctionTypeMap[key] == functionType)
			{
				inputKeyToFunctionTypeMap.Remove(key);
				switch (key)
				{
					case KeyCode.LeftShift:
						inputKeyToFunctionTypeMap.Remove(KeyCode.RightShift);
						break;
					case KeyCode.RightShift:
						inputKeyToFunctionTypeMap.Remove(KeyCode.LeftShift);
						break;
					case KeyCode.LeftControl:
						inputKeyToFunctionTypeMap.Remove(KeyCode.RightControl);
						break;
					case KeyCode.RightControl:
						inputKeyToFunctionTypeMap.Remove(KeyCode.LeftControl);
						break;
					case KeyCode.LeftAlt:
						inputKeyToFunctionTypeMap.Remove(KeyCode.RightAlt);
						break;
					case KeyCode.RightAlt:
						inputKeyToFunctionTypeMap.Remove(KeyCode.LeftAlt);
						break;
				}
				
				break;
			}
		}
	}

	private void AddFunctionToNewSlot(KeyCode keyCode, KeyConfigView.FunctionType functionType)
	{
		if (inputKeyToFunctionTypeMap.ContainsKey(keyCode))
		{
			inputKeyToFunctionTypeMap[keyCode] = functionType;
			switch (keyCode)
			{
				case KeyCode.LeftShift:
					inputKeyToFunctionTypeMap[KeyCode.RightShift] = functionType;
					break;
				case KeyCode.RightShift:
					inputKeyToFunctionTypeMap[KeyCode.LeftShift] = functionType;
					break;
				case KeyCode.LeftControl:
					inputKeyToFunctionTypeMap[KeyCode.RightControl] = functionType;
					break;
				case KeyCode.RightControl:
					inputKeyToFunctionTypeMap[KeyCode.LeftControl] = functionType;
					break;
				case KeyCode.LeftAlt:
					inputKeyToFunctionTypeMap[KeyCode.RightAlt] = functionType;
					break;
				case KeyCode.RightAlt:
					inputKeyToFunctionTypeMap[KeyCode.LeftAlt] = functionType;
					break;
			}
		}
		else
		{
			inputKeyToFunctionTypeMap.Add(keyCode, functionType);
			switch (keyCode)
			{
				case KeyCode.LeftShift:
					inputKeyToFunctionTypeMap.Add(KeyCode.RightShift, functionType);
					break;
				case KeyCode.RightShift:
					inputKeyToFunctionTypeMap.Add(KeyCode.LeftShift, functionType);
					break;
				case KeyCode.LeftControl:
					inputKeyToFunctionTypeMap.Add(KeyCode.RightControl, functionType);
					break;
				case KeyCode.RightControl:
					inputKeyToFunctionTypeMap.Add(KeyCode.LeftControl, functionType);
					break;
				case KeyCode.LeftAlt:
					inputKeyToFunctionTypeMap.Add(KeyCode.RightAlt, functionType);
					break;
				case KeyCode.RightAlt:
					inputKeyToFunctionTypeMap.Add(KeyCode.LeftAlt, functionType);
					break;
			}
		}
	}

	public void ExecuteActionFromPressedKey(KeyCode keyCode)
	{
		if (inputKeyToFunctionTypeMap.ContainsKey(keyCode))
		{
			functionTypeToFunctionMap[inputKeyToFunctionTypeMap[keyCode]].Invoke();
		}
	}
}
