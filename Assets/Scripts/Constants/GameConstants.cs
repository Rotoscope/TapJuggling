using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstants
{
    public const float GRAVITY = 9.81f;
    public const float ROTATION_SPEED = 350f;
    public const float INITIAL_SPAWN_DELAY = 5f;
    public const float MINIMUM_SPAWN_DELAY = 1.2f;
    public const float INITIAL_SPAWN_FORCE = -180f;

    // after REDUCTION_CHECK, reduce delay by reduction
    public const float REDUCTION_CHECK = 2f;
    public const float SPAWN_REDUCTION = 0.5f;
    public const float CLICK_BOOST = 900f;

    public const int INITIAL_LIFE_COUNT = 3;

    public static float LEFT_END = -Screen.width / 2;
    public static float RIGHT_END = Screen.width / 2;

    // 3/4 of the screen will be safe spawn from width
    // full height for vertical spawn
    // divided by 2 because of default pivot 0.5
    public static float SAFE_SPAWN_LEFT = -Screen.safeArea.width * 3 / 4 / 2;
    public static float SAFE_SPAWN_RIGHT = Screen.safeArea.width * 3 / 4 / 2;
    public static float SAFE_SPAWN_HEIGHT = Screen.safeArea.height / 2;
}
