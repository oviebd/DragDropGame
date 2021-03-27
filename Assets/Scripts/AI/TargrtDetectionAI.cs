using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargrtDetectionAI : MonoBehaviour
{
    [SerializeField] private GameObject _playerObj;
    [SerializeField] private float _searchRadius = 5;
    [SerializeField] private float _searchDistance = 5;
    [SerializeField] private float _searchMaxAngle = 80;

    private bool _isTargetLocked = false;
	//private List<EnemyController> closestEnemyList = new List<EnemyController>();

	/* void Start()
    {
        getAllEnemyInARadious(_searchRadius, _searchDistance, _searchMaxAngle);
    }

    void Update()
    {
        getAllEnemyInARadious(_searchRadius, _searchDistance, _searchMaxAngle);
    }


   void getAllEnemyInARadious(float maxRadius, float maxDistance, float maxAngle)
    {
        EnemyController[] enemys = FindObjectsOfType<EnemyController>();
        int i = 0;
        closestEnemyList = new List<EnemyController>();
        while (i < enemys.Length)
        {

            float distance = Vector3.Distance(enemys[i].transform.position, _playerObj.transform.position);
            //  Debug.Log("Distance : " + distance);
            float angle = getAngle(_playerObj.transform, enemys[i].gameObject.transform);

            if (distance <= maxDistance && angle <= maxAngle)
            {

                closestEnemyList.Add(enemys[i]);
            }

            // Debug.Log("Enemy Num : " + (i + 1) + "Name :  " + enemys[i].gameObject.name);
            //Debug.Log("Enemy distance : " + distance);
            //Debug.Log("Angle is : " + angle);

            // getAngle(weapon.transform, _target.transform);
            i++;
        }
        getClosestEnemy(closestEnemyList);
    }
*/

	float getAngle(Transform playerPos, Transform target)
    {
        Vector3 direction = target.position - playerPos.position;
        //Debug.Log("Direction : " + direction);
        // direction = target.InverseTransformDirection(direction);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Debug.Log("Angle: " +angle);
        //  Debug.Log("ATan: with deg " + Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        return angle;
    }

/*    EnemyController getClosestEnemy(List<EnemyController> enemies)
    {
        float minDistance = _searchDistance + 20;
        EnemyController enemy = null;
        for (int i = 0; i < enemies.Count; i++)
        {
            float distance = Vector3.Distance(enemies[i].transform.position, _playerObj.transform.position);
            //Debug.Log("Distance in sort : " + distance);
            if (distance <= minDistance)
            {
                minDistance = distance;
                enemy = enemies[i];
            }
        }

        if (enemy != null)
            Debug.Log("Closest Enemy Name : " + enemy.name);

        return enemy;
    }*/

}
