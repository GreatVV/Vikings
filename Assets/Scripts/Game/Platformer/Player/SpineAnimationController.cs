using System;
using UnityEngine;

public class SpineAnimationController : MonoBehaviour
{
    public RaycastCharacterController2D controller;
    public string crouchingName;
    public string crouchingSlidingName;
    public string idleName;
    public string runningName;
    public SkeletonAnimation SkeletonAnimation;
    public string slidingName;
    public string walkingName;

    private int CurrentDirection
    {
        get
        {
            return controller.CurrentDirection;
        }
    }

    public CharacterState CurrentState
    {
        get
        {
            return controller.State;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        switch (controller.State)
        {
            case CharacterState.NONE:
                break;
            case CharacterState.IDLE:
                SkeletonAnimation.loop = false;
                SkeletonAnimation.AnimationName = idleName;
                break;
            case CharacterState.WALKING:
                SkeletonAnimation.AnimationName = walkingName;
                SkeletonAnimation.loop = true;
                break;
            case CharacterState.RUNNING:
                SkeletonAnimation.AnimationName = runningName;
                SkeletonAnimation.loop = true;
                break;
            case CharacterState.SLIDING:
                SkeletonAnimation.AnimationName = slidingName;
                SkeletonAnimation.loop = true;
                break;
            case CharacterState.AIRBORNE:
                break;
            case CharacterState.FALLING:
                break;
            case CharacterState.AIRBORNE_CROUCH:
                break;
            case CharacterState.WALL_SLIDING:
                break;
            case CharacterState.CROUCHING:
                SkeletonAnimation.AnimationName = crouchingName;
                SkeletonAnimation.loop = true;
                break;
            case CharacterState.CROUCH_SLIDING:
                SkeletonAnimation.AnimationName = crouchingSlidingName;
                SkeletonAnimation.loop = true;
                break;
            case CharacterState.HOLDING:
                break;
            case CharacterState.CLIMBING:
                break;
            case CharacterState.CLIMB_TOP_OF_LADDER_UP:
                break;
            case CharacterState.CLIMB_TOP_OF_LADDER_DOWN:
                break;
            case CharacterState.LEDGE_HANGING:
                break;
            case CharacterState.LEDGE_CLIMBING:
                break;
            case CharacterState.LEDGE_CLIMB_FINISHED:
                break;
            case CharacterState.ROPE_CLIMBING:
                break;
            case CharacterState.ROPE_HANGING:
                break;
            case CharacterState.ROPE_SWING:
                break;
            case CharacterState.SWIMMING:
                break;
            case CharacterState.JUMPING:
                break;
            case CharacterState.DOUBLE_JUMPING:
                break;
            case CharacterState.WALL_JUMPING:
                break;
            case CharacterState.PUSHING:
                break;
            case CharacterState.PULLING:
                break;
            case CharacterState.STUNNED:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        CheckDirection();
    }

    protected void CheckDirection()
    {
        // Rope states
        if (CurrentState == CharacterState.ROPE_HANGING || CurrentState == CharacterState.ROPE_CLIMBING)
        {
            // No need to rotate, stay in existing direction
        }
        // Climbing states
        else
        {
            if (CurrentState == CharacterState.CLIMBING || CurrentState == CharacterState.HOLDING ||
                CurrentState == CharacterState.CLIMB_TOP_OF_LADDER_UP ||
                CurrentState == CharacterState.CLIMB_TOP_OF_LADDER_DOWN)
            {
                // No need to rotate, stay in existing direction
            }
            // Wall slide
            else
            {
                if (CurrentState == CharacterState.WALL_SLIDING)
                {
                    if (controller.CurrentDirection > 0)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                    else
                    {
                        if (controller.CurrentDirection < 0)
                        {
                            transform.localScale = new Vector3(-1, 1, 1);
                        }
                    }
                }
                // Directional states
                else
                {
                    if (controller.CurrentDirection > 0)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                    else
                    {
                        if (controller.CurrentDirection < 0)
                        {
                            transform.localScale = new Vector3(-1, 1, 1);
                        }
                    }
                }
            }
        }
    }
}