using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
	private string name;
	private Sprite sprite;
	public Character(string name)
	{
		this.name = name;
	}

	public string Name() { return name; }
}
