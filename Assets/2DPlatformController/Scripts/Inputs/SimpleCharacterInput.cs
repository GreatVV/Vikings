using UnityEngine;
using System.Collections;

/// <summary>
/// A simple character input. Arrows to move, left SHIFT to run, SPACE to jump.
/// </summary>
public class SimpleCharacterInput : RaycastCharacterInput
{

	/// <summary>
	/// IF true always run.
	/// </summary>
	public bool alwaysRun;

	/// <summary>
	/// If true dropping from a passthrough platform requires user to press down and then jump.
	/// </summary>
	public bool jumpAndDownForDrop;

	private int movingDirection;

	void Update ()
	{
		
		if (Input.GetKey(KeyCode.R)) {
			Application.LoadLevel(0);
		}
		
		jumpButtonHeld = false;
		jumpButtonDown = false;
		dropFromPlatform = false;
		x = 0;
		y = 0;
		
		if (Input.GetKey("d") && !Input.GetKey("a")) {
			x = 0.5f;
			movingDirection = 1;
		} else if (Input.GetKey("a") && !Input.GetKey("d")) {
			x = -0.5f;
			movingDirection = -1;
		} else if (Input.GetKey("d") && Input.GetKey("a")){
			x = movingDirection / 2.0f;
		}
	
		// Shift to run
		if (alwaysRun || Input.GetKey(KeyCode.LeftShift)) {
			x *= 2;
		}
		
		if (Input.GetKey("w") ) {
			y = 1;
		} else if (Input.GetKey("s") ) {
			y = -1;
			if (!jumpAndDownForDrop) dropFromPlatform = true;
		}
		
		if (Input.GetKey(KeyCode.W) ) {
			jumpButtonHeld = true;
			if (Input.GetKeyDown(KeyCode.W)) {
				if (jumpAndDownForDrop && Input.GetKey("down")) {
					dropFromPlatform = true;
				} else {
					jumpButtonDown = true;	
				}
				swimButtonDown = true;	
			} else {
				jumpButtonDown = false;		
				swimButtonDown = false;
			}
		} else {
			jumpButtonDown = false;
			swimButtonDown = false;
		}
	}
	
}

