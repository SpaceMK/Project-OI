using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public List<Action<UIState>> UpdateStates = new List<Action<UIState>>();

    public void UpdateState(UIState newState)
    {
        foreach (var states in UpdateStates)
        {
            states(newState);
        }
    }

}

[System.Serializable]
public enum UIState
{
   Starting,
   ReadyToPlay,
   Load,
   Options,
   StartGame
}
