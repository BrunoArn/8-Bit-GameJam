using UnityEngine;

public class SpawnHole : MonoBehaviour
{
    [SerializeField] GameObject hole;
    public void SpawnHoleOnLocation()
    {
        Instantiate(hole, this.transform);
    }
}
