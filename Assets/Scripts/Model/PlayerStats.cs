using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
	#region Properties

	#region Main Stats
	public string Name
	{
		get;
		private set;
	}

	public string ClassName
	{
		get;
		private set;
	}

	public string Fame
	{
		get;
		private set;
	}

	public int LowerDmg
	{
		get;
		private set;
	}

	public int UppderDmg
	{
		get;
		private set;
	}

	public int Level
	{
		get;
		private set;
	}

	public int HP
	{
		get;
		private set;
	}

	public int MP
	{
		get;
		private set;
	}

	public long CurrentExp
	{
		get;
		private set;
	}

	public long NextLvExp
	{
		get;
		private set;
	}

	public int AbilityPoints
	{
		get;
		private set;
	}

	public int STR
	{
		get;
		private set;
	}

	public int DEX
	{
		get;
		private set;
	}

	public int INT
	{
		get;
		private set;
	}

	public int LUK
	{
		get;
		private set;
	}
	#endregion

	#region Detailed Stats
	public int DmgBonus
	{
		get;
		private set;
	}

	public int BossDmg
	{
		get;
		private set;
	}

	public int FinalDmg
	{
		get;
		private set;
	}

	public int IgnoreDefense
	{
		get;
		private set;
	}

	public int CritRate
	{
		get;
		private set;
	}

	public int CritDmg
	{
		get;
		private set;
	}

	public int StatusResistance
	{
		get;
		private set;
	}

	public int KnockbackResistance
	{
		get;
		private set;
	}

	public int Defense
	{
		get;
		private set;
	}

	public int Speed
	{
		get;
		private set;
	}

	public int Jump
	{
		get;
		private set;
	}

	public int MasteryPercent
	{
		get;
		private set;
	}

	public int HonorExp
	{
		get;
		private set;
	}
	#endregion

	#endregion

	#region Constructor
	public PlayerStats()
	{
		InitializeMainStats();
		InitializeDetailedStats();
	}
	#endregion

	#region Methods
	private void InitializeMainStats()
	{
		InitializeBasicStats();
		InitializeAbilityPoints();
		CalculateDmg();
	}

	private void InitializeBasicStats()
	{
		Level = 1;
		InitializeExp();
	}

	private void InitializeExp()
	{
		CurrentExp = 0;
		SetNextLvExp();
	}

	private void SetNextLvExp()
	{
		NextLvExp = StatsFactory.GetExpFromLevel(Level);
	}

	private void InitializeAbilityPoints()
	{
		AbilityPoints = 0;
		HP = 55;
		MP = 50;
		STR = 4;
		DEX = 4;
		INT = 4;
		LUK = 4;
	}

	private void CalculateDmg()
	{
		UppderDmg = StatsFactory.CalculateUpperShownDmgRange(this);
		LowerDmg = StatsFactory.CalculateLowerShownDmgRange(this);
	}

	private void InitializeDetailedStats()
	{
		CritRate = 5;
	}

	public void AssignOneAbilityPoints(StatsConstants.AbilityPointType abilityPointType)
	{
		switch(abilityPointType)
		{
			case StatsConstants.AbilityPointType.HP:
				HP += 100;
				break;
			case StatsConstants.AbilityPointType.MP:
				MP += 10;
				break;
			case StatsConstants.AbilityPointType.STR:
				STR++;
				break;
			case StatsConstants.AbilityPointType.DEX:
				DEX++;
				break;
			case StatsConstants.AbilityPointType.INT:
				INT++;
				break;
			case StatsConstants.AbilityPointType.LUK:
				LUK++;
				break;
		}

		AbilityPoints--;
		CalculateDmg();
	}

	public void AssignAllAbilityPoints()
	{
		STR += AbilityPoints;
		AbilityPoints = 0;
		CalculateDmg();
	}

	public void IncreaseExp(long receivedExp)
	{
		CurrentExp += receivedExp;
	}

	public void LvUp()
	{
		CurrentExp = CurrentExp - NextLvExp;
		Level++;
		SetNextLvExp();
		AbilityPoints += StatsConstants.ABILITY_POINTS_PER_LV;
	}
	#endregion
}
