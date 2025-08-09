using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Manages player input for controlling the RTS camera.
/// </summary>
public class CameraController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CinemachineCamera _virtualCamera;

    [Header("Zoom Settings")]
    [Tooltip("How sensitive the zoom is to the mouse scroll wheel.")]
    [SerializeField] private float _zoomSensitivity = 0.1f;
    [Tooltip("How quickly the camera smoothes to the target zoom distance. Smaller is faster.")]
    [SerializeField] private float _zoomDampening = 0.2f;
    [SerializeField] private float _minZoomDistance = 5f;
    [SerializeField] private float _maxZoomDistance = 50f;

    private GameControls _gameControls;
    private CinemachineThirdPersonFollow _thirdPersonFollow;

    // Variables for dampened zoom
    private float _currentTargetDistance;
    private float _zoomVelocity; // Required by SmoothDamp

    private void Awake()
    {
        _gameControls = new GameControls();
        if (_virtualCamera != null)
        {
            _thirdPersonFollow = _virtualCamera.gameObject.GetComponent<CinemachineThirdPersonFollow>();
            // Initialize our target distance to the camera's starting distance.
            _currentTargetDistance = _thirdPersonFollow.CameraDistance;
        }
    }

    private void OnEnable() => _gameControls.Camera.Enable();
    private void OnDisable() => _gameControls.Camera.Disable();

    private void LateUpdate()
    {
        HandleZoomInput();
        ApplyDampenedZoom();
    }

    /// <summary>
    /// Reads scroll input and updates the target zoom distance.
    /// </summary>
    private void HandleZoomInput()
    {
        float scrollValue = _gameControls.Camera.Zoom.ReadValue<float>();
        if (Mathf.Abs(scrollValue) < 0.1f)
            return;

        // Adjust the TARGET distance, not the actual distance.
        _currentTargetDistance -= scrollValue * _zoomSensitivity;
        _currentTargetDistance = Mathf.Clamp(_currentTargetDistance, _minZoomDistance, _maxZoomDistance);
    }

    /// <summary>
    /// Smoothly interpolates the camera's actual distance towards the target distance.
    /// </summary>
    private void ApplyDampenedZoom()
    {
        if (_thirdPersonFollow == null)
            return;

        _thirdPersonFollow.CameraDistance = Mathf.SmoothDamp(
            _thirdPersonFollow.CameraDistance,
            _currentTargetDistance,
            ref _zoomVelocity,
            _zoomDampening
        );
    }
}