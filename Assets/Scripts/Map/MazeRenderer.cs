using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Map
{
    public class MazeRenderer : MonoBehaviour
    {

        [SerializeField] private int mazeHeight;
        [SerializeField] private int mazeWidth;
        [SerializeField] private Transform wallPrefab;
        [SerializeField] private float wallLength;
        [SerializeField] private float wallThickness;
        [SerializeField] private float wallRemovalPercentage;
        [SerializeField] private bool printToConsole;

        private PlayerManager _playerManager;
        private float mazeWorldWidth;
        private float mazeWorldHeight;
        private Vector2 mazeWorldOffset;

        private void Awake()
        {
            _playerManager = FindObjectOfType<PlayerManager>();
            
            mazeWorldWidth = mazeWidth * wallLength;
            mazeWorldHeight = mazeHeight * wallLength;

            mazeWorldOffset = new Vector2(mazeWorldWidth * -1 / 2, mazeWorldHeight * -1 / 2);
        }
        
        private void OnEnable()
        {
            _playerManager.OnPlayerSpawn += OnPlayerSpawn;
        }

        private void Start()
        {
            MazeGenerator.Generate(mazeWidth, mazeHeight, out bool[,] horizontalWalls, out bool[,] verticalWalls);
            MazeGenerator.RandomlyRemoveWalls(horizontalWalls, verticalWalls, wallRemovalPercentage);
            Draw(horizontalWalls, verticalWalls);
            
            if (printToConsole)
            {
                MazeGenerator.PrintToConsole(horizontalWalls, verticalWalls);
            }
        }

        private void OnPlayerSpawn(GameObject player)
        {
            Vector2 playerMazePos =
                new Vector2(Random.Range(0, mazeWidth), Random.Range(0, mazeHeight));
            
            Vector2 playerPos =
                new Vector2(playerMazePos.x * wallLength + wallLength / 2, playerMazePos.y * wallLength + wallLength / 2) + mazeWorldOffset;

            Vector3 playerRotation = Vector3.forward * Random.Range(0, 360);
            
            player.transform.position = playerPos;
            player.transform.eulerAngles = playerRotation;
        }

        void Draw(bool[,] horizontalWalls, bool[,] verticalWalls)
        {
            //Render Main Walls
            Transform topWall = Instantiate(wallPrefab, transform);
            topWall.position = new Vector2(mazeWorldWidth / 2, mazeWorldHeight) + mazeWorldOffset;
            topWall.localScale = new Vector2(mazeWidth * wallLength + wallThickness, wallThickness);
            topWall.eulerAngles = Vector3.zero;
            
            Transform botWall = Instantiate(wallPrefab, transform);
            botWall.position = new Vector2(mazeWorldWidth / 2, 0) + mazeWorldOffset;
            botWall.localScale = new Vector2(mazeWidth * wallLength + wallThickness, wallThickness);
            botWall.eulerAngles = Vector3.zero;
            
            Transform rightWall = Instantiate(wallPrefab, transform);
            rightWall.position = new Vector2(mazeWorldWidth, mazeWorldHeight / 2) + mazeWorldOffset;
            rightWall.localScale = new Vector2(mazeHeight * wallLength + wallThickness, wallThickness);
            rightWall.eulerAngles = Vector3.forward * 90;
            
            Transform leftWall = Instantiate(wallPrefab, transform);
            leftWall.position = new Vector2(0, mazeWorldHeight / 2) + mazeWorldOffset;
            leftWall.localScale = new Vector2(mazeHeight * wallLength + wallThickness, wallThickness);
            leftWall.eulerAngles = Vector3.forward * 90;
            
            // Render horizontal walls
            for (int i = 0; i < horizontalWalls.GetLength(0); i++)
            {
                for (int j = 0; j < horizontalWalls.GetLength(1); j++)
                {
                    if (horizontalWalls[i, j])
                    {
                        Vector2 wallSize = new Vector2(wallLength + wallThickness, wallThickness);
                        Vector2 wallPosition = new Vector2(i * wallLength + wallLength / 2, (j + 1) * wallLength);
                        Vector3 wallRotation = Vector3.zero;
                        Transform wall = Instantiate(wallPrefab, transform);
                        wall.position = wallPosition + mazeWorldOffset;
                        wall.localScale = wallSize;
                        wall.eulerAngles = wallRotation;
                    }
                    
                }
            }
            
            // Render vertical walls
            for (int i = 0; i < verticalWalls.GetLength(0); i++)
            {
                for (int j = 0; j < verticalWalls.GetLength(1); j++)
                {
                    if (verticalWalls[i, j])
                    {
                        Vector2 wallSize = new Vector2(wallLength + wallThickness, wallThickness);
                        Vector2 wallPosition = new Vector2((i + 1) * wallLength, j * wallLength + wallLength / 2);
                        Vector3 wallRotation = Vector3.forward * 90;
                        Transform wall = Instantiate(wallPrefab, transform);
                        wall.position = wallPosition + mazeWorldOffset;
                        wall.localScale = wallSize;
                        wall.eulerAngles = wallRotation;
                    }
                    
                }
            }
        }
    }
}