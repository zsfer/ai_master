using Unity.AI.Navigation;
using UnityEngine;

[RequireComponent(typeof(NavMeshSurface))]
public class BakedNavmesh : MonoBehaviour
{
    [Header("obstacle stuff")]
    [SerializeField] GameObject[] _obstacleList;
    [SerializeField] NavMeshSurface _surf;

    [Header("random map stuff")]
    [SerializeField] Vector2 _mapSize;
    [SerializeField] float _noiseScale;
    [SerializeField] float _spawnThreshold;

    void Awake()
    {
        SpawnObstacles();
        BakeNavmesh();
    }

    void SpawnObstacles()
    {
        // determine spawn pos of objects using perlin noise
        for (float y = 0; y < _mapSize.y; y++)
        {
            for (float x = 0; x < _mapSize.x; x++)
            {
                float xCoord = x / _mapSize.x;
                float yCoord = y / _mapSize.y;

                float smp = Mathf.PerlinNoise(xCoord * _noiseScale + 0.1f, yCoord * _noiseScale + 0.1f);

                if (smp > _spawnThreshold)
                {
                    var worldPos = new Vector3(
                        (xCoord * _mapSize.x) - _mapSize.x / 2,
                        0,
                        (yCoord * _mapSize.y) - _mapSize.y / 2
                    );

                    var obst = Instantiate(
                            _obstacleList[Random.Range(0, _obstacleList.Length)],
                            worldPos,
                            Quaternion.Euler(Vector3.up * Random.Range(0, 360f))
                    );
                }
            }
        }
    }

    void BakeNavmesh() => _surf.BuildNavMesh();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Awake(); // call both funcs
    }
}
