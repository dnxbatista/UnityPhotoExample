using UnityEngine;
using UnityEngine.InputSystem;

public class CCameraControler : MonoBehaviour
{
    #region Variables
    [SerializeField] private Transform _onFaceTransform;
    [SerializeField] private RenderTexture _pictureRenderTexture;
    [SerializeField] private RenderTexture _cameraRenderTexture;
    [SerializeField] private Camera _pictureCamera; // I Know there are a better names for this but, is not a big thing in this project
    [SerializeField] private Material _cameraRenderMaterial;

    [SerializeField] private Transform _itemStarPos;

    private InputAction _useCameraAction;
    private InputAction _faceCameraAction;
    private InputAction _restartCameraAction;

    private int numberOfPicturesTaken = 0;
    #endregion

    #region Engine Functions
    private void Start()
    {
        _cameraRenderMaterial.SetTexture("_MainTexture", _cameraRenderTexture);

        _useCameraAction = InputSystem.actions.FindAction("Attack");
        _faceCameraAction = InputSystem.actions.FindAction("GetCamera");
        _restartCameraAction = InputSystem.actions.FindAction("RestartCamera");
    }

    private void Update()
    {
        if (_useCameraAction.WasPressedThisFrame())
        {
            _pictureCamera.Render();

            //_cameraRenderMaterial.mainTexture = _pictureRenderTexture;
            _cameraRenderMaterial.SetTexture("_MainTexture", _pictureRenderTexture);

            numberOfPicturesTaken++;
            Debug.Log($"Snapshot taken! {numberOfPicturesTaken}");
        }

        if (_restartCameraAction.WasPressedThisFrame())
        {
            _cameraRenderMaterial.SetTexture("_MainTexture", _cameraRenderTexture);
        }

        if (_faceCameraAction.IsPressed())
        {
            transform.position = Vector3.Lerp(transform.position, _onFaceTransform.position, 8f * Time.deltaTime);
        } else
        {
            transform.position = Vector3.Lerp(transform.position, _itemStarPos.position, 8f * Time.deltaTime);
        }

    }
    #endregion
}