using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeySlotView : MonoBehaviour
{
	[SerializeField] KeyCode keyCode;
	public KeyCode GetKeyCode()
	{
		return keyCode;
	}

	void Awake()
	{
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
