using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Player playerData;
	[SerializeField] int level;

	private void Awake()
	{
		playerData = new Player("Thai");
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void GainExp(float gainedExp)
	{
		playerData.AddCurrentExp(gainedExp);
		CheckPlayerLvUp();
		UpdateExpBar();
	}

	private void CheckPlayerLvUp()
	{
		while (playerData.CurrentExp >= playerData.NextLvExp)
		{
			playerData.LvUp();
		}

		level = playerData.Level;
	}

	private void UpdateExpBar()
	{
		float percent = CalculateExpPercent();
		ExpBarView.Instance.UpdateExpInfo(playerData.CurrentExp, playerData.NextLvExp, percent);
	}

	private float CalculateExpPercent()
	{
		float percent = (float)(Math.Round(playerData.CurrentExp / playerData.NextLvExp * 100, 2));
		return percent;
	}
}
