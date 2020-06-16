using System;
using UnityEngine;

public class StaticTarget : MonoBehaviour,ITakeDamage,IEnemy
{ 
    [SerializeField] float targetHealth;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] bool targetEnabled;
    [SerializeField] Color targetIsDead, targetIsAlive;
    Material targetMaterial;

    public Action OnDeath { get; set;}

    void Start()
    {
        targetMaterial = meshRenderer.materials[1];
        ChangeTargetColor(!targetEnabled);
    }

    public void TakeDamage(float damage)
    {
        targetHealth -= damage;
        if (targetHealth <= 0f)
        {
            ChangeTargetColor(true);
            OnDeath?.Invoke();
        }
    }

    
    void ChangeTargetColor(bool dead)
    {
        var color = dead ? targetIsDead : targetIsAlive;
        targetMaterial.color = color;
    }
}
