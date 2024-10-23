using UnityEngine;

public class AdversaryBehaviorManager : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameConstantsRepository.CharacterTag))
        {
            _audioSource.Play();
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            GameSessionManager.Instance.LoseLife(5);
            Destroy(gameObject, _audioSource.clip.length);
        }
    }
}