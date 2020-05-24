using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DetailedStatsView : MonoBehaviour
{
	[Header("Buttons")]
	[SerializeField] Button hiddenAbilityReset;
	[SerializeField] Button hideDetailedStats;

	[Header("TMP_Texts")]
	[SerializeField] TMP_Text dmg;
	[SerializeField] TMP_Text dmgBonus;
	[SerializeField] TMP_Text bossDmg;
	[SerializeField] TMP_Text finalDmg;
	[SerializeField] TMP_Text ignoreDef;
	[SerializeField] TMP_Text critRate;
	[SerializeField] TMP_Text critDmg;
	[SerializeField] TMP_Text statusResistence;
	[SerializeField] TMP_Text knockbackResistence;
	[SerializeField] TMP_Text def;
	[SerializeField] TMP_Text speed;
	[SerializeField] TMP_Text jump;
	[SerializeField] TMP_Text honorExp;
    public static DetailedStatsView Instance { get; private set; }

    protected DetailedStatsView() { }

	private void Awake()
	{
		Instance = this;
	}

	// Start is called before the first frame update
	void Start()
    {
		hideDetailedStats.onClick.AddListener(() => OnHideDetailedStatsClicked());
	}

	private void OnHideDetailedStatsClicked()
	{
		GameObjectUtils.HideGameObject(gameObject);
	}

	public void UpdateDmgText(string dmg)
	{
		this.dmg.text = dmg;
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
