using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] private InputAction jump;
    [SerializeField] private float jumpForce;
    [SerializeField] private InputAction movement;
    [SerializeField] private float speed;
    private Vector3 _finalVector;

    private Vector3 _movementVector;
    private Rigidbody _rb;
    public bool IsGrounded { get; private set; }

    private void Awake() {
        this._rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        this._movementVector = this.movement.ReadValue<Vector2>();
        this._finalVector = new Vector3(this._movementVector.x, 0, this._movementVector.y);

        this._rb.velocity = this._finalVector * this.speed + new Vector3(0, this._rb.velocity.y, 0);
        if (IsGrounded && this.jump.triggered) this._rb.AddForce(Vector3.up * this.jumpForce, ForceMode.Impulse);
    }

    /// <summary>
    ///     Check if player is grounded every physics update.
    /// </summary>
    private void FixedUpdate() {
        GroundCheck();
    }

    private void OnEnable() {
        this.movement.Enable();
        this.jump.Enable();
    }

    private void OnDisable() {
        this.movement.Disable();
        this.jump.Disable();
    }

    /// <summary>
    ///     Send a ray below the player, store resulting boolean in a variable.
    /// </summary>
    private void GroundCheck() {
        IsGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}