using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [Header("Map infos")]
    [SerializeField] private MapDatabase mapDatabase;
    [SerializeField] private Transform mapSpawnPoint;
    [SerializeField] private GameObject actualMap;
    [Header("Player infos")]
    [SerializeField] private FlowerExperience playerExperience;

    [Header("Transition Info")]
    [SerializeField] private AnimationClip transitionAnimation;
    [SerializeField] private GameObject transition;
    [SerializeField] private GameObject positionHolder;
    [SerializeField] private GameEvent transitionFinish;
    [SerializeField] private GameEvent transitionHalfFInished;

    private int mapIndex = 0;
    //private List<String> usedMaps = new List<String>();
    
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

        StartCoroutine(TransitionRoutine(choosenMap.mapPrefab));
    }

    public void SpawnAnyMap(GameObject map)
    {
        StartCoroutine(TransitionRoutine(map));
    }

    private IEnumerator TransitionRoutine(GameObject map)
    {
        GameObject transitionInstance = Instantiate(transition, positionHolder.transform);

        yield return new WaitForSeconds(transitionAnimation.length / 2);
        transitionHalfFInished.Raise();

        if (actualMap != null)
        {
            Destroy(actualMap);
        }
        actualMap = Instantiate(map, mapSpawnPoint.position, Quaternion.identity);

        yield return new WaitForSeconds(transitionAnimation.length / 2);

        Destroy(transitionInstance);
        transitionFinish.Raise();
    }

}
