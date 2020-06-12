using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ChessPrototype.Base
{
    public class InputManager : MonoBehaviour
    {
        public GameManager gameManager;
        public new Camera camera;

        private bool isSingleClick;
        private bool isDoubleClick;

        private bool startTimer;

        private float timer;
        private float doubleClickInterval = 0.5f;

        public event Action<Tile> OnSingleClick;
        public event Action OnDoubleClick;

        private Tile tileAtTimeOfSingleClick;

        public void Init(GameManager manager, Camera cam)
        {
            this.gameManager = manager;
            this.camera = cam;

            timer = 0;
            startTimer = false;
            isSingleClick = false;
            isDoubleClick = false;
        }

        private void Update()
        {
            MonitorMouseInput();
            AssignClickStates();
        }

        private void MonitorMouseInput()
        {
            if (startTimer)
            {
                timer += Time.deltaTime;

                if (timer <= doubleClickInterval)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        timer = 0;
                        isDoubleClick = true;
                    }
                }
                else
                {
                    startTimer = false;
                    timer = 0;
                    isSingleClick = true;
                }
            }

            if (Input.GetMouseButtonDown(0) && !startTimer)
            {
                startTimer = true;

                // Need tile that mouse was over at time of click in the case that it won't eventuate as a double click.
                tileAtTimeOfSingleClick = gameManager.GetTile();
            }
        }

        private void AssignClickStates()
        {
            if (isSingleClick && !isDoubleClick)
            {
                if (tileAtTimeOfSingleClick == null)
                    return;

                OnSingleClick(tileAtTimeOfSingleClick);
                isSingleClick = false;

                StartCoroutine(ResetTimerAtEndOfFrame());
            }
            else if (isDoubleClick && !isSingleClick)
            {
                OnDoubleClick();
                isDoubleClick = false;

                StartCoroutine(ResetTimerAtEndOfFrame());
            }
        }

        private IEnumerator ResetTimerAtEndOfFrame()
        {
            yield return new WaitForFixedUpdate();

            startTimer = false;
            timer = 0;
            isSingleClick = false;
            isDoubleClick = false;
        }
    }
}