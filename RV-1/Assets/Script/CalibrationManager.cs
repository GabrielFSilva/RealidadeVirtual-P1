using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalibrationManager : MonoBehaviour {

    public GameObject panel;
    public Text startingText;
    
	void Start () {
        StartCoroutine(WaitAndCalibrate());
	}
	
	IEnumerator WaitAndCalibrate()
    {
        for (int i = 5; i > 0; i--)
        {
            startingText.text = "Starting in: " + i.ToString();
            yield return new WaitForSeconds(1f);
        }

        panel.SetActive(false);
    }
}
