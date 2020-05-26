using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

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

	[Header("TMP_Texts")]
	[SerializeField] TMP_Text playerName;
	[SerializeField] TMP_Text className;
	[SerializeField] TMP_Text guildName;
	[SerializeField] TMP_Text fame;
	[SerializeField] TMP_Text dmg;
	[SerializeField] TMP_Text hp;
	[SerializeField] TMP_Text mp;
	[SerializeField] TMP_Text abilityPoints;
	[SerializeField] TMP_Text str;
	[SerializeField] TMP_Text dex;
	[SerializeField] TMP_Text intelligence;
	[SerializeField] TMP_Text luk;

	private PlayerController playerController;

	public static MainStatsView Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
		playerController = FindObjectOfType<PlayerController>();
    }

	// Start is called before the first frame update
	void Start()
    {
		HideOtherStatWindows();
		SetupButtons();
	}

	private void HideOtherStatWindows()
	{
		DetailedStatsView.Instance.gameObject.SetActive(false);
		HyperStatsView.Instance.gameObject.SetActive(false);
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
		DetailedStatsView.Instance.UpdateDmgText(dmg.text);
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
