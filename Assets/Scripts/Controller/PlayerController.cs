using UnityEngine;
using static MSSim.Constants.StatsConstants;

public class PlayerController : MonoBehaviour
{
	private Player playerData;
	private PlayerStats playerStats;
	[SerializeField] int level;

	private void Awake()
	{
		playerData = new Player();
		playerStats = playerData.PlayerStats;
	}

	// Start is called before the first frame update
	void Start()
    {
		level = playerStats.Level;
		UpdateUIStats();
		UpdateExpBar();
	}

	private void UpdateUIStats()
	{
		MainStatsView.Instance.UpdateStats(
			playerStats.LowerDmg,
			playerStats.UppderDmg,
			playerStats.HP,
			playerStats.MP,
			playerStats.STR,
			playerStats.DEX,
			playerStats.INT,
			playerStats.LUK
		);

		UpdateAbilityPointsUI();
	}

	private void UpdateAbilityPointsUI()
	{
		MainStatsView.Instance.UpdateAbilityPoints(playerStats.AbilityPoints);

		if (playerStats.AbilityPoints == 0)
		{
			MainStatsView.Instance.DisableAllAssignAbilityPointButtons();
		}
		else
		{
			MainStatsView.Instance.EnableAllAssignAbilityPointButtons();
		}
	}

	private void UpdateExpBar()
	{
		float percent = CalculateExpPercent();
		ExpBarView.Instance.UpdateExpInfo(playerStats.CurrentExp, playerStats.NextLvExp, percent);
	}

	private float CalculateExpPercent()
	{
		float percent = (float)playerStats.CurrentExp / playerStats.NextLvExp * 100;
		return percent;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void AssignOneAbilityPoints(AbilityPointType abilityPointType)
	{
		playerStats.AssignOneAbilityPoints(abilityPointType);
		UpdateUIStats();
	}

	public void AssignAllAbilityPoints()
	{
		playerData.PlayerStats.AssignAllAbilityPoints();
		UpdateUIStats();
	}

	public void GainExp(long gainedExp)
	{
		playerStats.IncreaseExp(gainedExp);
		CheckPlayerLvUp();
		UpdateExpBar();
	}

	private void CheckPlayerLvUp()
	{
		while (playerStats.CurrentExp >= playerStats.NextLvExp)
		{
			playerStats.LvUp();
			UpdateAbilityPointsUI();
		}

		level = playerStats.Level;
	}

		
}
