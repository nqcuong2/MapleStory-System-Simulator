using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class ExpBarView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] TextMeshProUGUI expInfoTxt;
	Slider expSlider;

	private string currLvExp;
	private string nextLvExp;
	private string formattedExpPercent;
    public static ExpBarView Instance { get; private set; }

    protected ExpBarView() { }

	private void Awake()
	{
		Instance = this;
	}

	// Start is called before the first frame update
	void Start()
    {
		expSlider = GetComponent<Slider>();
    }

	public void UpdateExpInfo(long currentExp, long nextLvExp, float percent)
	{
		currLvExp = currentExp.ToString();
		this.nextLvExp = nextLvExp.ToString();
		formattedExpPercent = String.Format("{0:0.00}", Math.Truncate(percent * 100) / 100);
		ShowSimpleExpInfo();
		expSlider.value = percent;
	}

	private void ShowSimpleExpInfo()
	{
		string expInfo = currLvExp + " [" + formattedExpPercent + "%]";
		expInfoTxt.SetText(expInfo);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		ShowDetailExpInfo();
	}

	private void ShowDetailExpInfo()
	{
		string expInfo = "EXP : " + currLvExp + " / " + nextLvExp + " [" + formattedExpPercent + "%]";
		expInfoTxt.SetText(expInfo);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		ShowSimpleExpInfo();
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
