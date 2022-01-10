using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Threading.Tasks;

namespace com.impactionalGames.LudoPrime
{
    public class PlayerPiece : MonoBehaviourPun
    {
        public bool isReady;
        public bool canMove;
        public bool moveNow;
        public int numberOfStepsAlreadyMoved;
        public float speed = 100f;

        public PathObjectsParent pathsParent;
        public PathPoints previousPathPoint;
        public PathPoints currentPathPoint;

        Coroutine moveSteps_Coroutine;

        private void Awake()
        {
            pathsParent = FindObjectOfType<PathObjectsParent>();
        }

        public void MoveSteps(PathPoints[] pathPointsToMoveOn_)
        {
            moveSteps_Coroutine = StartCoroutine(MoveSteps_Enum(pathPointsToMoveOn_));


        }

        public void MakePlayerReadyToMove(PathPoints[] pathPointsToMoveOn_)
        {
            isReady = true;
            transform.position = pathPointsToMoveOn_[0].transform.position;
            numberOfStepsAlreadyMoved = 1;

            previousPathPoint = pathPointsToMoveOn_[0];
            currentPathPoint = pathPointsToMoveOn_[0];
            GameManager.gm.RemovePathPoint(previousPathPoint);
            GameManager.gm.AddPathPoint(currentPathPoint);

            GameManager.gm.canDiceRoll = true;
            GameManager.gm.selfDice = true;
            GameManager.gm.transferDice = false;
        }

        IEnumerator MoveSteps_Enum(PathPoints[] pathPointsToMoveOn_)
        {
            yield return new WaitForSeconds(0.5f);
            int numOfStepsToMove = GameManager.gm.numOfStepsToMove;


            if (canMove)
            {
                for (int i = numberOfStepsAlreadyMoved; i < (numberOfStepsAlreadyMoved + numOfStepsToMove); i++)
                {
                    if (isPathPointsAvailableToMove(numOfStepsToMove, numberOfStepsAlreadyMoved, pathPointsToMoveOn_))
                    {
                        transform.position = pathPointsToMoveOn_[i].transform.position;

                        yield return new WaitForSeconds(0.5f);

                    }
                }
            }

            if (isPathPointsAvailableToMove(numOfStepsToMove, numberOfStepsAlreadyMoved, pathPointsToMoveOn_))
            {
                GameManager.gm.transferDice = false;
                numberOfStepsAlreadyMoved += numOfStepsToMove;
                //GameManager.gm.numOfStepsToMove = 0;

                GameManager.gm.RemovePathPoint(previousPathPoint);
                //previousPathPoint.RemovePlayerPiece(this);
                currentPathPoint = pathPointsToMoveOn_[numberOfStepsAlreadyMoved - 1];

                if (currentPathPoint.AddPlayerPiece(this))
                {
                    if (numberOfStepsAlreadyMoved == 57)
                    {
                        GameManager.gm.selfDice = true;
                    }
                    else
                    {
                        if (GameManager.gm.numOfStepsToMove != 6)
                        {
                            //GameManager.gm.selfDice = false;
                            GameManager.gm.transferDice = true;

                        }
                        else
                        {
                            GameManager.gm.selfDice = true;
                            // GameManager.gm.transferDice = false;
                        }
                    }
                }
                else
                {
                    GameManager.gm.selfDice = true;
                }


                GameManager.gm.AddPathPoint(currentPathPoint);
                previousPathPoint = currentPathPoint;

                //GameManager.gm.numOfStepsToMove = 0;

            }
            GameManager.gm.CanPlayerMove = true;
            GameManager.gm.RollingDiceManager();

            //if (moveSteps_Coroutine != null)
            //{
            //    StopCoroutine(moveSteps_Coroutine);
            //}

            GameManager.gm.RollingDiceManager();
        }




        bool isPathPointsAvailableToMove(int numOfStepsToMove_, int numOfstepsAlreadyMoved_, PathPoints[] pathPointsToMoveOn_)
        {
            //if (numOfStepsToMove_ == 0)
            //{
            //    return false; ;
            // }
            int leftNumOfpathPoints = pathPointsToMoveOn_.Length - numOfstepsAlreadyMoved_;
            if (leftNumOfpathPoints >= numOfStepsToMove_)
            {
                return true;
            }
            return false;
        }

       
    }
}
