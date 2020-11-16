using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 'abstract Builder' class
interface IShipBuilder
{
    Ship GetShip();
    
    void BuildBody();
    void BuildWing();
}

public enum ShipType
{
    Frigate,
    Destroyer,
    Cruiser,
    Battlecruiser,
    Battleship
}
