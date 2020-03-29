using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainStatsView : MonoBehaviour
{
	[Header("Buttons")]
	[SerializeField] Button hpUp;
	[SerializeField] Button mpUp;
	[SerializeField] Button autoAssign;
	[SerializeField] Button strUp;
	[SerializeField] Button dexUp;
	[SerializeField] Button intUp;
	[SerializeField] Button lukUp;
	[SerializeField] Button hyperStats;
	[SerializeField] Button detailedStats;

	[Header("Texts")]
	[SerializeField] Text playerName;
	[SerializeField] Text className;
	[SerializeField] Text guildName;
	[SerializeField] Text fame;
	[SerializeField] Text dmg;
	[SerializeField] Text hp;
	[SerializeField] Text mp;
	[SerializeField] Text abilityPoints;
	[SerializeField] Text str;
	[SerializeField] Text dex;
	[SerializeField] Text intelligence;
	[SerializeField] Text luk;

	[Header("Hyper Stats Btn Sprites")]
	[SerializeField] Sprite normalHSShowState;
	[SerializeField] Sprite normalHSHideState;

	[Header("Detailed Stats Btn Sprites")]
	[SerializeField] Sprite normalDSShowState;
	[SerializeField] Sprite normalDSHideState;

	private PlayerController playerController;

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
		playerController = FindObjectOfType<PlayerController>();
	}

	// Start is called before the first frame update
	void Start()
    {
		SetupButtons();
	}

	private void SetupButtons()
	{
		autoAssign.onClick.AddListener(() => OnAutoAssignClicked());
		hpUp.onClick.AddListener(() => OnIncreaseOneAbilityPointClicked(StatsConstants.AbilityPointType.HP));
		mpUp.onClick.AddListener(() => OnIncreaseOneAbilityPointClicked(StatsConstants.AbilityPointType.MP));
		strUp.onClick.AddListener(() => OnIncreaseOneAbilityPointClicked(StatsConstants.AbilityPointType.STR));
		dexUp.onClick.AddListener(() => OnIncreaseOneAbilityPointClicked(StatsConstants.AbilityPointType.DEX));
		intUp.onClick.AddListener(() => OnIncreaseOneAbilityPointClicked(StatsConstants.AbilityPointType.INT));
		lukUp.onClick.AddListener(() => OnIncreaseOneAbilityPointClicked(StatsConstants.AbilityPointType.LUK));
		hyperStats.onClick.AddListener(() => OnHyperStatsClicked());
		detailedStats.onClick.AddListener(() => OnDetailedStatsClicked());
	}

	private void OnAutoAssignClicked()
	{
		playerController.AssignAllAbilityPoints();
	}

	private void OnIncreaseOneAbilityPointClicked(StatsConstants.AbilityPointType abilityPointType)
	{
		playerController.AssignOneAbilityPoints(abilityPointType);
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

	public void UpdateStats(int lowerDmg, int upperDmg, int hp, int mp, int str, int dex, int intelligence, int luk)
	{
		dmg.text = lowerDmg + " ~ " + upperDmg;
		this.hp.text = hp.ToString();
		this.mp.text = mp.ToString();
		this.str.text = str.ToString();
		this.dex.text = dex.ToString();
		this.intelligence.text = intelligence.ToString();
		this.luk.text = luk.ToString();
	}

	public void UpdateAbilityPoints(int abilityPoints)
	{
		this.abilityPoints.text = abilityPoints.ToString();
	}

	public void EnableAllAssignAbilityPointButtons()
	{
		autoAssign.interactable = true;
		hpUp.interactable = true;
		mpUp.interactable = true;
		strUp.interactable = true;
		dexUp.interactable = true;
		intUp.interactable = true;
		lukUp.interactable = true;
	}

	public void DisableAllAssignAbilityPointButtons()
	{
		autoAssign.interactable = false;
		hpUp.interactable = false;
		mpUp.interactable = false;
		strUp.interactable = false;
		dexUp.interactable = false;
		intUp.interactable = false;
		lukUp.interactable = false;
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
