using System;
using UnityEngine;
using UnityEngine.Serialization;

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
        
        private void OnEnable()
        {
            _playerManager = FindObjectOfType<PlayerManager>();
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
            int playerX = UnityEngine.Random.Range(0, mazeWidth);
            int playerY = UnityEngine.Random.Range(0, mazeHeight);
            player.transform.position = new Vector2((playerX - (mazeWidth)/2.0f)*wallLength + wallLength/2.0f, (-playerY + (mazeHeight)/2.0f)*wallLength - wallLength/2.0f);
        }

        void Draw(bool[,] horizontalWalls, bool[,] verticalWalls)
        {
            float worldWidth = mazeWidth * wallLength;
            float worldHeight = mazeHeight * wallLength;

            Vector2 offset = new Vector2(worldWidth * -1/2, worldHeight * -1/2);

            //Render Main Walls
            Transform topWall = Instantiate(wallPrefab, transform);
            topWall.position = new Vector2(0, worldHeight * 1/2);
            topWall.localScale = new Vector2(mazeWidth * wallLength + wallThickness, wallThickness);
            topWall.eulerAngles = Vector3.zero;
            
            Transform botWall = Instantiate(wallPrefab, transform);
            botWall.position = new Vector2(0, worldHeight * -1/2);
            botWall.localScale = new Vector2(mazeWidth * wallLength + wallThickness, wallThickness);
            botWall.eulerAngles = Vector3.zero;
            
            Transform rightWall = Instantiate(wallPrefab, transform);
            rightWall.position = new Vector2(worldWidth * 1/2, 0);
            rightWall.localScale = new Vector2(mazeHeight * wallLength + wallThickness, wallThickness);
            rightWall.eulerAngles = Vector3.forward * 90;
            
            Transform leftWall = Instantiate(wallPrefab, transform);
            leftWall.position = new Vector2(worldWidth * -1/2, 0);
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
                        wall.position = wallPosition + offset;
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
                        wall.position = wallPosition + offset;
                        wall.localScale = wallSize;
                        wall.eulerAngles = wallRotation;
                    }
                    
                }
            }
        }
    }
}