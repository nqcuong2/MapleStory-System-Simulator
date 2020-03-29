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

	public PlayerStats PlayerStats
	{
		get;
		private set;
	}

	public Player()
	{
		PlayerStats = new PlayerStats();
	}
}
