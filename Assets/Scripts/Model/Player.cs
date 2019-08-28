using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
	private int health;
	private string hair;
	private string eyes;
	private string top;
	private string bottom;
	private string shoes;
	private string weapon;
	private bool isFemale;

	public Player(string name) : base(name)
	{
		health = 100;
	}

	public Player(string name, string hair, string eyes, string top, string bottom, string shoes, string weapon, bool isFemale) : base (name)
	{
		health = 100;
		this.hair = hair;
		this.eyes = eyes;
		this.top = top;
		this.bottom = bottom;
		this.shoes = shoes;
		this.weapon = weapon;
		this.isFemale = isFemale;
	}

	public Player(string name, int health, string hair, string eyes, string top, string bottom, string shoes, string weapon, bool isFemale) : base(name)
	{
		this.health = health;
		this.hair = hair;
		this.eyes = eyes;
		this.top = top;
		this.bottom = bottom;
		this.shoes = shoes;
		this.weapon = weapon;
		this.isFemale = isFemale;
	}


}
