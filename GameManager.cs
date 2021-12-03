using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI debugText;
    private PlayerController _player;

    private void Awake() {
        this._player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    
    private void Update() {
        this.debugText.text = this._player.IsGrounded ? "Grounded" : "!Grounded";
    }
}