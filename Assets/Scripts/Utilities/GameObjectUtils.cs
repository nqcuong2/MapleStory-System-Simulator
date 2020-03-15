using UnityEngine;

class GameObjectUtils : MonoBehaviour
{
	public static void ShowGameObject(GameObject toShowGameObject)
	{
		toShowGameObject.SetActive(true);
	}

	public static void HideGameObject(GameObject toHideGameObject)
	{
		toHideGameObject.SetActive(false);
	}
}
