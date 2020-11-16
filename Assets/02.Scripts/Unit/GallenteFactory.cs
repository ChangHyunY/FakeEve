using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GallenteFactory : RaceFactory 
{
    public GameObject thorax;
    public int poolSize = 10;       // Object Pool Size
    GameObject[] enemyPool;

    public override UnitBuilding makeUnitBuilding()
    {
        enemyPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; ++i)
        {
            enemyPool[i] = Instantiate(thorax) as GameObject;
            enemyPool[i].name = "Thorax" + i;
            enemyPool[i].SetActive(false);
        }

        // 생성방식 오브젝트 풀 방식으로 변경
        //Instantiate(thorax, thorax.transform.localPosition, thorax.transform.localRotation);

        StartCoroutine(SpawnManager(poolSize, enemyPool));

        return new Thorax();
    }
}
