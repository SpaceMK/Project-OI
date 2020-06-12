using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerfunctionalityInput : MonoBehaviour
{
    [SerializeField] KeyCode checkInventory;
    [SerializeField] PlayerInventory playerInventory;
    public Action<PlayerInventory> CheckInventory;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(checkInventory))
            CheckInventory?.Invoke(playerInventory);
    }
}
