using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConstants
{
    private static float GROUND_BOX_CAST_DISTANCE = 0.02f;
    public static float GroundBoxCastDistance
    {
        get { return GROUND_BOX_CAST_DISTANCE; }
    }

    private static float LADDER_DOWN_RAYCAST_DISTANCE_OFFSET = 0.1f;
    public static float LadderDownRaycastDistanceOffset
    {
        get { return LADDER_DOWN_RAYCAST_DISTANCE_OFFSET; }
    }
}
