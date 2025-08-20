using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private MapDatabase mapDatabase;
    [SerializeField] private Transform mapSpawnPoint;
    [SerializeField] private FlowerExperience playerExperience;

    private int mapIndex = 0;
    //private List<String> usedMaps = new List<String>();
    [SerializeField] private GameObject actualMap;


    public void SpawnNextMap()
    {
        mapIndex++;

        bool isStore = mapIndex % 5 == 0;
        int mapDificulty = playerExperience.level;

        var availableMaps = mapDatabase.mapsAvailable
        .Where(map => map.mapType == (isStore ? MapType.store : MapType.normal))
        .Where(map => map.dificulty <= mapDificulty).ToList();
        //.Where(map => !usedMaps.Contains(map.mapId)).ToList();

        if (availableMaps.Count == 0)
        {
            Debug.Log("ta sem mapa");
            return;
        }
        int randomMap = UnityEngine.Random.Range(0, availableMaps.Count);
        var choosenMap = availableMaps[randomMap];
        // usedMaps.Add(choosenMap.mapId);

        if (actualMap != null)
        {
            Destroy(actualMap);
        }
        actualMap = Instantiate(choosenMap.mapPrefab, mapSpawnPoint.position, Quaternion.identity);
    }

}
