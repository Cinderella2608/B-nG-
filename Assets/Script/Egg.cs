using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Egg : MonoBehaviour
{
    public GameObject EggPrefab;
    public GameObject ExplosionPrefab;

    public float MinHeight;
    public float MaxHeight;
    private float TimeDestroy = 2f;
    private bool isEggCreated = false;

    public Score diem;
    public Score miss;


    private void Start()
    {
        Invoke("egg", 1f);  // Gọi phương thức "Egg" sau 1 giây và sau đó lặp lại mỗi 2 giây.
    }
    void egg()
    {
        if (!isEggCreated)
        {
            Vector3 Spawn = new Vector3(Random.Range(MinHeight, MaxHeight), 5f);
            GameObject Trung = Instantiate(EggPrefab, Spawn, Quaternion.identity);
            Destroy(Trung, TimeDestroy);

            isEggCreated = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chicken"))
        {
            diem.AddScore(1);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            miss.AddMissScore(1);
            DestroyEggWithExplosion();
        }
    }
    void DestroyEggWithExplosion()
    {
        GameObject Explosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(Explosion, 1f);
        Destroy(gameObject);
    }
}
