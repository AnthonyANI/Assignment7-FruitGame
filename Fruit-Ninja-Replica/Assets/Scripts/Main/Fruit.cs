using UnityEngine;

public class Fruit : MonoBehaviour
{

    public GameObject fruitSlicedPrefab;
    public GameObject droppedXPrefab;
    public float startForce = 7.5f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * (startForce * GameDataManager.fruitSpeed), ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade" && !GameplayManager.isGameover)
        {
            ScoreManager.UpdateFruitSliced();
            Vector3 direction = (col.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
            Destroy(slicedFruit, 3f);
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Background")
        {
            if (!GameplayManager.isGameover)
            {
                ScoreManager.UpdateFruitDropped();
                GameObject droppedX = Instantiate(droppedXPrefab, new Vector3(transform.position.x, transform.position.y + 1.1f, transform.position.z), Quaternion.LookRotation(Vector3.forward));
                Destroy(droppedX, 1f);
            }
            Destroy(gameObject);
        }
    }

}
