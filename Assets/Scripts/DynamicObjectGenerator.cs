using UnityEngine;
using UnityEngine.Serialization;

public class DynamicObjectGenerator : MonoBehaviour
{
    [FormerlySerializedAs("_coinPrefab")]
    [Header("Prefabs")]
    [SerializeField] private GameObject _coinPrefabsObject;
    [FormerlySerializedAs("_spherePrefabs")] [SerializeField] private GameObject[] _spherePrefabsObject;

    [Header("Spawn Settings")]
    [SerializeField] private float _spawnInterval = 0.1f;
    [SerializeField] private int _coinSpawnChance = 80;

    private void Start()
    {
        StartSpawning();
    }

    private void StartSpawning()
    {
        InvokeRepeating(nameof(SpawnRandomObject), 0f, _spawnInterval);
    }

    private void SpawnRandomObject()
    {
        if (ShouldSpawnCoin())
        {
            SpawnObject(_coinPrefabsObject);
        }
        else
        {
            SpawnObject(GetRandomSpherePrefab());
        }
    }

    private bool ShouldSpawnCoin()
    {
        return Random.Range(0, 100) < _coinSpawnChance;
    }

    private GameObject GetRandomSpherePrefab()
    {
        int randomIndex = Random.Range(0, _spherePrefabsObject.Length);
        return _spherePrefabsObject[randomIndex];
    }

    private void SpawnObject(GameObject prefab)
    {
        GameObject instance = Instantiate(prefab, GetRandomSpawnPosition(), Quaternion.identity);
        instance.transform.parent = transform.parent;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float x = Random.Range(-8f, 8f);
        float y = Random.Range(-4f, 4f);
        return new Vector3(x, y, 0);
    }
}