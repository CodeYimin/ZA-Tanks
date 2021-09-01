using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI
{
    public class CameraFollowPlayers : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private float padding = 5;

        private PlayerManager _playerManager;
        private readonly List<GameObject> _players = new List<GameObject>();

        private void Awake()
        {
            _playerManager = FindObjectOfType<PlayerManager>();
            _playerManager.OnPlayerSpawn += OnPlayerSpawn;
            _playerManager.OnPlayerDestroy += OnPlayerDestroy;
        }

        private void OnPlayerSpawn(GameObject player)
        {
            _players.Add(player);
        }

        private void OnPlayerDestroy(GameObject player)
        {
            _players.Remove(player);
        }
        
        private void LateUpdate()
        {
            if (_players.Count <= 0) return;
            
            float xMin = _players.Min((player) => player.transform.position.x);
            float xMax = _players.Max((player) => player.transform.position.x);
            
            float yMin = _players.Min((player) => player.transform.position.y);
            float yMax = _players.Max((player) => player.transform.position.y);
        
            camera.orthographicSize = Math.Max((xMax - xMin) / camera.aspect, yMax - yMin) / 2 + padding;
            camera.transform.position = new Vector3((xMin + xMax) / 2, (yMin + yMax) / 2, -10);
        
        }
    }
}
