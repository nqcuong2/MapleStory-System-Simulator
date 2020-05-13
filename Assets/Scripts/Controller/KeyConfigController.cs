using System;
using System.Collections.Generic;
using UnityEngine;

public class KeyConfigController
{
	#region Class Fields
	private Dictionary<KeyCode, KeyConfigView.FunctionType> inputKeyToFunctionTypeMap;
	private Dictionary<KeyCode, KeyConfigView.FunctionType> tempMap = new Dictionary<KeyCode, KeyConfigView.FunctionType>();
	private Dictionary<KeyConfigView.FunctionType, Action> functionTypeToFunctionMap;
	#endregion

	#region Constructor
	public KeyConfigController()
	{
		IntializeFunctionTypeToFunctionMap();
		InitializeKeyToFunctionMap();
	}
	#endregion

	#region Methods
	private void IntializeFunctionTypeToFunctionMap()
	{
		functionTypeToFunctionMap = new Dictionary<KeyConfigView.FunctionType, Action>();
		functionTypeToFunctionMap.Add(KeyConfigView.FunctionType.NONE, () => { });
		functionTypeToFunctionMap.Add(KeyConfigView.FunctionType.MAIN_MENU, () => { UnityEditor.EditorApplication.isPlaying = false; });
		functionTypeToFunctionMap.Add(KeyConfigView.FunctionType.STATS, () => ToggleStatsWindow());
		functionTypeToFunctionMap.Add(KeyConfigView.FunctionType.KEY_BINDING, () => ToggleKeyBindingWindow());
	}

	private void ToggleStatsWindow()
	{
		GameObjectUtils.ToggleWindow(MainStatsView.Instance.gameObject);
	}

	private void ToggleKeyBindingWindow()
	{
		GameObjectUtils.ToggleWindow(KeyConfigView.Instance.gameObject);
	}

	private void InitializeKeyToFunctionMap()
	{
		inputKeyToFunctionTypeMap = new Dictionary<KeyCode, KeyConfigView.FunctionType>();
		inputKeyToFunctionTypeMap.Add(KeyCode.Escape, KeyConfigView.FunctionType.MAIN_MENU);
		inputKeyToFunctionTypeMap.Add(KeyCode.F1, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.F2, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.F3, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.F4, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.F5, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.F6, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.F7, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.F8, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.F9, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.F10, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.F11, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.F12, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.BackQuote, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Alpha1, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Alpha2, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Alpha3, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Alpha4, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Alpha5, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Alpha6, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Alpha7, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Alpha8, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Alpha9, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Alpha0, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Minus, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Equals, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Q, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.W, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.E, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.R, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.T, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Y, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.U, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.I, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.O, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.P, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.LeftBracket, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.RightBracket, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Backslash, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.A, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.S, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.D, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.F, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.G, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.H, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.J, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.K, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.L, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Semicolon, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Quote, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Z, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.X, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.C, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.V, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.B, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.N, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.M, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Comma, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Period, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Space, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.LeftShift, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.RightShift, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.LeftControl, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.RightControl, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.LeftAlt, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.RightAlt, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Insert, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Home, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.PageUp, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.Delete, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.End, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KeyCode.PageDown, KeyConfigView.FunctionType.NONE);
	}

	public void MapFunctionToKeyboardSlot(KeyCode keyCode, KeyConfigView.FunctionType functionType)
	{
		RemoveFunctionFromKey(keyCode);
		AddFunctionToKey(keyCode, functionType);
	}

	private void RemoveFunctionFromKey(KeyCode keyCode)
	{
		if (tempMap.ContainsKey(keyCode))
		{
			tempMap[keyCode] = KeyConfigView.FunctionType.NONE;
		}
		else
		{
			tempMap.Add(keyCode, KeyConfigView.FunctionType.NONE);
		}
	}

	private void AddFunctionToKey(KeyCode keyCode, KeyConfigView.FunctionType functionType)
	{
		if (tempMap.ContainsKey(keyCode))
		{
			tempMap[keyCode] = functionType;
		}
		else
		{
			tempMap.Add(keyCode, functionType);
		}
	}

	public void ExecuteActionFromPressedKey(KeyCode keyCode)
	{
		if (tempMap.ContainsKey(keyCode))
		{
			functionTypeToFunctionMap[tempMap[keyCode]].Invoke();
		}
		else if (inputKeyToFunctionTypeMap.ContainsKey(keyCode))
		{
			functionTypeToFunctionMap[inputKeyToFunctionTypeMap[keyCode]].Invoke();
		}
	}

	public void SaveNewChanges()
	{
		foreach (KeyCode key in tempMap.Keys)
		{
			inputKeyToFunctionTypeMap[key] = tempMap[key];
			switch (key)
			{
				case KeyCode.LeftShift:
					inputKeyToFunctionTypeMap[KeyCode.RightShift] = tempMap[key];
					break;
				case KeyCode.RightShift:
					inputKeyToFunctionTypeMap[KeyCode.LeftShift] = tempMap[key];
					break;
				case KeyCode.LeftControl:
					inputKeyToFunctionTypeMap[KeyCode.RightControl] = tempMap[key];
					break;
				case KeyCode.RightControl:
					inputKeyToFunctionTypeMap[KeyCode.LeftControl] = tempMap[key];
					break;
				case KeyCode.LeftAlt:
					inputKeyToFunctionTypeMap[KeyCode.RightAlt] = tempMap[key];
					break;
				case KeyCode.RightAlt:
					inputKeyToFunctionTypeMap[KeyCode.LeftAlt] = tempMap[key];
					break;
			}
		}

		ClearChanges();
	}

	public void ClearChanges()
	{
		tempMap.Clear();
	}
	#endregion
}
