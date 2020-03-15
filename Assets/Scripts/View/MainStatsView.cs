using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainStatsView : MonoBehaviour
{
	[Header("Buttons")]
	[SerializeField] Button autoAssign;
	[SerializeField] Button strUp;
	[SerializeField] Button dexUp;
	[SerializeField] Button intUp;
	[SerializeField] Button lukUp;
	[SerializeField] Button hyperStats;
	[SerializeField] Button detailedStats;

	[Header("Hyper Stats Btn Sprites")]
	[SerializeField] Sprite normalHSShowState;
	[SerializeField] Sprite normalHSHideState;

	[Header("Detailed Stats Btn Sprites")]
	[SerializeField] Sprite normalDSShowState;
	[SerializeField] Sprite normalDSHideState;

	private static MainStatsView instance;
	public static MainStatsView Instance
	{
		get
		{
			return instance;
		}
	}

	private void Awake()
	{
		instance = this;
	}

	// Start is called before the first frame update
	void Start()
    {
		hyperStats.onClick.AddListener(() => OnHyperStatsClicked());
		detailedStats.onClick.AddListener(() => OnDetailedStatsClicked());
	}

	private void OnHyperStatsClicked()
	{
		GameObject hyperStatsGO = HyperStatsView.Instance.gameObject;
		if (hyperStatsGO.activeSelf)
		{
			GameObjectUtils.HideGameObject(hyperStatsGO);
		}
		else
		{
			GameObjectUtils.ShowGameObject(hyperStatsGO);
		}
	}

	private void OnDetailedStatsClicked()
	{
		GameObject detailedStatsGO = DetailedStatsView.Instance.gameObject;
		if (detailedStatsGO.activeSelf)
		{
			GameObjectUtils.HideGameObject(detailedStatsGO);
		}
		else
		{
			GameObjectUtils.ShowGameObject(detailedStatsGO);
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
