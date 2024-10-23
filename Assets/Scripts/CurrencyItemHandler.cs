using UnityEngine;

public class CurrencyItemHandler : MonoBehaviour
{
    [Header("Coin Settings")]
    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        InitializeAudioSource();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsPlayerCollision(collision))
        {
            HandleCoinPickup(collision);
        }
    }

    private void InitializeAudioSource()
    {
        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
        }
    }

    private bool IsPlayerCollision(Collider2D collision)
    {
        return collision.CompareTag(GameConstantsRepository.CharacterTag);
    }

    private void HandleCoinPickup(Collider2D player)
    {
        PlayPickupSound();
        AddPointsToPlayer(player);
        DisableCoin();
        DestroyCoinAfterSound();
    }

    private void PlayPickupSound()
    {
        if (_audioSource != null)
        {
            _audioSource.Play();
        }
    }

    private void AddPointsToPlayer(Collider2D player)
    {
        GameScoreTracker gameScoreTracker = player.GetComponent<GameScoreTracker>();
        if (gameScoreTracker != null)
        {
            gameScoreTracker.AddPoints(1);
        }
    }

    private void DisableCoin()
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    private void DestroyCoinAfterSound()
    {
        if (_audioSource != null && _audioSource.clip != null)
        {
            Destroy(gameObject, _audioSource.clip.length);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}