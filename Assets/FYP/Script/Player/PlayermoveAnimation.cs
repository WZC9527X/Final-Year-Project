using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayermoveAnimation : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int BackHash;
    int LeftHash;
    int RightHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        BackHash = Animator.StringToHash("Back");
        LeftHash = Animator.StringToHash("Left");
        RightHash = Animator.StringToHash("Right");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool Back = animator.GetBool(BackHash);
        bool Left = animator.GetBool(LeftHash);
        bool Right = animator.GetBool(RightHash);
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool RunPressed = Input.GetKey(KeyCode.LeftShift);
        bool BackPressed = Input.GetKey(KeyCode.S);
        bool LeftPressed = Input.GetKey(KeyCode.A);
        bool RightPressed = Input.GetKey(KeyCode.D);

        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (forwardPressed && RunPressed))
        {
            animator.SetBool(isRunningHash, true);
        }

        if (isRunning && (!forwardPressed || !RunPressed))
        {
            animator.SetBool(isRunningHash, false);
        }

        if (!Back && BackPressed)
        {
            animator.SetBool(BackHash, true);
        }

        if (Back && !BackPressed)
        {
            animator.SetBool(BackHash, false);
        }

        if (!Left && LeftPressed)
        {
            animator.SetBool(LeftHash, true);
        }

        if (Left && !LeftPressed)
        {
            animator.SetBool(LeftHash, false);
        }

        if (!Right && RightPressed)
        {
            animator.SetBool(RightHash, true);
        }

        if (Right && !RightPressed)
        {
            animator.SetBool(RightHash, false);
        }
    }

}
