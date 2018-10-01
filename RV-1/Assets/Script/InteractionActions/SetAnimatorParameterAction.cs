using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorParameterAction : InteractionAction {

    public Animator target;

    [Header("Bool Parameter")]
    public bool useBoolParameter;
    public string boolParameterName;
    public bool boolParameterValue;

    [Header("Trigger Parameter")]
    public bool useTriggerParameter;
    public string triggerParameterName;
    
    public override void PlayAction()
    {
        if (useBoolParameter)
        {
            target.SetBool(boolParameterName, boolParameterValue);
        }
        if (useTriggerParameter)
        {
            target.SetTrigger(triggerParameterName);
        }
    }
}
