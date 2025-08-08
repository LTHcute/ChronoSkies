using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float speed = 5f;

    void Start()
    {
        SpawnMeteor();
    }

    void SpawnMeteor()
    {
        // Spawn trong vùng camera nhìn thấy
        Vector3 spawnPos = new Vector3(-8f, 5f, 0); // Góc trên trái
        GameObject meteor = Instantiate(meteorPrefab, spawnPos, Quaternion.identity);

        Rigidbody2D rb = meteor.GetComponent<Rigidbody2D>();
        if (rb == null) rb = meteor.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        // Bay chéo xuống phải
        Vector3 targetPos = new Vector3(8f, -5f, 0);
        Vector3 dir = (targetPos - spawnPos).normalized;
        rb.linearVelocity = dir * speed;
    }
}
