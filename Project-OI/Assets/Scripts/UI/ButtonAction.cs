using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    [SerializeField] Button changeStateButton;
    [SerializeField] UIState newState;
    public Action<UIState> ChangeState;
    void Start()
    {
        changeStateButton.onClick.AddListener(()=>ChangeState(newState));
    }

   
}
