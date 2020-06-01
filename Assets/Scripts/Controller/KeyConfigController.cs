using System;
using System.Collections.Generic;
using UnityEngine;

public class KeyConfigController
{
	#region Class Fields
	private Dictionary<int, SlotItem> keyBindingMap;
	private Dictionary<int, SlotItem> tempMap = new Dictionary<int, SlotItem>();
	private Dictionary<SlotItem.Type, Action> functionTypeToFunctionMap;

    private const int INVALID_KEYCODE = -1;
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
		keyBindingMap = new Dictionary<int, SlotItem>();
        keyBindingMap.Add((int)KeyCode.Escape, new SlotItem(null, SlotItem.Type.MAIN_MENU));
		keyBindingMap.Add((int)KeyCode.F1, null);
		keyBindingMap.Add((int)KeyCode.F2, null);
		keyBindingMap.Add((int)KeyCode.F3, null);
		keyBindingMap.Add((int)KeyCode.F4, null);
		keyBindingMap.Add((int)KeyCode.F5, null);
		keyBindingMap.Add((int)KeyCode.F6, null);
		keyBindingMap.Add((int)KeyCode.F7, null);
		keyBindingMap.Add((int)KeyCode.F8, null);
		keyBindingMap.Add((int)KeyCode.F9, null);
		keyBindingMap.Add((int)KeyCode.F10, null);
		keyBindingMap.Add((int)KeyCode.F11, null);
		keyBindingMap.Add((int)KeyCode.F12, null);
		keyBindingMap.Add((int)KeyCode.BackQuote, null);
		keyBindingMap.Add((int)KeyCode.Alpha1, null);
		keyBindingMap.Add((int)KeyCode.Alpha2, null);
		keyBindingMap.Add((int)KeyCode.Alpha3, null);
		keyBindingMap.Add((int)KeyCode.Alpha4, null);
		keyBindingMap.Add((int)KeyCode.Alpha5, null);
		keyBindingMap.Add((int)KeyCode.Alpha6, null);
		keyBindingMap.Add((int)KeyCode.Alpha7, null);
		keyBindingMap.Add((int)KeyCode.Alpha8, null);
		keyBindingMap.Add((int)KeyCode.Alpha9, null);
		keyBindingMap.Add((int)KeyCode.Alpha0, null);
		keyBindingMap.Add((int)KeyCode.Minus, null);
		keyBindingMap.Add((int)KeyCode.Equals, null);
		keyBindingMap.Add((int)KeyCode.Q, null);
		keyBindingMap.Add((int)KeyCode.W, null);
		keyBindingMap.Add((int)KeyCode.E, null);
		keyBindingMap.Add((int)KeyCode.R, null);
		keyBindingMap.Add((int)KeyCode.T, null);
		keyBindingMap.Add((int)KeyCode.Y, null);
		keyBindingMap.Add((int)KeyCode.U, null);
		keyBindingMap.Add((int)KeyCode.I, null);
		keyBindingMap.Add((int)KeyCode.O, null);
		keyBindingMap.Add((int)KeyCode.P, null);
		keyBindingMap.Add((int)KeyCode.LeftBracket, null);
		keyBindingMap.Add((int)KeyCode.RightBracket, null);
		keyBindingMap.Add((int)KeyCode.Backslash, null);
		keyBindingMap.Add((int)KeyCode.A, null);
		keyBindingMap.Add((int)KeyCode.S, null);
		keyBindingMap.Add((int)KeyCode.D, null);
		keyBindingMap.Add((int)KeyCode.F, null);
		keyBindingMap.Add((int)KeyCode.G, null);
		keyBindingMap.Add((int)KeyCode.H, null);
		keyBindingMap.Add((int)KeyCode.J, null);
		keyBindingMap.Add((int)KeyCode.K, null);
		keyBindingMap.Add((int)KeyCode.L, null);
		keyBindingMap.Add((int)KeyCode.Semicolon, null);
		keyBindingMap.Add((int)KeyCode.Quote, null);
		keyBindingMap.Add((int)KeyCode.Z, null);
		keyBindingMap.Add((int)KeyCode.X, null);
		keyBindingMap.Add((int)KeyCode.C, null);
		keyBindingMap.Add((int)KeyCode.V, null);
		keyBindingMap.Add((int)KeyCode.B, null);
		keyBindingMap.Add((int)KeyCode.N, null);
		keyBindingMap.Add((int)KeyCode.M, null);
		keyBindingMap.Add((int)KeyCode.Comma, null);
		keyBindingMap.Add((int)KeyCode.Period, null);
		keyBindingMap.Add((int)KeyCode.Space, null);
		keyBindingMap.Add(KEYCODE_SHIFT, null);
		keyBindingMap.Add(KEYCODE_CONTROL, null);
		keyBindingMap.Add(KEYCODE_ALT, null);
        keyBindingMap.Add((int)KeyCode.Insert, null);
		keyBindingMap.Add((int)KeyCode.Home, null);
		keyBindingMap.Add((int)KeyCode.PageUp, null);
		keyBindingMap.Add((int)KeyCode.Delete, null);
		keyBindingMap.Add((int)KeyCode.End, null);
		keyBindingMap.Add((int)KeyCode.PageDown, null);
	}

    public void ResetSlotItem(SlotItem selectedItem)
    {
		RemoveFunctionFromKey(selectedItem);
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

        int toRemoveKeycode = INVALID_KEYCODE;
        foreach (int keycode in keyBindingMap.Keys)
        {
            SlotItem slotItem = keyBindingMap[keycode];
            if (slotItem != null && (slotItem.SlotType == selectedItem.SlotType))
            {
                toRemoveKeycode = keycode;
                break;
            }
        }

        if (toRemoveKeycode != INVALID_KEYCODE)
        {
            DisableKey(toRemoveKeycode);
        }
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
		else if (keyBindingMap.ContainsKey(convertedKeycode))
		{
            if (keyBindingMap[convertedKeycode] != null)
            {
                functionTypeToFunctionMap[keyBindingMap[convertedKeycode].SlotType].Invoke();
            }
        }
	}

	public void SaveNewChanges()
	{
		foreach (int keycode in tempMap.Keys)
		{
			keyBindingMap[keycode] = tempMap[keycode];
		}

		ClearChanges();
	}

	public void ClearChanges()
	{
		tempMap.Clear();
	}

    public void DisableAllKeys()
    {
        foreach (int keycode in keyBindingMap.Keys)
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

        return keyBindingMap[convertedKeycode];
    }

    public bool IsTypeAssigned(SlotItem.Type type)
    {
        var map = tempMap.Count > 0 ? tempMap : keyBindingMap;
        foreach (int keycode in map.Keys)
        {
            if (map[keycode] != null && map[keycode].SlotType == type)
            {
                return true;
            }
        }

        return false;
    }
	#endregion
}
