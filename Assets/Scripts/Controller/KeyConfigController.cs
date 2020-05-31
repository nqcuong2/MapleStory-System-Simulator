using System;
using System.Collections.Generic;
using UnityEngine;

public class KeyConfigController
{
	#region Class Fields
	private Dictionary<int, SlotItem> inputKeyToFunctionTypeMap;
	private Dictionary<int, SlotItem> tempMap = new Dictionary<int, SlotItem>();
	private Dictionary<SlotItem.Type, Action> functionTypeToFunctionMap;

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
		functionTypeToFunctionMap = new Dictionary<SlotItem.Type, Action>();
		functionTypeToFunctionMap.Add(SlotItem.Type.NONE, () => { });
		functionTypeToFunctionMap.Add(SlotItem.Type.MAIN_MENU, () => { UnityEditor.EditorApplication.isPlaying = false; });
		functionTypeToFunctionMap.Add(SlotItem.Type.STATS, () => ToggleStatsWindow());
		functionTypeToFunctionMap.Add(SlotItem.Type.KEY_BINDING, () => ToggleKeyBindingWindow());
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
		inputKeyToFunctionTypeMap = new Dictionary<int, SlotItem>();
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Escape, new SlotItem(null, SlotItem.Type.MAIN_MENU));
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F1, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F2, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F3, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F4, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F5, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F6, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F7, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F8, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F9, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F10, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F11, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F12, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.BackQuote, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Alpha1, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Alpha2, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Alpha3, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Alpha4, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Alpha5, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Alpha6, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Alpha7, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Alpha8, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Alpha9, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Alpha0, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Minus, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Equals, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Q, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.W, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.E, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.R, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.T, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Y, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.U, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.I, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.O, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.P, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.LeftBracket, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.RightBracket, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Backslash, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.A, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.S, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.D, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.F, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.G, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.H, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.J, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.K, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.L, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Semicolon, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Quote, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Z, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.X, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.C, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.V, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.B, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.N, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.M, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Comma, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Period, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Space, null);
		inputKeyToFunctionTypeMap.Add(KEYCODE_SHIFT, null);
		inputKeyToFunctionTypeMap.Add(KEYCODE_CONTROL, null);
		inputKeyToFunctionTypeMap.Add(KEYCODE_ALT, null);
        inputKeyToFunctionTypeMap.Add((int)KeyCode.Insert, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Home, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.PageUp, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.Delete, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.End, null);
		inputKeyToFunctionTypeMap.Add((int)KeyCode.PageDown, null);
	}

	public void MapFunctionToKeyboardSlot(KeyCode keycode, SlotItem selectedItem)
	{
        int convertedKeycode = ConvertKeyCodeToInt(keycode);
		RemoveFunctionFromKey(selectedItem);
        AddItemToKey(convertedKeycode, selectedItem);
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

	private void RemoveFunctionFromKey(SlotItem selectedItem)
	{
        foreach (int keycode in tempMap.Keys)
        {
            SlotItem slotItem = tempMap[keycode];
            if (slotItem != null && (slotItem.SlotType == selectedItem.SlotType))
            {
                tempMap[keycode] = null;
                return;
            }
        }

        int toRemoveKeycode = -1;
        foreach (int keycode in inputKeyToFunctionTypeMap.Keys)
        {
            SlotItem slotItem = inputKeyToFunctionTypeMap[keycode];
            if (slotItem != null && (slotItem.SlotType == selectedItem.SlotType))
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
            tempMap[keycode] = null;
        }
        else
        {
            tempMap.Add(keycode, null);
        }
    }

	private void AddItemToKey(int keyCode, SlotItem selectedItem)
	{
        if (tempMap.ContainsKey(keyCode))
        {
            tempMap[keyCode] = selectedItem;
        }
        else
        {
            tempMap.Add(keyCode, selectedItem);
        }
    }

	public void ExecuteActionFromPressedKey(KeyCode keyCode)
	{
        int convertedKeycode = ConvertKeyCodeToInt(keyCode);
        if (tempMap.ContainsKey(convertedKeycode))
		{
            if (tempMap[convertedKeycode] != null)
            {
                functionTypeToFunctionMap[tempMap[convertedKeycode].SlotType].Invoke();
            }
        }
		else if (inputKeyToFunctionTypeMap.ContainsKey(convertedKeycode))
		{
            if (inputKeyToFunctionTypeMap[convertedKeycode] != null)
            {
                functionTypeToFunctionMap[inputKeyToFunctionTypeMap[convertedKeycode].SlotType].Invoke();
            }
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

    public SlotItem GetSlotItem(KeyCode keyCode)
    {
        int convertedKeycode = ConvertKeyCodeToInt(keyCode);
        if (tempMap.ContainsKey(convertedKeycode))
        {
            return tempMap[convertedKeycode];
        }

        return inputKeyToFunctionTypeMap[convertedKeycode];
    }

    public bool IsTypeAssigned(SlotItem.Type type)
    {
        var toCheckMap = tempMap.Count > 0 ? tempMap : inputKeyToFunctionTypeMap;
        foreach (SlotItem slotItem in tempMap.Values)
        {
            if (slotItem != null && slotItem.SlotType == type)
            {
                return true;
            }
        }

        return false;
    }
	#endregion
}
