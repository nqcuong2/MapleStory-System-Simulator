using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsContainerView : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
    {
		GameObjectUtils.HideGameObject(HyperStatsView.Instance.gameObject);
		GameObjectUtils.HideGameObject(DetailedStatsView.Instance.gameObject);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
