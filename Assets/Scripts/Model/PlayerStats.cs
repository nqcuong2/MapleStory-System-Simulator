using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
	#region Fields
	//Basic stats
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

	public float[] Damage
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

	//Detailed stats
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

	public int HonorExp
	{
		get;
		private set;
	}

	#endregion

	#region Constructor
	public PlayerStats()
	{
		Level = 199;
		HP = 100;
		CurrentExp = 777054900;
		GetNextLvExp();
	}
	#endregion

	#region Methods
	public void GetNextLvExp()
	{
		NextLvExp = StatsFactory.GetExpFromLevel(Level);
	}

	public void IncreaseExp(long receivedExp)
	{
		CurrentExp += receivedExp;
	}

	public void LvUp()
	{
		CurrentExp = CurrentExp - NextLvExp;
		Level++;
		GetNextLvExp();
	}
	#endregion
}
