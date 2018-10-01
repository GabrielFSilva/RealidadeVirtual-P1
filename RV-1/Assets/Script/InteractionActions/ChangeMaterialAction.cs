using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialAction : InteractionAction {

    public Renderer targetRenderer;
    public Material newMaterial;

    public override void PlayAction()
    {
        targetRenderer.material = newMaterial;
    }
}
