using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionSetUp : MonoBehaviour
{
    private LocomotionController lc;

    private LocomotionTeleport TeleportController
    {
        get
        {
            return lc.GetComponent<LocomotionTeleport>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        lc = FindObjectOfType<LocomotionController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetupNonCap()
    {
        var input = TeleportController.GetComponent<TeleportInputHandlerTouch>();
        input.InputMode = TeleportInputHandlerTouch.InputModes.SeparateButtonsForAimAndTeleport;
        input.AimButton = OVRInput.RawButton.A;
        input.TeleportButton = OVRInput.RawButton.A;
    }
    void SetupTeleportDefaults()
    {
        TeleportController.enabled = true;
        //lc.PlayerController.SnapRotation = true;
        lc.PlayerController.RotationEitherThumbstick = false;
        //lc.PlayerController.FixedSpeedSteps = 0;
        TeleportController.EnableMovement(false, false, false, false);
        TeleportController.EnableRotation(false, false, false, false);

        var input = TeleportController.GetComponent<TeleportInputHandlerTouch>();
        input.InputMode = TeleportInputHandlerTouch.InputModes.CapacitiveButtonForAimAndTeleport;
        input.AimButton = OVRInput.RawButton.A;
        input.TeleportButton = OVRInput.RawButton.A;
        input.CapacitiveAimAndTeleportButton = TeleportInputHandlerTouch.AimCapTouchButtons.A;
        input.FastTeleport = false;

        var hmd = TeleportController.GetComponent<TeleportInputHandlerHMD>();
        hmd.AimButton = OVRInput.RawButton.A;
        hmd.TeleportButton = OVRInput.RawButton.A;

        var orient = TeleportController.GetComponent<TeleportOrientationHandlerThumbstick>();
        orient.Thumbstick = OVRInput.Controller.LTouch;
    }

    void SetupNodeTeleport()
    {
        SetupTeleportDefaults();
        SetupNonCap();
        //lc.PlayerController.SnapRotation = true;
        //lc.PlayerController.FixedSpeedSteps = 1;
        lc.PlayerController.RotationEitherThumbstick = true;
        TeleportController.EnableRotation(true, false, false, true);
        var input = TeleportController.GetComponent<TeleportInputHandlerTouch>();
        input.AimingController = OVRInput.Controller.RTouch;
        //var input = TeleportController.GetComponent<TeleportAimHandlerLaser>();
        //input.AimingController = OVRInput.Controller.RTouch;
    }
}
