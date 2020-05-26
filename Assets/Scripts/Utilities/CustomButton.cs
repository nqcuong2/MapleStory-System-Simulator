using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class CustomButton : Button
{
    [SerializeField] Sprite secondStateNormal;
    [SerializeField] Sprite secondStateHighlighted;
    [SerializeField] Sprite secondStatePressed;
    [SerializeField] Sprite secondStateDisabled;

    private Sprite firstStateNormal;

    private SpriteState firstState; // default state
    private SpriteState secondState;

    protected override void Awake()
    {
        base.Awake();

        InitializeFirstState();
        InitializeSecondState();
    }

    private void InitializeFirstState()
    {
        firstStateNormal = GetComponent<Image>().sprite;

        firstState = new SpriteState();
        firstState.highlightedSprite = spriteState.highlightedSprite;
        firstState.pressedSprite = spriteState.pressedSprite;
        firstState.disabledSprite = spriteState.disabledSprite;
    }

    private void InitializeSecondState()
    {
        if (secondStateNormal != null)
        {
            secondState = new SpriteState();
            secondState.highlightedSprite = secondStateHighlighted;
            secondState.pressedSprite = secondStatePressed;
            secondState.disabledSprite = secondStateDisabled;
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
	{
		base.OnPointerClick(eventData);

        if (secondStateNormal != null)
        {
            SwapButtonState();
        }
        GameObjectUtils.UnfocusButton();
	}

    private void SwapButtonState()
    {
        if (GetComponent<Image>().sprite == firstStateNormal)
        {
            GetComponent<Image>().sprite = secondStateNormal;
            spriteState = secondState;
        }
        else
        {
            GetComponent<Image>().sprite = firstStateNormal;
            spriteState = firstState;
        }
    }
}
