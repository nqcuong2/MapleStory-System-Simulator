using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeyConfigFunctionKeyView : MonoBehaviour, InteractableSprite
{
	[SerializeField] KeyConfigView.FunctionType functionType;

	private RectTransform rectTransform;
	private Vector2 defaultPos;

	public KeyConfigView.FunctionType GetFunctionType()
	{
		return functionType;
	}

	public Sprite GetSprite()
	{
		return GetComponent<Image>().sprite;
	}

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		defaultPos = transform.localPosition;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
    }
}
