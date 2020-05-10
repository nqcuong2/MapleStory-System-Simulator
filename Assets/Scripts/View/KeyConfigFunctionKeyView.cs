using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyConfigFunctionKeyView : InteractableSprite
{
	private RectTransform rectTransform;
	private Vector2 defaultPos;

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		defaultPos = transform.localPosition;
	}

	public override void Reset()
	{
		gameObject.SetActive(true);
		CurrentSlot = null;
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
