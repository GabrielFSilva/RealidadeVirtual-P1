using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAction : InteractionAction {

    public float delay = 1f;
    public GameObject secondaryActionsContainer;
    public List<InteractionAction> actions;

    private void Start()
    {
        actions = secondaryActionsContainer.GetComponents<InteractionAction>().ToList();
    }

    public override void PlayAction()
    {
        StartCoroutine(WaitAndPlayActions());
    }

    IEnumerator WaitAndPlayActions()
    {
        yield return new WaitForSeconds(delay);
        foreach (InteractionAction action in actions)
            action.PlayAction();
    }
}
