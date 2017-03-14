using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

    private RectTransform bar;

    public float value = 100;
    public float maxValue = 100; 

	private void Start ()
    {
        bar = GetComponent<RectTransform>();
        UpdateBar();
	}

    private void UpdateBar()
    {
        float ratio = value / maxValue;
        bar.localScale = new Vector3(ratio, 1, 1);
    }

    public void ChangeValue(float change)
    {
        value += change;

        if (value < 0)
            value = 0;
        if (value > maxValue)
            value = maxValue;

        UpdateBar();
    }

}
