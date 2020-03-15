using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailedStatsView : MonoBehaviour
{
	[Header("Buttons")]
	[SerializeField] Button hiddenAbilityReset;
	[SerializeField] Button hideDetailedStats;

	private static DetailedStatsView instance;
	public static DetailedStatsView Instance
	{
		get
		{
			return instance;
		}
	}

	protected DetailedStatsView() { }

	private void Awake()
	{
		instance = this;
	}

	// Start is called before the first frame update
	void Start()
    {
		hideDetailedStats.onClick.AddListener(() => OnHideDetailedStatsClicked());
	}

	private void OnHideDetailedStatsClicked()
	{
		GameObjectUtils.HideGameObject(gameObject);
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
