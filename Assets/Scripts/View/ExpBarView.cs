using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ExpBarView : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI expInfoTxt;
	Slider expSlider;

	private static ExpBarView instance;
	public static ExpBarView Instance
	{
		get
		{
			return instance;
		}
	}

	protected ExpBarView() { }

	private void Awake()
	{
		instance = this;
	}

	// Start is called before the first frame update
	void Start()
    {
		expSlider = GetComponent<Slider>();
    }

	public void UpdateExpInfo(long currentExp, long nextLvExp, float percent)
	{
		string formattedPercent = String.Format("{0:0.00}", Math.Truncate(percent * 100) / 100);
		string expInfo = currentExp + " / " + nextLvExp + " [" + formattedPercent + "%]";
		expInfoTxt.SetText(expInfo);
		expSlider.value = percent;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
