using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // Prefab del enemigo
    public Transform[] spawnPoints;  // Array de puntos de spawn
    public float spawnDelay = 5f;    // Tiempo entre cada aparición de enemigos
    public float spawnStartTime = 30f; // Tiempo en el que se empieza a spawnear (en segundos)
    private float timer = 0f;        // Temporizador para el spawn

    void Update()
    {
        // Incrementa el temporizador con el tiempo que ha pasado desde el último frame
        timer += Time.deltaTime;

        // Chequea si el tiempo de juego ha alcanzado el tiempo de inicio del spawn y si es hora de spawnear
        if (Time.time >= spawnStartTime && timer >= spawnDelay)
        {
            SpawnEnemy();
            timer = 0f;  // Resetea el temporizador para el siguiente spawn
        }
    }

    // Función que spawnea un enemigo en un punto aleatorio
    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length); // Selecciona un punto de spawn aleatorio
        Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
    }
}
