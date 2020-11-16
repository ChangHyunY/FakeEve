using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Race
{
    Caldari,
    Amarr,
    Gallente,
    Minmatar
}

public abstract class RaceFactory : MonoBehaviour
{
    public abstract UnitBuilding makeUnitBuilding();

    public IEnumerator SpawnManager(int poolSize, GameObject[] enemyPool)
    {
        while (true)
        {
            // 2초 간격으로 생성
            yield return new WaitForSeconds(2.0f);

            for (int i = 0; i < poolSize; i++)
            {
                if (enemyPool[i].activeSelf == true)
                    continue;

                float x = Random.Range(-5, 6);
                float y = Random.Range(-5, 6);
                float z = Random.Range(-5, 6);

                enemyPool[i].transform.position = new Vector3(enemyPool[i].transform.position.x + x, enemyPool[i].transform.position.y + y, enemyPool[i].transform.position.z + z);
                enemyPool[i].SetActive(true);

                break;
            }
        }
    }
}