using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjectAction : InteractionAction {

    public GameObject target;
    public bool enable;

    public override void PlayAction()
    {
        target.SetActive(enable);
    }
}
