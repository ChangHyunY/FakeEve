using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleShip : MonoBehaviour
{
    public static BattleShip _instance = null;

    private Transform battleship;

    public Vector3 perp;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        if (_instance != this)
        {
            Destroy(_instance);
        }
    }

    private void Start()
    {
        battleship = GetComponent<Transform>();

        perp = Vector3.Cross(battleship.forward, battleship.right);
    }

    private void Update()
    {
        // 정면 벡터
        Debug.DrawLine(battleship.position, battleship.forward * 5, Color.green);

        // 수직 벡터
        Debug.DrawLine(battleship.position, perp * 5, Color.red);
    }

    public void AngleToDirection(Transform target)
    {
        Vector3 dirToTarget = target.position - battleship.position;

        battleship.LookAt(target);

        battleship.Rotate(90, 0, 0);

        // 수직 벡터 연산
        perp = Vector3.Cross(battleship.forward, battleship.right);
    }

    public Vector3 GetPerp() { return perp; }

    public Transform GetTransform() { return GetComponent<Transform>(); }
}
