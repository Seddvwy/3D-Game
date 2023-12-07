using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerteEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;

    public int enemyCount;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while(enemyCount < 10)
        {
            xPos = Random.Range(50, 91);
            zPos = Random.Range(22, 70);
            Instantiate(theEnemy, new Vector3(xPos, 23, zPos),Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }

    
}
