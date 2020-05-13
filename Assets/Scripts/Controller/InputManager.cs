using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	public static InputManager Instance { get; private set; }

	private KeyConfigController keyConfigController;

	private InputManager() { keyConfigController = new KeyConfigController(); }

	private void Awake()
	{
		Instance = this;
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

	private void OnGUI()
	{
		Event e = Event.current;
		if (e.type == EventType.KeyDown && e.keyCode != KeyCode.None)
		{
			keyConfigController.ExecuteActionFromPressedKey(e.keyCode);
		}
	}

	public void UpdateKeyMapping(KeyCode keyCode, KeyConfigView.FunctionType functionType)
	{
		keyConfigController.MapFunctionToKeyboardSlot(keyCode, functionType);
	}
}
