using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using JUTPS.JUInputSystem;
namespace JUTPS.Addons.DoubleJump
{
    public class JUCharacterDoubleJump : JUTPSActions.JUTPSAction
    {
        public string JumpAnimatorStateName = "Jump";
        public int JumpCount = 2;
        private int currentJumps;
        private bool hasFirstJump;
        public bool CanJump;
        public UnityEvent OnJump;
        public UnityEvent OnExtraJump;
        void LateUpdate()
        {
            if (TPSCharacter.IsDriving || TPSCharacter.IsRagdolled || TPSCharacter.IsRolling) return;

            if (TPSCharacter.IsGrounded == true)
            {
                hasFirstJump = false;
                CanJump = true;
                currentJumps = 0;
            }

            if (TPSCharacter.IsJumping == false)
            {
                if (JUInput.GetButtonDown(JUInput.Buttons.JumpButton) && CanJump && hasFirstJump == true)
                {
                    //Force Extra Jumping
                    ForcedJump();
                    OnExtraJump.Invoke();

                    //Add jump count
                    currentJumps += 1;

                    //Finish Jump Count
                    if (currentJumps >= JumpCount - 1)
                    {
                        CanJump = false;
                    }
                }
            }
            else if (hasFirstJump == false)
            {
                OnJump.Invoke();
                hasFirstJump = true;
            }
        }
        public void ForcedJump()
        {            
            //Force Jump Animation
            anim.Play(JumpAnimatorStateName, 0, 0);

            //Change States
            TPSCharacter.IsGrounded = false;
            TPSCharacter.IsJumping = true;
            TPSCharacter.CanJump = false;
            TPSCharacter.IsCrouched = false;

            //Add Force
            rb.AddForce(transform.up * 200 * TPSCharacter.JumpForce, ForceMode.Impulse);
            if (TPSCharacter.SetRigidbodyVelocity == false)
            {
                rb.AddForce(TPSCharacter.DirectionTransform.forward * TPSCharacter.VelocityMultiplier * rb.mass * TPSCharacter.Speed, ForceMode.Impulse);
                TPSCharacter.VelocityMultiplier = 0;
            }

            //Disable IsJumping state in 0.3s
            if (TPSCharacter.IsInvoking("_disablejump")) TPSCharacter.CancelInvoke("_disablejump");

            TPSCharacter.Invoke("_disablejump", 0.3f);
        }
    }
}
