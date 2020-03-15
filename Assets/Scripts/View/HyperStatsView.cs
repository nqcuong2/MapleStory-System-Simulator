using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HyperStatsView : MonoBehaviour
{
	[Header("Buttons")]
	[SerializeField] Button hyperStatsReset;
	[SerializeField] Button hideHyperStats;

	private static HyperStatsView instance;
	public static HyperStatsView Instance
	{
		get
		{
			return instance;
		}
	}
	
	protected HyperStatsView() { }

	private void Awake()
	{
		instance = this;
	}

	// Start is called before the first frame update
	void Start()
    {
		SetupButtonEvents();
    }

	private void SetupButtonEvents()
	{
		hideHyperStats.onClick.AddListener(() => OnHideHyperStatsClicked());
	}

	private void OnHideHyperStatsClicked()
	{
		GameObjectUtils.HideGameObject(gameObject);
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
