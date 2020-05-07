using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseController : MonoBehaviour
{
	[SerializeField] Image transparentIcon;

	public static MouseController Instance
	{
		get;
		private set;
	}

	private GraphicRaycaster raycaster;
	private InteractableSprite selectedSprite;

	private void Awake()
	{
		Instance = this;
		transparentIcon.gameObject.SetActive(false);
		raycaster = GetComponent<GraphicRaycaster>();
	}

	public void ShowTransparentWithGivenIcon()
	{
		UpdateTransparentIconPosByMousePos();
		transparentIcon.sprite = selectedSprite.GetSprite();
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
			PointerEventData pointerData = new PointerEventData(EventSystem.current);
			List<RaycastResult> results = new List<RaycastResult>();

			//Raycast using the Graphics Raycaster and mouse click position
			pointerData.position = Input.mousePosition;
			this.raycaster.Raycast(pointerData, results);

			bool found = false;
			foreach (RaycastResult result in results)
			{
				if (selectedSprite == null)
				{
					selectedSprite = result.gameObject.GetComponent<InteractableSprite>();
					if (selectedSprite != null)
					{
						ShowTransparentWithGivenIcon();
						found = true;
						break;
					}
				}
				else
				{
					KeySlotView clickedKeySlot = result.gameObject.GetComponent<KeySlotView>();
					if (clickedKeySlot && transparentIcon.gameObject.activeSelf)
					{
						KeyConfigView.Instance.UpdateKey(clickedKeySlot, selectedSprite as KeyConfigFunctionKeyView);
						HideClickingIcon();
						found = true;
						break;
					}
				}
			}

			if (selectedSprite != null && !found)
			{
				HideClickingIcon();
			}
		}

		if (transparentIcon.gameObject.activeSelf)
		{
			UpdateTransparentIconPosByMousePos();
		}
	}

	private void HideClickingIcon()
	{
		selectedSprite = null;
		transparentIcon.sprite = null;
		transparentIcon.gameObject.SetActive(false);
	}
}
