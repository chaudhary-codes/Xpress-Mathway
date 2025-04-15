using UnityEngine;

public class OptionSpawner : MonoBehaviour
{
    [SerializeField] private OptionBlock optionPrefab;
    [SerializeField] private Transform spawnPoint;  // set this to an empty Transform in front of runner
    [SerializeField] private float laneOffset = 6f; // horizontal spacing

    public void SpawnOptions(int[] values)
    {
        int count = values.Length;
        float startX = -1 + spawnPoint.position.x - laneOffset * (count - 1) / 2f;

        for (int i = 0; i < count; i++)
        {
            Vector3 pos = new Vector3(startX + i * laneOffset,
                                      spawnPoint.position.y,
                                      spawnPoint.position.z);
        
            OptionBlock block = Instantiate(optionPrefab, pos, Quaternion.identity);
            block.SetValue(values[i]);
        }
    }

    public void ClearOptions()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }


}