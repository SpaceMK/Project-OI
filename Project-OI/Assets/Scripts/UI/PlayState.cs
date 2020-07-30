using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : MonoBehaviour
{
    [SerializeField] UIState myState;
    [SerializeField] ButtonAction playStateButton;
    [SerializeField] UIManager uiManager;
    [SerializeField] GameObject uiStatePanel;
    void Start()
    {
        playStateButton.ChangeState += ChangeStateTrigger;
        uiManager.UpdateStates.Add(NewState);
    }

    void ChangeStateTrigger(UIState state)
    {
        uiManager.UpdateState(state);
    }

    void NewState(UIState state)
    {
        bool enabled = state == myState ? true : false;
        uiStatePanel.SetActive(enabled);
    }
}
