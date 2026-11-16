using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleLevelGenerator : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public int gridSize = 80;
    public float scale = 4f;
    public float wallThreshold = 0.55f;
    public float seed = 0f;

    Transform container;

    void Start()
    {
        Generate();
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            seed = Random.Range(0f, 1000f);
            Generate();
        }
    }

    void Generate()
    {
        if (container == null)
        {
            container = new GameObject("Level Container").transform;
            container.SetParent(transform, false);
        }

        for (int i = container.childCount - 1; i >= 0; i--)
        {
            Destroy(container.GetChild(i).gameObject);
        }

        int walls = 0;
        int floors = 0;

        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                // The seed is added to the coordinates BEFORE dividing by scale.
                float noiseValue = Mathf.PerlinNoise((x + seed) / scale, (z + seed) / scale);

                GameObject prefab;
                if (noiseValue > wallThreshold)
                {
                    prefab = wallPrefab;
                    walls++;
                }
                else
                {
                    prefab = floorPrefab;
                    floors++;
                }

                GameObject tile = Instantiate(prefab, container);
                tile.transform.localPosition = new Vector3(x, 0f, z);
            }
        }

        Debug.Log("Level built with seed " + seed.ToString("F1") + ". Walls: " + walls + "  Floors: " + floors);
    }
}
