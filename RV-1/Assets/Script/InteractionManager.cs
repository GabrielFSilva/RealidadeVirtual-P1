using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InteractionManager : MonoBehaviour
{
    public GameObject loadingBaseImage;
    public Image loadingInteractionImage;
    public MeshRenderer pointerRenderer;

    public List<EventTrigger> eventTriggers;

    public bool loading;
    public float loadTime;
    private float currentLoadTime;

    // Use this for initialization
    void Start () {
        eventTriggers = new List<EventTrigger>(FindObjectsOfType<EventTrigger>());

       
        foreach (EventTrigger evt in eventTriggers)
        {
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerEnter;
            entry.callback.AddListener((data) => { StartLoading((PointerEventData)data); });

            EventTrigger.Entry exit = new EventTrigger.Entry();
            exit.eventID = EventTriggerType.PointerExit;
            exit.callback.AddListener((data) => { StopLoading((PointerEventData)data); });

            evt.triggers.Add(entry);
            evt.triggers.Add(exit);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (loading && currentLoadTime < loadTime)
        {
            currentLoadTime += Time.deltaTime;
            loadingInteractionImage.fillAmount = currentLoadTime / loadTime;
            if (currentLoadTime >= loadTime)
                Debug.Log("Finished");
        }
	}

    public void StartLoading(PointerEventData data)
    {
        loading = true;
        loadingBaseImage.SetActive(true);
        //pointerRenderer.enabled = false;
        currentLoadTime = 0f;
        Debug.Log("test");
    }

    public void StopLoading(PointerEventData data)
    {
        Destroy(data.hovered[0]);
        loading = false;
        loadingBaseImage.SetActive(false);
        //pointerRenderer.enabled = true;
    }
}
