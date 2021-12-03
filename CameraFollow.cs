using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private readonly Vector3 _offset = new Vector3(0, 4, -10);
    private GameObject _player;
    private Vector3 _playerPosition;

    private void Awake() {
        this._player = GameObject.Find("Player");
    }

    /// <summary>
    /// Storing player's position in a variable every update.
    /// </summary>
    private void Update() {
        this._playerPosition = this._player.transform.position;
    }

    /// <summary>
    /// Follow player.
    /// </summary>
    private void LateUpdate() {
        transform.position = this._playerPosition + this._offset;
    }
}