using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		[SerializeField]
		private Vector2 move;
		[SerializeField]
		private Vector2 look;
		[SerializeField]
		private bool jump;
		[SerializeField]
		private bool sprint;
		[SerializeField]
		public bool flashlight;
		[SerializeField]
		public bool characterSwitchLeft;
		[SerializeField]
		public bool characterSwitchRight;
		[Header("Movement Settings")]
		private bool analogMovement;

#if !UNITY_IOS || !UNITY_ANDROID
		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;
#endif

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputAction.CallbackContext value)
		{
			MoveInput(value.ReadValue<Vector2>());
		}

		public void OnLook(InputAction.CallbackContext value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.ReadValue<Vector2>());
			}
		}

		public void OnJump(InputAction.CallbackContext value)
		{
			JumpInput(value.action.triggered);
		}

		public void OnSprint(InputAction.CallbackContext value)
		{
			SprintInput(value.action.ReadValue<float>()==1);
		}
		public void OnLight(InputAction.CallbackContext value)
        {
			LightInput(value.action.triggered);
        }
		public void OnSwitchCharacterLeft(InputAction.CallbackContext value)
        {
			CharacterSwitchInputLeft(value.action.triggered);

		}
		public void OnSwitchCharacterRight(InputAction.CallbackContext value)
		{
			CharacterSwitchInputRight(value.action.triggered);

		}
#else
	// old input sys if we do decide to have it (most likely wont)...
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}
		public void LightInput(bool newLightState)
        {
			flashlight = newLightState;
        }
		public void CharacterSwitchInputLeft(bool newCharacterSwitchState)
        {
			characterSwitchLeft = newCharacterSwitchState;
        }
		public void CharacterSwitchInputRight(bool newCharacterSwitchState)
		{
			characterSwitchRight = newCharacterSwitchState;
		}
		public Vector2 GetMove()
        {
			return move;
        }
		public Vector2 GetLook()
        {
			return look;
        }
		public bool IsJumping()
        {
			return jump;
        }
		public bool IsSprinting()
		{
			return sprint;
		}
		public bool IsAnalog()
        {
			return analogMovement;
        }
#if !UNITY_IOS || !UNITY_ANDROID

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

#endif

	}
	
}