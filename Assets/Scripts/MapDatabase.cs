using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapDatabase", menuName = "Scriptable Objects/MapDatabase")]
public class MapDatabase : ScriptableObject
{
    public List<MapaData> mapsAvailable;
}
