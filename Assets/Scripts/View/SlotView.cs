using MSSim.Constants;
using UnityEngine;
using UnityEngine.UI;

public class SlotView : MonoBehaviour
{
	[SerializeField] KeyCode keyCode;
	public KeyCode GetKeyCode()
	{
		return keyCode;
	}

	public IMouseInteractable AssignedFunctionKey
	{
		get;
		set;
	}

	void Awake()
	{
		AssignedFunctionKey = null;
	}

    public void Reset()
    {
        GetComponent<Image>().color = Constants.TRANSPARENT_COLOR;
        //AssignedFunctionKey?.Reset();
        //AssignedFunctionKey = null;
    }

    //public void UpdateFunctionKey(IMouseInteractable functionKey)
    //{
    //	GetComponent<Image>().color = Constants.OPAQUE_COLOR;
    //	GetComponent<Image>().sprite = functionKey.GetSprite();
    //	AssignedFunctionKey = functionKey;
    //	functionKey.CurrentSlot = this;
    //}

    public void UpdateSprite(Sprite sprite)
    {
        if (sprite == null)
        {
            Reset();
        }
        else
        {
            GetComponent<Image>().color = Constants.OPAQUE_COLOR;
            GetComponent<Image>().sprite = sprite;
        }
    }
}
