using UnityEngine;

public class sound : MonoBehaviour
{
    AudioSource play;
    public AudioClip aud;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        play = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(aud, this.transform.position);
        }
    }
}
