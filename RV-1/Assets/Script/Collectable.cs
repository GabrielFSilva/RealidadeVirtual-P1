using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public enum CollectableType
    {
        RED_BOX,
        GREEN_BOX,
        BLUE_BOX,
        YELLOW_BOX
    }

    public CollectableType type;

	public void Collect()
    {
        gameObject.SetActive(false);
    }
    public void Plate(Transform parent, Vector3 localPos)
    {
        transform.parent = parent;
        transform.localPosition = localPos;
        gameObject.SetActive(true);
    }
}
