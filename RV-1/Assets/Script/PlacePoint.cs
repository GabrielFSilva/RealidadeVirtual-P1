using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlacePoint : MonoBehaviour
{
    public Collectable.CollectableType requiredCollectable;
    public Transform placeTransform;
    public List<InteractionAction> actions;

    private void Start()
    {
        actions = GetComponents<InteractionAction>().ToList();
    }

    public void PlaceObject(Collectable collectable)
    {
        collectable.transform.parent = placeTransform;
        collectable.transform.localPosition = Vector3.zero;
        collectable.GetComponent<Collider>().enabled = false;
        GetComponent<Collider>().enabled = false;
        collectable.gameObject.SetActive(true);
        
        foreach (InteractionAction action in actions)
            action.PlayAction();
    }
}
