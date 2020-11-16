using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryMethodUse : MonoBehaviour
{
    public static FactoryMethodUse _instance = null;

    private FactoryMethod factoryMethod;

    private RaceFactory factory;

    private UnitBuilding building;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(_instance);
        }
    }

    private void Start()
    {
        factoryMethod = GetComponent<FactoryMethod>();

        factory = factoryMethod.GetFactory();
    }

    public void ChangFactory()
    {
        factoryMethod.ChangeFactory();

        factory = factoryMethod.GetFactory();
    }

    public void makeUnit()
    {
        building = factory.makeUnitBuilding();

        building.produce();
    }
}