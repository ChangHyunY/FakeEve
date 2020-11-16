using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryMethod : MonoBehaviour
{
    public Race type = Race.Caldari;

    public RaceFactory GetFactory()
    {
        RaceFactory factory = null;

        switch(type)
        {
            case Race.Caldari:
                factory = GetComponent<CaldariFactory>();
                break;

            case Race.Amarr:
                factory = GetComponent<AmarrFactory>();
                break;

            case Race.Gallente:
                factory = GetComponent<GallenteFactory>();
                break;

            case Race.Minmatar:
                factory = GetComponent<MinmatarFactory>();
                break;
        }

        return factory;
    }

    public void ChangeFactory()
    {
        switch(type)
        {
            case Race.Caldari:
                type = Race.Amarr;
                break;

            case Race.Amarr:
                type = Race.Gallente;
                break;

            case Race.Gallente:
                type = Race.Minmatar;
                break;

            case Race.Minmatar:
                type = Race.Caldari;
                break;
        }
    }
}
