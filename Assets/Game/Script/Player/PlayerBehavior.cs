using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Script
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerBehavior : MonoBehaviour , IStateSwitcher
    {
        public PlayerInventory PlayerInventory;
        private PlayerEventHandler _playerEventHandler;

        public static Vector3 pos;
        
        private List<StateBase> attackStates;
        private List<StateBase> moveStates;
        private StateBase currentMoveState;
        private StateBase currentAttackState;

        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;
        [SerializeField] private float gravity;
        [SerializeField] private Transform hand;
        
        [SerializeField] private Transform camera;
        private float xrot;
        
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Input.compositionCursorPos = Vector2.zero;
            moveStates = new List<StateBase>()
            {
                new MoveState(this,GetComponent<PlayerInventory>(),transform, speed,jumpForce,GetComponent<CharacterController>(),gravity)
            };
            attackStates = new List<StateBase>()
            {
                new PlayerAttackState(this),new PlayerOnAttackState(this,hand)
            };
            currentMoveState = moveStates[0];
            currentAttackState = attackStates[0];
        }

        private void FixedUpdate()
        {
            currentMoveState.FixedUpdate();
            currentAttackState.FixedUpdate();
            CameraRotate();
        }

        private void Update()
        {
            currentMoveState.Update();
            currentAttackState.Update();
            pos = transform.position;
        }

        public void Switch<T>() where T : StateBase
        {
            var s = moveStates.FirstOrDefault(s => s is T);
            if (s == null) return;
            currentMoveState.Exit();
            currentMoveState = s;
            currentMoveState.Enter();
            var a = attackStates.FirstOrDefault(a => a is T);
            if (a == null) return;
            currentAttackState.Exit();
            currentAttackState = a;
            currentAttackState.Enter();
        }
        
        private void CameraRotate()
        {
            var xMouse = Input.GetAxis("Mouse X");
            var yMouse = Input.GetAxis("Mouse Y");
            xrot -= yMouse;
            xrot = Mathf.Clamp(xrot, -90, 90);
            camera.localRotation = Quaternion.Euler(xrot,0,0);
            transform.Rotate(Vector3.up * xMouse);
        }
    }
}