using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solution
{
    public class ZombieParade : OOPEnemy
    {
        private LinkedList<GameObject> Parade = new LinkedList<GameObject>();
        public int SizeParade = 3;
        int timer = 0;
        public GameObject[] bodyPrefab;
        public float moveInterval = 0.5f;

        public GameObject zombiePrefab;
        public float spawnInterval = 10f;

        private Vector3 moveDirection;

        IEnumerator Start()
        {
            moveDirection = Vector3.up;

            positionX = (int)transform.position.x;
            positionY = (int)transform.position.y;

            yield return null;

            StartCoroutine(MoveParade());
            StartCoroutine(SpawnMoreZombie());
        }

        IEnumerator SpawnMoreZombie()
        {
            OOPMapGenerator map = FindObjectOfType<OOPMapGenerator>();

            while (true)
            {
                yield return new WaitForSeconds(spawnInterval);

                int x;
                int y;

                do
                {
                    x = Random.Range(0, map.Rows);
                    y = Random.Range(0, map.Cols);
                }
                while (map.GetMapData(x, y) != null);

                Instantiate(zombiePrefab, new Vector3(x, y, 0), Quaternion.identity);
            }
        }


        private Vector3 RandomizeDirection()
        {
            List<Vector3> possibleDirections = new List<Vector3>
            {
                Vector3.up,
                Vector3.down,
                Vector3.left,
                Vector3.right
            };

            return possibleDirections[Random.Range(0, possibleDirections.Count)];
        }

        IEnumerator MoveParade()
        {
            Parade.AddFirst(this.gameObject);

            while (isAlive)
            {
                LinkedListNode<GameObject> firstNode = Parade.First;
                GameObject firstPart = firstNode.Value;

                LinkedListNode<GameObject> lastNode = Parade.Last;
                GameObject lastPart = lastNode.Value;

                Parade.RemoveLast();

                int toX = 0;
                int toY = 0;

                bool isCollide = true;
                int countTryFind = 0;

                while (isCollide && countTryFind <= 10)
                {
                    moveDirection = RandomizeDirection();
                    toX = (int)(firstPart.transform.position.x + moveDirection.x);
                    toY = (int)(firstPart.transform.position.y + moveDirection.y);
                    countTryFind++;

                    if (countTryFind > 10)
                    {
                        toX = positionX;
                        toY = positionY;
                    }

                    isCollide = IsCollision(toX, toY);
                }

                positionX = toX;
                positionY = toY;

                lastPart.transform.position = new Vector3(positionX, positionY, 0);

                Parade.AddFirst(lastNode);

                if (Parade.Count < SizeParade)
                {
                    timer++;
                    if (timer > 3)
                    {
                        Grow();
                        timer = 0;
                    }
                }

                yield return new WaitForSeconds(moveInterval);
            }
        }

        private bool IsCollision(int x, int y)
        {
            OOPMapGenerator map = FindObjectOfType<OOPMapGenerator>();

            if (x < 0 || x >= map.Rows || y < 0 || y >= map.Cols)
            {
                return false;
            }

            Identity other = map.GetMapData(x, y);

            if (other != null)
            {
                return true;
            }

            return false;
        }


        private void Grow()
        {
            GameObject newPart = Instantiate(bodyPrefab[0]);
            GameObject lastPart = Parade.Last.Value;
            newPart.transform.position = lastPart.transform.position;
            Parade.AddLast(newPart);
        }
    }
}
