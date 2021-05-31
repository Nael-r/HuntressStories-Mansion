using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerControllerChannelSO _playerControllerChannel;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerLook _playerLook;
    private DefaultInputMap _defaultInputMap;

    private void Awake()
    {
        if (_defaultInputMap == null)
        {
            _defaultInputMap = new DefaultInputMap();
        }
        if(_playerMovement == null)
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }
        if(_playerLook == null)
        {
            _playerLook = GetComponent<PlayerLook>();
        }
        SubscribePlayingInputs();
        SubscribeInteractionInputs();
        SubscribeEvents();
    }
    private void SubscribePlayingInputs()
    {
        _defaultInputMap.Player.Fire.performed += ctx => Fire();
        _defaultInputMap.Player.Move.performed += ctx => Move(ctx);
        _defaultInputMap.Player.Move.canceled += ctx => StopMoving();
        _defaultInputMap.Player.Run.performed += ctx => Run();
        _defaultInputMap.Player.Run.canceled += ctx => StopRunning();
        _defaultInputMap.Player.Look.performed += ctx => Look(ctx);
        _defaultInputMap.Player.Look.canceled += ctx => StopLook();
        _defaultInputMap.Player.Interact.performed += ctx => Interact();
        _defaultInputMap.Player.Reload.performed += ctx => Reload();
    }

    private void SubscribeInteractionInputs()
    {
        _defaultInputMap.Interaction.Cancel.canceled += ctx => InteractCancel();
    }

    private void SubscribeEvents()
    {
        _playerControllerChannel.OnActivateInteractionControls += ActivateInteractionInput;
        _playerControllerChannel.OnActivatePlayingControls += ActivatePlayingInput;
    }

    private void ActivatePlayingInput()
    {
        if (!_defaultInputMap.Player.enabled)
        {
            _defaultInputMap.Player.Enable();
        }
        _defaultInputMap.Interaction.Disable();
    }

    private void ActivateInteractionInput()
    {
        _defaultInputMap.Interaction.Enable();
        if (_defaultInputMap.Player.enabled)
        {
            _defaultInputMap.Player.Disable();
        }
    }

    private void OnEnable()
    {
        _defaultInputMap.Enable();
    }

    private void OnDisable()
    {
        _defaultInputMap.Disable();
    }

    private void Fire()
    {
        Debug.Log("Fire");
    }

    private void Move(CallbackContext ctx)
    {
        _playerMovement.StartMoving(ctx.ReadValue<Vector2>());
    }
    private void StopMoving()
    {
        _playerMovement.StopMoving();
    }

    private void Run()
    {
        _playerMovement.StartRunning();
    }
    private void StopRunning()
    {
        _playerMovement.StopRunning();
    }
    private void Look(CallbackContext ctx)
    {
        _playerLook.StartLook(ctx.ReadValue<Vector2>());
    }
    private void StopLook()
    {
        _playerLook.StopLook();
    }
    private void Interact()
    {
        _playerControllerChannel.Interact();
    }

    private void Reload()
    {
        Debug.Log("Reload");
    }

    private void InteractCancel()
    {
        _playerControllerChannel.InteractCancel();
    }
}
