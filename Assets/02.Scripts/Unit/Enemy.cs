using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform tf;

    private void Start()
    {
        tf = GetComponent<Transform>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(1))
        {
            BattleShip._instance.AngleToDirection(tf);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent)
        {
            other.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            other.gameObject.SetActive(false);
        }

        this.gameObject.SetActive(false);
    }
}
