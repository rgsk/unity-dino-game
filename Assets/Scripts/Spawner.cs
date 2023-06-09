using UnityEngine;

public class Spawner : MonoBehaviour {
    [System.Serializable]
    public struct SpawnableObject {
        public GameObject prefab;
        [Range(0f, 1f)]
        public float spawnChance;
        public float level2SpawnChance;
    }
    public SpawnableObject[] objects;
    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;
    private void OnEnable() {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }
    private void OnDisable() {
        CancelInvoke();
    }
    private void Spawn() {
        float spawnChance = Random.value;
        foreach (var obj in objects) {
            var spawnChanceConsidered = GameManger.Instance.level == 2 ? obj.level2SpawnChance : obj.spawnChance;
            if (spawnChance < spawnChanceConsidered) {
                GameObject obstacle = Instantiate(obj.prefab);
                obstacle.transform.position += transform.position;
                break;
            }
            spawnChance -= spawnChanceConsidered;

        }
        var decrease = Mathf.Min(1, GameManger.Instance.score / 1000);

        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate - decrease));
    }
}
