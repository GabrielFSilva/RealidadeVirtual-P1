using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public List<InteractionAction> actions;

    private void Start()
    {
        actions = GetComponents<InteractionAction>().ToList();
    }

    public void Interact()
    {
        foreach (InteractionAction action in actions)
            action.PlayAction();
    }
}
