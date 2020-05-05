using System;
using System.Collections.Generic;
using UnityEngine;

public class KeyConfigController
{
	Dictionary<KeyConfigView.FunctionType, KeyCode> inputKeyToFunctionTypeMap;
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
		inputKeyToFunctionTypeMap = new Dictionary<KeyConfigView.FunctionType, KeyCode>();
	}

	private void ToggleStatsWindow()
	{
		MainStatsView.Instance.ToggleWindow();
	}

	public void MapFunctionToKeyboardSlot(KeyConfigView.FunctionType functionType, KeyCode keyCode)
	{
		if (inputKeyToFunctionTypeMap.ContainsKey(functionType))
		{
			inputKeyToFunctionTypeMap[functionType] = keyCode;
		}
		else
		{
			inputKeyToFunctionTypeMap.Add(functionType, keyCode);
		}
	}

	public void ExecuteActionFromPressedKey(KeyCode keyCode)
	{
		foreach (KeyConfigView.FunctionType functionType in inputKeyToFunctionTypeMap.Keys)
		{
			if (inputKeyToFunctionTypeMap[functionType] == keyCode)
			{
				functionTypeToFunctionMap[functionType].Invoke();
				return;
			}
		}
	}
}
