using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] BombData bombData;
    float timer;
    List<Collider2D> colliders = new ();
    [SerializeField]float maxScale, maxFrequency;

    void Start()
    {
        StartCoroutine(Explosion());

    }

    IEnumerator Explosion()
    {
        timer = 0;
        while (timer < bombData.timeToExplode)
        {
            Debug.Log(Mathf.Sin(Time.deltaTime * (timer / bombData.timeToExplode) * 70) * 0.5f + 1f);
            transform.localScale = new Vector3(Mathf.Sin(Time.deltaTime * maxFrequency) * maxScale / 2 + maxScale /2, Mathf.Sin(Time.deltaTime * maxFrequency) * maxScale / 2 + maxScale / 2);
            timer += Time.deltaTime;
            yield return null;
        }
        Collider2D[] collidersX = Physics2D.OverlapBoxAll(transform.position, new Vector2(bombData.rangeX, 0.5f), 1f);
        Collider2D[] collidersY = Physics2D.OverlapBoxAll(transform.position, new Vector2(0.5f, bombData.rangeY), 1f);
        colliders.AddRange(collidersX);
        colliders.AddRange(collidersY);
        Debug.Log(colliders.Count);

        foreach (Collider2D collider in colliders)
        {
            Debug.LogError(collider.gameObject.name, collider.gameObject);
            if (collider.TryGetComponent(out HP hp))
            {
                hp.TakeDamage(bombData.dmg);
            }
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector2(bombData.rangeX, 0.5f));

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector2(0.5f, bombData.rangeY));
    }
}
