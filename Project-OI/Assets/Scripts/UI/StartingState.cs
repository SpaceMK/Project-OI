using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingState : MonoBehaviour
{
    [SerializeField] UIState myState;
    [SerializeField] ButtonAction goBackToMenu;
    [SerializeField] UIManager manager;
    [SerializeField] GameObject uiStatePanel;

    void Start()
    {
        goBackToMenu.ChangeState += ChangeStateTrigger;
        manager.UpdateStates.Add(UpdateState);
    }



    void ChangeStateTrigger(UIState state)
    {
        manager.UpdateState(state);
    }


    void UpdateState(UIState newState)
    {
        bool enabled = newState == myState ? true : false;
        goBackToMenu.gameObject.SetActive(!enabled);
        uiStatePanel.SetActive(enabled);
    }
}
