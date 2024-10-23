using UnityEngine;

public class CharacterMovementHandler : MonoBehaviour
{
    [Header("Player Movement Settings")]
    [SerializeField] private float _smoothing = 0.1f;

    private Vector3 _touchPosition;
    private bool _isDragging = false;
    private Camera _mainCamera;

    private void Start()
    {
        InitializeCamera();
    }

    private void Update()
    {
        HandleInput();
        if (_isDragging)
        {
            UpdateTouchPosition();
            MovePlayer();
        }
    }

    private void InitializeCamera()
    {
        _mainCamera = Camera.main;
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDragging();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopDragging();
        }
    }

    private void StartDragging()
    {
        _isDragging = true;
    }

    private void StopDragging()
    {
        _isDragging = false;
    }

    private void UpdateTouchPosition()
    {
        _touchPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _touchPosition.z = 0;
    }

    private void MovePlayer()
    {
        Vector3 clampedPosition = ClampPosition(_touchPosition);
        transform.position = SmoothMove(transform.position, clampedPosition);
    }

    private Vector3 ClampPosition(Vector3 targetPosition)
    {
        float screenWidth = _mainCamera.orthographicSize * _mainCamera.aspect;
        float screenHeight = _mainCamera.orthographicSize;

        targetPosition.x = Mathf.Clamp(targetPosition.x, -screenWidth, screenWidth);
        targetPosition.y = Mathf.Clamp(targetPosition.y, -screenHeight, screenHeight);

        return targetPosition;
    }

    private Vector3 SmoothMove(Vector3 current, Vector3 target)
    {
        return Vector3.Lerp(current, target, _smoothing);
    }
}