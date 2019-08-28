using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
	private Sprite sprite;

	public NPC(string name, Sprite sprite) : base(name)
	{
		this.sprite = sprite;
	}
}
