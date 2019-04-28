using UnityEngine;

public class Fruit : MonoBehaviour
{

    public GameObject fruitSlicedPrefab;
    public GameObject droppedXPrefab;
    public float startForce = 10f;

    Rigidbody2D rb;
    float scale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * (startForce * (1f + .5f * GameDataManager.fruitSpeed)), ForceMode2D.Impulse);
        scale = (float)GameDataManager.fruitSize * .5f;
        transform.localScale = new Vector3(scale, scale, 1f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade" && !GameplayManager.isGameover)
        {
            ScoreManager.UpdateFruitSliced();
            Vector3 direction = (col.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
            slicedFruit.transform.localScale = new Vector3(scale, scale, scale);
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
