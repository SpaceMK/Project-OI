using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTarget : MonoBehaviour,ITakeDamage
{ 
    [SerializeField] float targetHealth;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] bool targetEnabled;
    [SerializeField] Color targetIsDead, targetisAlive;
    Material targetMaterial;

    void Start()
    {
        targetMaterial = meshRenderer.materials[1];
        ChangeTargetColor(!targetEnabled);
    }

    public void TakeDamage(float damage)
    {
        targetHealth -= damage;
        if (targetHealth <= 0f)
            ChangeTargetColor(true);
    }

    
    void ChangeTargetColor(bool dead)
    {
        var color = dead ? targetIsDead : targetisAlive;
        targetMaterial.color = color;
    }
}
