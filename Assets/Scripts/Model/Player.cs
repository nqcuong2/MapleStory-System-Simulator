using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
	private string hair;
	private string eyes;
	private string top;
	private string bottom;
	private string shoes;
	private string weapon;
	private bool isFemale;

	private PlayerStats playerStats;

	public Player()
	{
		playerStats = new PlayerStats();
	}

	public long CurrentExp
	{
		get { return playerStats.CurrentExp; }
	}

	public void IncreaseExp(long receivedExp)
	{
		playerStats.IncreaseExp(receivedExp);
	}

	public long NextLvExp
	{
		get { return playerStats.NextLvExp; }
	}

	public int Level
	{
		get { return playerStats.Level; }
	}

	public void LvUp()
	{
		playerStats.LvUp();
	}
}
