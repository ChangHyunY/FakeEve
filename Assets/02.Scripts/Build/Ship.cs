using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private ShipType shipType;

    public void SetShipType(ShipType shipType)
    {
        this.shipType = shipType;
    }

    public void AddPart(GameObject part, Vector3 localPosition)
    {
        GameObject obj = Instantiate(part) as GameObject;
        obj.transform.localPosition = localPosition;
        obj.transform.SetParent(this.transform);
    }

    public string GetPartsList()
    {
        string partList = shipType.ToString() + " parts:\n\t";

        Transform[] trs = GetComponentsInChildren<Transform>();
        for(int i = 0; i < trs.Length; ++i)
        {
            partList += trs[i].gameObject.name + " ";
        }

        return partList;
    }
}
