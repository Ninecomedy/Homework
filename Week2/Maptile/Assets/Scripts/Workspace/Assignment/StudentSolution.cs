using System.Collections;
using System.Collections.Generic;
using System.Text;
using AssignmentSystem.Services;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment
{
    public class StudentSolution : MonoBehaviour, IAssignment
    {

        #region Lecture

        public void LCT01_SyntaxArray()
        {
            string[] ironManSuit = new string[2];
            ironManSuit[0] = "Mark I";
            ironManSuit[1] = "Mark II";
            string tonyStarkWear = ironManSuit[0];
            Debug.Log($"TonyStark Wear: {tonyStarkWear}");
            Debug.Log($"Room size: {ironManSuit.Length}");
            Debug.Log(ironManSuit[0]);
            Debug.Log(ironManSuit[1]);
        }

        public void LCT02_ArrayInitialize()
        {
            string[] spiderManSuits =
            {
        "Classic SpiderMan",
        "Black Suit",
        "Iron Spider Suit"
    };

            Debug.Log($"Room size: {spiderManSuits.Length}");
            for (int i = 0; i < spiderManSuits.Length; i++)
            {
                Debug.Log(spiderManSuits[i]);
            }

            string[] batmanSuits = new string[2];
            batmanSuits[0] = "Classic BatMan";
            batmanSuits[1] = "White bat";

            Debug.Log($"Room size: {batmanSuits.Length}");
            for (int i = 0; i < batmanSuits.Length; i++)
            {
                Debug.Log(batmanSuits[i]);
            }
        }


        public void LCT03_SyntaxLoop()
        {
            for (int i = 0; i < 10; i++)
            {
                Debug.Log("<10 : " + i);
            }
            Debug.Log("===");
            for (int i = 1; i <= 10; i++)
            {
                Debug.Log("<=10 : " + i);
            }
        }

        public void LCT04_LoopAndArray(string[] ironManSuitNames)
        {
            for (int i = 0; i < ironManSuitNames.Length; i++)
                Debug.Log(ironManSuitNames[i]);

            Debug.Log("===");

            for (int i = 0; i < ironManSuitNames.Length; i += 2)
                Debug.Log(ironManSuitNames[i]);
        }

        public void LCT05_Syntax2DArray()
        {
            int[,] my2DArray =
            {
                {1, 2},
                {3, 4}
            };

            Debug.Log($"my2DArray[0, 0] = {my2DArray[0, 0]}");
            Debug.Log($"my2DArray[0, 1] = {my2DArray[0, 1]}");
            Debug.Log($"my2DArray[1, 0] = {my2DArray[1, 0]}");
            Debug.Log($"my2DArray[1, 1] = {my2DArray[1, 1]}");

            my2DArray[0, 1] = 6;
            my2DArray[1, 1] = 8;

            Debug.Log("After change value");
            Debug.Log($"my2DArray[0, 1] = {my2DArray[0, 1]}");
            Debug.Log($"my2DArray[1, 1] = {my2DArray[1, 1]}");
        }

        public void LCT06_SizeOf2DArray(int[,] my2DArray)
        {
            Debug.Log($"rows = {my2DArray.GetLength(0)}");
            Debug.Log($"cols = {my2DArray.GetLength(1)}");
        }

        public void LCT07_SyntaxNestedLoop(int columns, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                string row = "";
                for (int j = 0; j < columns; j++)
                {
                    row += "*";
                }
                Debug.Log(row);
            }
        }

        #endregion

        #region Assignment

        public void AS01_RandomItemDrop(GameObject[] items)
        {
            throw new System.NotImplementedException();
        }

        public void AS02_NestedLoopForCreate2DMap(GameObject[] floorTiles, int columns, int rows)
        {
            throw new System.NotImplementedException();
        }

        public void AS03_NestedLoopForMakingWallAround(GameObject wall, int columns, int rows)
        {
            throw new System.NotImplementedException();
        }

        public void AS04_AttackEnemy(int[] enemyHP, int damage, int target)
        {
            throw new System.NotImplementedException();
        }

        public void AS05_DynamicIterationLoop(int n)
        {
            throw new System.NotImplementedException();
        }

        public void AS06_WhileLoopAndArray(string[] ironManSuitNames)
        {
            throw new System.NotImplementedException();
        }

        public void AS07_HealTargetAtIndex(int[] heroHPs, int heal, int targetIndex)
        {
            throw new System.NotImplementedException();
        }

        public void AS08_RandomPickingDialogue(string[] dialogues)
        {
            throw new System.NotImplementedException();
        }

        public void AS09_MultiplicationTable(int n)
        {
            throw new System.NotImplementedException();
        }

        public void AS10_FindSummationFromZeroToNUsingWhileLoop(int n)
        {
            throw new System.NotImplementedException();
        }

        public void AS11_SpawnEnemies(int[] enemyHPs, GameObject enemyPrefab)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator AS12_CountTime(float CountTime)
        {
            throw new System.NotImplementedException();
        }

        public void AS13_SumOfNumbersInRow(int[,] matrix, int row)
        {
            throw new System.NotImplementedException();
        }

        public void AS14_SumOfNumbersInColumn(int[,] matrix, int column)
        {
            throw new System.NotImplementedException();
        }

        public void AS15_MakeTheTriangle(int size)
        {
            throw new System.NotImplementedException();
        }

        public void AS16_MultiplicationTableOf_2_3_and_4()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Extra assignment

        public void EX_01_TicTacToeGame_TurnPlay(string[,] board, string playerTurn, int row, int column)
        {
            throw new System.NotImplementedException();
        }

        private void PrintBoard(string[,] board)
        {
            StringBuilder sb = new();
            for (int i = 0; i < 3; i++)
            {
                sb.AppendLine("-------------");
                sb.AppendLine("| " + board[i, 0] + " | " + board[i, 1] + " | " + board[i, 2] + " |");
            }
            sb.AppendLine("-------------");
            Debug.Log(sb.ToString());
        }
        #endregion
    }

}
