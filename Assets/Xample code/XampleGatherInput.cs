// using System.Collections;
// using System.Collections.Generic;
// using System.Diagnostics;
// using UnityEngine;
// using UnityEngine.InputSystem;
// using UnityEngine.UI;

// public class GatherInput : MonoBehaviour
// {
//    private NewControl mycontrol;
//    public float valueX;
//    public bool Jumpvaluable;

//    public bool tryAttack;

//    public float valueY;
//    public bool tryToClimb;
//    public bool pause = false;
//    private void Awake()
//    {
//     mycontrol = new NewControl();
//    }
//      private void OnEnable()
//    {

//         mycontrol.Player.Move.performed += StartMove;
//         mycontrol.Player.Move.canceled += StopMove;
//         mycontrol.Player.Jump.performed += JumpStart;
//         mycontrol.Player.Jump.canceled += JumpStop;

//         mycontrol.Player.Attack.performed += TryToAttack;
//         mycontrol.Player.Attack.canceled += StopTryToAttack;

//         mycontrol.Player.Climb.performed += ClimbStart;
//         mycontrol.Player.Climb.canceled += ClimbStop;
//         mycontrol.UI.Pause.performed += PauseGame;
//         mycontrol.UI.Pause.Enable();
        
//        mycontrol.Player.Enable();

       
//    }
//    private void OnDisable() {
//      mycontrol.Player.Move.performed -= StartMove;
//         mycontrol.Player.Move.canceled -= StopMove;
//         mycontrol.Player.Jump.performed -= JumpStart;
//         mycontrol.Player.Jump.canceled -= JumpStop;
         
//          mycontrol.Player.Attack.performed -= TryToAttack;
//         mycontrol.Player.Attack.canceled -= StopTryToAttack;

//           mycontrol.Player.Climb.performed -= ClimbStart;
//         mycontrol.Player.Climb.canceled -= ClimbStop;
        
//          mycontrol.UI.Pause.performed -= PauseGame;
//         mycontrol.UI.Pause.Disable();
      
        
     
//          mycontrol.Player.Disable();
         
//    }
//    public void DisableControls()
//    {
//     mycontrol.Player.Move.performed -= StartMove;
//         mycontrol.Player.Move.canceled -= StopMove;
//         mycontrol.Player.Jump.performed -= JumpStart;
//         mycontrol.Player.Jump.canceled -= JumpStop;

//         mycontrol.Player.Climb.performed -= ClimbStart;
//         mycontrol.Player.Climb.canceled -= ClimbStop;
       
        
//        mycontrol.Player.Disable();
//        valueX = 0;
//    }
//    private void StartMove(InputAction.CallbackContext ctx)
//    {
//     valueX = ctx.ReadValue<float> ();
   
//    }
//    private void StopMove(InputAction.CallbackContext ctx)
//    {
//     valueX = 0;
//    }
//    private void JumpStart(InputAction.CallbackContext ctx)
//    {
//     Jumpvaluable = true;
//    }
//    private void JumpStop(InputAction.CallbackContext ctx)
//    {
//     Jumpvaluable = false;
//    }
//    private void TryToAttack(InputAction.CallbackContext ctx)
//    {
//     tryAttack = true;
//    }
//    private void StopTryToAttack(InputAction.CallbackContext ctx)
//    {
//     tryAttack = false;
//    }

//    private void ClimbStart(InputAction.CallbackContext ctx)
//    {
//     valueY = Mathf.RoundToInt(ctx.ReadValue<float>()); //get axis values from button

//     if (Mathf.Abs(valueY) > 0)//check if press button by check value 
//     {                           // use absolute value because of climb down (climb down button have negative value)
//       tryToClimb = true;
      
//     }
//      UnityEngine.Debug.Log("ClimbStart");
//    }
//    private void ClimbStop(InputAction.CallbackContext ctx)
//    {
//     // reset values 
//     tryToClimb = false;
//     valueY = 0;
//    }

//    private void PauseGame(InputAction.CallbackContext ctx)
//    {
    
//     pause = !pause;
//     if (pause)
//     {
//       Time.timeScale = 0;
//       mycontrol.Player.Disable();
//     }
//     else
//     {
//       Time.timeScale = 1;
//       mycontrol.Player.Enable();
//     }
//     UnityEngine.Debug.Log("Pause");
//    }

// }
