using System.Collections.Generic;
using UnityEngine;

namespace Workshop.Solution
{
    public class MapGenerator : MonoBehaviour
    {
        public int columns = 10;
        public int rows = 10;

        public GameObject[] floorTiles;
        public GameObject[] wallTiles;
        public GameObject[] foodTiles;
        public GameObject[] Players;

        public GameObject Exit;
        public GameObject book3;
        public GameObject wood;
        public GameObject Bag;
        public GameObject Key;

        public void Start()
        {
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    GameObject floor = floorTiles[Random.Range(0, floorTiles.Length)];
                    Instantiate(floor, new Vector2(x, y), Quaternion.identity);
                }
            }

            for (int y = -1; y < rows + 1; y++)
            {
                for (int x = -1; x < columns + 1; x++)
                {
                    if (x == -1 || x == columns || y == -1 || y == rows)
                    {
                        GameObject wall = wallTiles[Random.Range(0, wallTiles.Length)];
                        Instantiate(wall, new Vector2(x, y), Quaternion.identity);
                    }
                }
            }

            Vector2 playerPos = new Vector2(0, 0);
            int r = Random.Range(0, Players.Length);
            Instantiate(Players[r], playerPos, Quaternion.identity);

            Vector2 exitPos = new Vector2(columns - 1, rows - 1);
            Instantiate(Exit, exitPos, Quaternion.identity);

            HashSet<Vector2> blocked = new HashSet<Vector2>
            {
                playerPos,
                exitPos
            };

            PlaceRandomItems(3, foodTiles, blocked);
            PlaceSpecificObjects(new GameObject[] { book3, wood, Bag }, blocked);
            PlaceSpecificObjects(new GameObject[] { Key }, blocked);
        }

        private void PlaceRandomItems(int count, GameObject[] prefabs, HashSet<Vector2> blocked)
        {
            int placed = 0;

            while (placed < count)
            {
                Vector2 pos = new Vector2(
                    Random.Range(0, columns),
                    Random.Range(0, rows)
                );

                if (blocked.Contains(pos)) continue;

                GameObject item = prefabs[Random.Range(0, prefabs.Length)];
                Instantiate(item, pos, Quaternion.identity);

                blocked.Add(pos);
                placed++;
            }
        }

        private void PlaceSpecificObjects(GameObject[] objects, HashSet<Vector2> blocked)
        {
            foreach (GameObject obj in objects)
            {
                if (obj == null) continue;

                while (true)
                {
                    Vector2 pos = new Vector2(
                        Random.Range(0, columns),
                        Random.Range(0, rows)
                    );

                    if (blocked.Contains(pos)) continue;

                    Instantiate(obj, pos, Quaternion.identity);
                    blocked.Add(pos);
                    break;
                }
            }
        }
    }
}
