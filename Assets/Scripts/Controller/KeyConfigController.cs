using System;
using System.Collections.Generic;
using UnityEngine;

public class KeyConfigController
{
	#region Class Fields
	private Dictionary<int, KeyConfigView.FunctionType> inputKeyToFunctionTypeMap;
	private Dictionary<int, KeyConfigView.FunctionType> tempMap = new Dictionary<int, KeyConfigView.FunctionType>();
	private Dictionary<KeyConfigView.FunctionType, Action> functionTypeToFunctionMap;

    private const int KEYCODE_SHIFT = 1000;
    private const int KEYCODE_ALT = 1001;
    private const int KEYCODE_CONTROL = 1002;
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
		inputKeyToFunctionTypeMap = new Dictionary<int, KeyConfigView.FunctionType>();
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Escape, KeyConfigView.FunctionType.MAIN_MENU);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F1, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F2, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F3, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F4, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F5, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F6, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F7, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F8, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F9, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F10, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F11, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F12, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.BackQuote, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Alpha1, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Alpha2, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Alpha3, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Alpha4, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Alpha5, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Alpha6, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Alpha7, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Alpha8, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Alpha9, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Alpha0, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Minus, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Equals, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Q, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.W, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.E, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.R, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.T, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Y, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.U, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.I, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.O, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.P, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.LeftBracket, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.RightBracket, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Backslash, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.A, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.S, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.D, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.G, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.H, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.J, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.K, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.L, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Semicolon, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Quote, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Z, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.X, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.C, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.V, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.B, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.N, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.M, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Comma, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Period, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Space, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KEYCODE_SHIFT, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KEYCODE_CONTROL, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add(KEYCODE_ALT, KeyConfigView.FunctionType.NONE);
        inputKeyToFunctionTypeMap.Add((int)KeyCode.Insert, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Home, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.PageUp, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Delete, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.End, KeyConfigView.FunctionType.NONE);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.PageDown, KeyConfigView.FunctionType.NONE);
	}

	public void MapFunctionToKeyboardSlot(KeyCode keycode, KeyConfigView.FunctionType functionType)
	{
        int convertedKeycode = ConvertKeyCodeToInt(keycode);
		RemoveFunctionFromKey(functionType);
		AddFunctionToKey(convertedKeycode, functionType);
	}

    private int ConvertKeyCodeToInt(KeyCode keycode)
    {
        if (keycode == KeyCode.LeftShift || keycode == KeyCode.RightShift)
        {
            return KEYCODE_SHIFT;
        }
        else if (keycode == KeyCode.LeftControl || keycode == KeyCode.RightControl)
        {
            return KEYCODE_CONTROL;
        }
        else if (keycode == KeyCode.LeftAlt || keycode == KeyCode.RightAlt)
        {
            return KEYCODE_ALT;
        }
        else
        {
            return (int)keycode;
        }
    }

	private void RemoveFunctionFromKey(KeyConfigView.FunctionType functionType)
	{
        foreach (int keycode in tempMap.Keys)
        {
            if (tempMap[keycode] == functionType)
            {
                tempMap[keycode] = KeyConfigView.FunctionType.NONE;
                return;
            }
        }

        int toRemoveKeycode = -1;
        foreach (int keycode in inputKeyToFunctionTypeMap.Keys)
        {
            if (inputKeyToFunctionTypeMap[keycode] == functionType)
            {
                toRemoveKeycode = keycode;
                break;
            }
        }

        DisableKey(toRemoveKeycode);
    }

    private void DisableKey(int keycode)
    {
        if (tempMap.ContainsKey(keycode))
        {
            tempMap[keycode] = KeyConfigView.FunctionType.NONE;
        }
        else
        {
            tempMap.Add(keycode, KeyConfigView.FunctionType.NONE);
        }
    }

	private void AddFunctionToKey(int keyCode, KeyConfigView.FunctionType functionType)
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
        int convertedKeycode = ConvertKeyCodeToInt(keyCode);
        if (tempMap.ContainsKey(convertedKeycode))
		{
			functionTypeToFunctionMap[tempMap[convertedKeycode]].Invoke();
		}
		else if (inputKeyToFunctionTypeMap.ContainsKey(convertedKeycode))
		{
			functionTypeToFunctionMap[inputKeyToFunctionTypeMap[convertedKeycode]].Invoke();
		}
	}

	public void SaveNewChanges()
	{
		foreach (int keycode in tempMap.Keys)
		{
			inputKeyToFunctionTypeMap[keycode] = tempMap[keycode];
		}

		ClearChanges();
	}

	public void ClearChanges()
	{
		tempMap.Clear();
	}

    public void DisableAllKeys()
    {
        foreach (int keycode in inputKeyToFunctionTypeMap.Keys)
        {
            DisableKey(keycode);
        }
    }
	#endregion
}
