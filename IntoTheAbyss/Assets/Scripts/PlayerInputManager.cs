using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField]
    private Transform[] _spawnPoints;

    private bool _keyboardConn = false;

    private List<Gamepad> _joinedGamepads = new List<Gamepad>();

    private int connectedPlayers = 0;

    private void Update()
    {
        if (Keyboard.current == null) return;

        if(!_keyboardConn && connectedPlayers < 2 && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            var player = PlayerInput.Instantiate(_playerPrefab, controlScheme: "WASD", pairWithDevice: Keyboard.current);

            if(_spawnPoints.Length > 0)
            {
                player.transform.position = _spawnPoints[0].position;
            }

            _keyboardConn = true;
            connectedPlayers++;

        }

        foreach (var gamepad in Gamepad.all)
        {
            if (!_joinedGamepads.Contains(gamepad) && connectedPlayers < 2 && gamepad.buttonSouth.wasPressedThisFrame)
            {
                PlayerInput.Instantiate(_playerPrefab, controlScheme: "Gamepad",pairWithDevice: gamepad);

                _joinedGamepads.Add(gamepad);
                connectedPlayers++;
            }
        }
    }
}
