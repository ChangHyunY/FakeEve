using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Engineer
{
    public void Construct(IShipBuilder shipBuilder)
    {
        shipBuilder.BuildBody();
        shipBuilder.BuildWing();
    }
}
