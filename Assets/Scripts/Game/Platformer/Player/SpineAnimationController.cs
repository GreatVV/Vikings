using UnityEngine;
using System.Collections;

public class SpineAnimationController : MonoBehaviour {

    public RaycastCharacterController2D controller;

    public string idleName;
    public string moveName;

    public SkeletonAnimation SkeletonAnimation;

	// Update is called once per frame
    void Update()
    {
        // When turning face towards the camera, unless climbing/rope climbing
        if (controller.State == CharacterState.IDLE)
        {
            SkeletonAnimation.loop = false;
            SkeletonAnimation.AnimationName = idleName;
        }

        if (controller.State == CharacterState.WALKING || controller.State == CharacterState.RUNNING)
        {
            SkeletonAnimation.loop = true;
            SkeletonAnimation.AnimationName = moveName;
        }
    }
}
