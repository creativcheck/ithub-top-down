using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    public class InputListener : MonoBehaviour
    {
        private CharacterActions _characterActions;
        private MainInput _mainInput;

        private Vector2 _direction;

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
        }

        private void Expose()
        {
            _mainInput.Player.Disable();

            _mainInput.Player.Move.performed -= Move;
            _mainInput.Player.Move.canceled -= Move;
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
