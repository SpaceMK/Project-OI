using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionObjective : MonoBehaviour, IInteractable
{
    [SerializeField] string objectTag, objectiveDescription;
   

    public string GetTag()
    {
        return objectTag;
    }

    public string GetDescription()
    {
        return objectiveDescription;
    }

    public void DestroyObject()
    {
        Destroy(this.gameObject,2f);
    }
}
