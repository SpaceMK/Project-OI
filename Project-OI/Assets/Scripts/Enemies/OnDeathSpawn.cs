using UnityEngine;

public class OnDeathSpawn : MonoBehaviour
{
    [SerializeField] Transform spawnPosition;
    [SerializeField] GameObject spawnObject;
    [SerializeField][Range(0f,1f)] float spawnForce;

    void Start()
    {
        IEnemy enemyDeath = gameObject.GetComponent(typeof(IEnemy)) as IEnemy;
        enemyDeath.OnDeath += EnemyIsDead;
    }


    void EnemyIsDead()
    {
        var enemyObject = Instantiate(spawnObject,spawnPosition.position,Quaternion.identity)as GameObject;
        enemyObject.GetComponent<Rigidbody>().velocity = Vector3.forward * spawnForce; 
    }
}
