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

    public GameObject selectedObject;
    public Collectable collectedObject;
    public Transform collectedTransformParent;

    // Use this for initialization
    void Start () {
        eventTriggers = new List<EventTrigger>(FindObjectsOfType<EventTrigger>());

        foreach (EventTrigger evt in eventTriggers)
        {
            if (evt.gameObject.name.Contains("Marker"))
                continue;

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
                SelectionFinished();
        }
	}

    private void SelectionFinished()
    {
        loading = false;
        loadingBaseImage.SetActive(false);

        if (selectedObject == null)
            return;

        if (selectedObject.tag == "Collectable")
        {
            if (collectedObject == null)
            {
                collectedObject = selectedObject.GetComponent<Collectable>();
                collectedObject.transform.parent = collectedTransformParent;
                collectedObject.transform.localScale = Vector3.one;
                collectedObject.transform.localPosition = Vector3.zero;
                collectedObject.GetComponent<Collider>().isTrigger = true;
            }
            else if (collectedObject.type == selectedObject.GetComponent<Collectable>().type)
            {
                collectedObject.transform.parent = null;
                collectedObject.transform.localScale = Vector3.one;
                collectedObject.GetComponent<Collider>().isTrigger = false;
                collectedObject = null;
            }
        }
        else if (selectedObject.tag == "Interactable" && collectedObject == null)
        {
            selectedObject.GetComponent<Interactable>().Interact();
        }
        else if (selectedObject.tag == "PlacePoint" && collectedObject != null)
        {
            PlacePoint __pp = selectedObject.GetComponent<PlacePoint>();
            if (__pp.requiredCollectable == collectedObject.type)
            {
                __pp.PlaceObject(collectedObject);
                collectedObject = null;
            }
        }
    }

    public void StartLoading(PointerEventData data)
    {
        loading = true;
        loadingBaseImage.SetActive(true);
        currentLoadTime = 0f;
        selectedObject = data.pointerEnter;
    }

    public void StopLoading(PointerEventData data)
    {
        loading = false;
        loadingBaseImage.SetActive(false);
        if (selectedObject == data.pointerEnter)
            selectedObject = null;
    }
}
