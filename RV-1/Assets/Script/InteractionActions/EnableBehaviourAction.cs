using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBehaviourAction : InteractionAction {

    public Behaviour targer;
    public bool enable;

    public override void PlayAction()
    {
        targer.enabled = enable;
    }

}
