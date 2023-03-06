using UnityEngine;

namespace Script
{
    public class MoveState : StateBase
    { 
        private float speed;
        private float jumpForce;
        private CharacterController _controller;
        private float gravity;
        private Vector3 velocity;
        private Transform _transform;
        private PlayerInventory _playerInventory;
        
        public MoveState(IStateSwitcher switcher,PlayerInventory playerInventory,Transform transform, float speed , float jumpForce, CharacterController controller,float gravity)
        {
            _playerInventory = playerInventory;
            _transform = transform;
            this.speed = speed;
            this.jumpForce = jumpForce;
            _controller = controller;
            this.gravity = gravity;
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _controller.isGrounded)
            {
                Jump();
            }
        }

        public override void FixedUpdate()
        {
            Move();
            GravityCalc();
            if (Input.GetKeyDown("1"))
            {
                _playerInventory.SelectItem(0);
            }
            if (Input.GetKeyDown("2"))
            {
                _playerInventory.SelectItem(1);
            }
            if (Input.GetKeyDown("3"))
            {
                _playerInventory.SelectItem(2);
            }
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
        }

        private void Jump()
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
        }

        private void Move()
        {
            var x = Input.GetAxis("Horizontal") * speed;
            var y = Input.GetAxis("Vertical") * speed;
            var dir = _transform.right * x + _transform.forward * y;
            _controller.Move(dir * Time.fixedDeltaTime);
        }

        private void GravityCalc()
        {
            velocity.y += gravity * Time.fixedDeltaTime;
            if (_controller.isGrounded)
            {
                velocity.y = -2;
            }
            _controller.Move(velocity * Time.fixedDeltaTime); 
        }
    }
}