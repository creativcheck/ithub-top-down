using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    public class InputListener : MonoBehaviour
    {
        private CharacterActions _characterActions;
        private MainInput _mainInput;

        private Vector2 _direction;
        private Coroutine _activeCoroutine;

        public void Initialize(CharacterActions actions)
        {
            _characterActions = actions;

            _mainInput = new MainInput();
            Bind();
        }

        private void Bind()
        {
            _mainInput.Player.Enable();

            _mainInput.Player.Move.performed += Move;
            _mainInput.Player.Move.canceled += Move;

            _mainInput.Player.Shoot.performed += StartShoot;
            _mainInput.Player.Shoot.canceled += StopShoot;
        }

        public void Expose()
        {
            _mainInput.Player.Disable();

            _mainInput.Player.Move.performed -= Move;
            _mainInput.Player.Move.canceled -= Move;

            _mainInput.Player.Shoot.performed -= StartShoot;
            _mainInput.Player.Shoot.canceled -= StopShoot;
        }

        private void StartShoot(InputAction.CallbackContext context)
        {
            _activeCoroutine = StartCoroutine(_characterActions.ShootDelay());
        }

        private void StopShoot(InputAction.CallbackContext context)
        {
            StopCoroutine(_activeCoroutine);
        }

        private void Move(InputAction.CallbackContext context)
        {
            _direction = context.ReadValue<Vector2>();

            _characterActions.Move(_direction);
        }

        void Update()
        {
            _characterActions.Rotate();
        }
    }

}
