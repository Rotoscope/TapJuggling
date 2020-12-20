using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    public const float GRAVITY = 9.81f;
    public const float ROTATION_SPEED = 350f;
    public const float INITIAL_SPAWN_DELAY = 5f;
    public const float MINIMUM_SPAWN_DELAY = 1.2f;
    // after REDUCTION_CHECK, reduce delay by reduction
    public const float REDUCTION_CHECK = 2f;
    public const float SPAWN_REDUCTION = 0.5f;
}
