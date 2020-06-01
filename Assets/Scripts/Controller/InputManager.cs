using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
	[SerializeField] Image transparentIcon;

	public static InputManager Instance
	{
		get;
		private set;
	}

	private GraphicRaycaster raycaster;
	private SlotItem selectedSlotItem;

	private void Awake()
	{
		Instance = this;
		transparentIcon.gameObject.SetActive(false);
		raycaster = GetComponent<GraphicRaycaster>();
	}

	public void ShowTransparentWithGivenIcon()
	{
		UpdateTransparentIconPosByMousePos();
		transparentIcon.sprite = selectedSlotItem.SlotSprite;
		transparentIcon.gameObject.SetActive(true);
	}

	private void UpdateTransparentIconPosByMousePos()
	{
		Vector2 newPosition = new Vector2(Input.mousePosition.x - transparentIcon.rectTransform.sizeDelta.x / 2,
										  Input.mousePosition.y - transparentIcon.rectTransform.sizeDelta.y / 2);
		transparentIcon.transform.position = newPosition;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			CheckMouseClick();
		}

		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			KeyConfigView.Instance.ExecuteActionFromPressedKey(KeyCode.LeftShift);
		}
		else if (Input.GetKeyDown(KeyCode.RightShift))
		{
			KeyConfigView.Instance.ExecuteActionFromPressedKey(KeyCode.RightShift);
		}

		if (transparentIcon.gameObject.activeSelf)
		{
			UpdateTransparentIconPosByMousePos();
		}
	}

	private void CheckMouseClick()
	{
		PointerEventData pointerData = new PointerEventData(EventSystem.current);
		List<RaycastResult> results = new List<RaycastResult>();

		//Raycast using the Graphics Raycaster and mouse click position
		pointerData.position = Input.mousePosition;
		this.raycaster.Raycast(pointerData, results);

		if (results.Count > 0)
		{
			if (selectedSlotItem == null)
			{
				SlotView selectedSlot = results[0].gameObject.GetComponent<SlotView>();
				if (selectedSlot)
				{
                    selectedSlotItem = KeyConfigView.Instance.GetSelectedSlotItem(selectedSlot);
				}
				else
				{
                    var selectedItem = results[0].gameObject.GetComponent<IMouseInteractable>();
                    selectedSlotItem = selectedItem == null ? null : new SlotItem(selectedItem.GetSprite(), selectedItem.GetType());
				}

				if (selectedSlotItem != null)
				{
					ShowTransparentWithGivenIcon();
				}
			}
			else
			{
				if (results[0].gameObject.name == "Reset_Function_Area")
				{
					KeyConfigView.Instance.ResetSlot(selectedSlotItem);
				}
				else
				{
					SlotView selectedSlot = results[0].gameObject.GetComponent<SlotView>();
					if (selectedSlot)
					{
                        if (KeyConfigView.Instance.IsSlotInKeyConfig(selectedSlot))
                        {
                            KeyConfigView.Instance.MapSlot(selectedSlot, selectedSlotItem);
                        }
					}
				}

				HideClickedIcon();
			}
		}
        else
        {
            HideClickedIcon();
        }
    }

	private void HideClickedIcon()
	{
		selectedSlotItem = null;
		transparentIcon.sprite = null;
		transparentIcon.gameObject.SetActive(false);
	}

	private void OnGUI()
	{
		Event e = Event.current;
		if (e.type == EventType.KeyDown && e.keyCode != KeyCode.None)
		{
			KeyConfigView.Instance.ExecuteActionFromPressedKey(e.keyCode);
		}
	}
}
