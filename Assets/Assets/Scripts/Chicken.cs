using UnityEngine;

// used for the chickens (Treated like a coin in the game)
public class Chicken : MonoBehaviour
{
    [SerializeField] int value = 1;
    [SerializeField] AudioClip collectClip;
    public PlayerController player;
    private void Awake()
    {
        player = FindFirstObjectByType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        RunState.Chickens += value;
        other.GetComponent<PlayerController>().PlayCollectEffect();
        if (collectClip != null) AudioSource.PlayClipAtPoint(collectClip, transform.position);
        Destroy(gameObject);
        player.UpdateSpeed();
    }
}
