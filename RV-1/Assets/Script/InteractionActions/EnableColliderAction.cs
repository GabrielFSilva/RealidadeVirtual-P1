using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableColliderAction : InteractionAction {

    public Collider targetCollider;
    public bool enable;

    public override void PlayAction()
    {
        targetCollider.enabled = enable;
    }
}
