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

	public void UpdateExpInfo(float currentExp, float nextLvExp, float percent)
	{
		string expInfo = currentExp + " / " + nextLvExp + " [" + percent + "%]";
		expInfoTxt.SetText(expInfo);
		expSlider.value = percent;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
