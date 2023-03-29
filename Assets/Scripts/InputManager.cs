using UnityEngine;
using UnityEngine.InputSystem;
[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
    #region Events
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;
    #endregion
    private InputPlayer playerControls;
    private Camera mainCamera;
    // Start is called before the first frame update

    private void Awake() {
        playerControls = new InputPlayer();
        mainCamera= Camera.main;
    }

    private void OnEnable() {
        playerControls.Enable();
    }
    private void OnDisable() {
        playerControls.Disable();
    }
    void Start()
    {
        playerControls.Player.primaryContact.started += ctx => StartTouchPrimary(ctx);
        playerControls.Player.primaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartTouchPrimary(InputAction.CallbackContext ctx){
        if(OnStartTouch != null)OnStartTouch(utils.ScreenToWorld(mainCamera,playerControls.Player.primaryPosition.ReadValue<Vector2>()),(float)ctx.startTime);
    }
    private void EndTouchPrimary(InputAction.CallbackContext ctx){
        if(OnEndTouch != null)OnEndTouch(utils.ScreenToWorld(mainCamera,playerControls.Player.primaryPosition.ReadValue<Vector2>()),(float)ctx.time);
    }

    public Vector2 primaryPosition(){
        return utils.ScreenToWorld(mainCamera,playerControls.Player.primaryPosition.ReadValue<Vector2>());
    }

}
