using UnityEngine;

public enum MapType { normal, store, boss }

[CreateAssetMenu(fileName = "MapaData", menuName = "Scriptable Objects/MapaData")]
public class MapaData : ScriptableObject
{
    public string mapId;
    public int dificulty;
    public MapType mapType;
    public GameObject mapPrefab;

}
