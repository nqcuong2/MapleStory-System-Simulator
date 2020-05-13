using UnityEngine;
using UnityEngine.EventSystems;

class GameObjectUtils : MonoBehaviour
{
	private static EventSystem myEventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();

	public static void ShowGameObject(GameObject toShowGameObject)
	{
		toShowGameObject.SetActive(true);
	}

	public static void HideGameObject(GameObject toHideGameObject)
	{
		toHideGameObject.SetActive(false);
	}

	public static void ToggleWindow(GameObject window)
	{
		window.SetActive(window.activeSelf ? false : true);
		window.transform.SetAsLastSibling();
	}

	public static void UnfocusButton()
	{
		myEventSystem?.SetSelectedGameObject(null);
	}
}
