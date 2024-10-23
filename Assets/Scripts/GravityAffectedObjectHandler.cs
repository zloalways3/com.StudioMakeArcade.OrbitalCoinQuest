using UnityEngine;

public class GravityAffectedObjectHandler : MonoBehaviour
{
    [Header("Falling Object Settings")]
    [SerializeField] private float _fallSpeed = 3f;
    [SerializeField] private float _spawnXRange = 2.5f;

    private Camera _mainCamera;
    private float _cameraHeight;

    private void Start()
    {
        InitializeCamera();
        SetInitialPosition();
    }

    private void Update()
    {
        MoveObjectDown();
        CheckOutOfBounds();
    }

    private void InitializeCamera()
    {
        _mainCamera = Camera.main;
        _cameraHeight = _mainCamera.orthographicSize;
    }

    private void SetInitialPosition()
    {
        float randomX = Random.Range(-_spawnXRange, _spawnXRange);
        float startY = _cameraHeight + 1f;
        transform.position = new Vector3(randomX, startY, 0f);
    }

    private void MoveObjectDown()
    {
        transform.Translate(Vector3.down * _fallSpeed * Time.deltaTime);
    }

    private void CheckOutOfBounds()
    {
        if (transform.position.y < -_cameraHeight - 1f)
        {
            Destroy(gameObject);
        }
    }
}