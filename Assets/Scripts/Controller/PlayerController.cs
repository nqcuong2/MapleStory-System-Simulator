using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		UpdateStatsOnUIs();
		UpdateExpBar();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void AssignAllAbilityPoints()
	{
		playerData.PlayerStats.AssignAllAbilityPoints();
		UpdateUIStats();
	}

	private void UpdateUIStats()
	{
		MainStatsView.Instance.UpdateStats(
			playerStats.LowerDmg,
			playerStats.UppderDmg,
			playerStats.STR,
			playerStats.DEX,
			playerStats.INT,
			playerStats.LUK
		);

		MainStatsView.Instance.UpdateAbilityPoints(playerStats.AbilityPoints);
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
			MainStatsView.Instance.UpdateAbilityPoints(playerStats.AbilityPoints);
		}

		level = playerStats.Level;
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
}
