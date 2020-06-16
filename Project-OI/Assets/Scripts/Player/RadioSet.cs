using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RadioSet : MonoBehaviour,IInteractable
{
    [SerializeField] List<string> correspondingTags;
    [SerializeField] string uiMessage;
    public Action RadioUsedByPlayers; 
    bool radioUsed;


    public void UseRadio(List<string> inventoryList)
    {
        if (correspondingTags.All(itm2 => inventoryList.Contains(itm2)) && !radioUsed)
        {
            RadioUsedByPlayers?.Invoke();
            radioUsed = true;
        }
    }

    public string GetRadioUIMessage()
    {
        return uiMessage;
    }
}
