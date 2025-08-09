using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Manages the player's control over the RTS camera, including zooming, panning, and orbiting.
/// </summary>
public class CameraController : MonoBehaviour
{
    [Header("References")]
    [Tooltip("The CinemachineCamera that this script will control.")]
    [SerializeField] private CinemachineCamera _virtualCamera;

    [Header("Zoom Settings")]
    [Tooltip("How sensitive the zoom is to the mouse scroll wheel.")]
    [SerializeField] private float _zoomSensitivity = 0.1f;
    [Tooltip("The closest the camera can get to its target.")]
    [SerializeField] private float _minZoomDistance = 5f;
    [Tooltip("The farthest the camera can get from its target.")]
    [SerializeField] private float _maxZoomDistance = 50f;

    private GameControls _gameControls;
    private CinemachineThirdPersonFollow _thirdPersonFollow;

    private void Awake()
    {
        _gameControls = new GameControls();
        if (_virtualCamera != null)
        {
            _thirdPersonFollow = _virtualCamera.gameObject.GetComponent<CinemachineThirdPersonFollow>();
        }
    }

    private void OnEnable()
    {
        _gameControls.Camera.Enable();
    }

    private void OnDisable()
    {
        _gameControls.Camera.Disable();
    }

    private void LateUpdate()
    {
        HandleZoom();
    }

    /// <summary>
    /// Reads the scroll wheel input and adjusts the camera's distance from the target.
    /// </summary>
    private void HandleZoom()
    {
        if (_thirdPersonFollow == null)
            return;

        float scrollValue = _gameControls.Camera.Zoom.ReadValue<float>();

        // Ignore minor input noise to prevent accidental zooming.
        if (Mathf.Abs(scrollValue) < 0.1f)
        {
            return;
        }

        // Apply zoom based on scroll input and clamp the result.
        _thirdPersonFollow.CameraDistance -= scrollValue * _zoomSensitivity;
        _thirdPersonFollow.CameraDistance = Mathf.Clamp(_thirdPersonFollow.CameraDistance, _minZoomDistance, _maxZoomDistance);
    }
}