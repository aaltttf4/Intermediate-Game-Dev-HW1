using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    public GameObject text;
    void Start()
    {

    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            text.SetActive(false);
        }
    }
}
