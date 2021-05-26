using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private DefaultInputMap _defaultInputMap;
    private void Awake()
    {
        if (_defaultInputMap == null)
        {
            _defaultInputMap = new DefaultInputMap();
        }
        _defaultInputMap.Player.Fire.performed += ctx => Fire();
        _defaultInputMap.Player.Move.performed += ctx => Move();
        _defaultInputMap.Player.Run.performed += ctx => Run();
        _defaultInputMap.Player.Look.performed += ctx => Look();
        _defaultInputMap.Player.Interact.performed += ctx => Interact();
        _defaultInputMap.Player.Reload.performed += ctx => Reload();
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

    private void Move()
    {
        Debug.Log("Move");
    }

    private void Run()
    {
        Debug.Log("Run");
    }

    private void Look()
    {
        Debug.Log("Look");
    }

    private void Interact()
    {
        Debug.Log("Interact");
    }

    private void Reload()
    {
        Debug.Log("Reload");
    }
}
