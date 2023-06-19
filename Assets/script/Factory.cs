using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public static class Factory
{

    public static BallType BallType;

    /// <summary>
    /// create the ball
    /// </summary>
    /// <param name="type">type of the ball on which depends the radius </param>
    /// <param name="position"></param>
    /// <param name="speed"></param>
    public static void CreateBall(BallType type, Vector2 position, float speed)
    {
        float radius = 0f;
        BallController controller = GameManager.instance.PoolingManager.GetEntity();
        controller.gameObject.transform.position = position;
        controller.SetType(type);
        switch (type)
        {
            case BallType.LargeBall:
                radius = controller.LargeBallRadius; 
                break;
            case BallType.MediumBall:
                radius = controller.MediumBallRadius; 
                break;
            case BallType.SmallBall:
                radius = controller.SmallBallRadius; 
                break;
            case BallType.LastBall:
                radius = controller.LastBallRadius; 
                break;
        }
        controller.SetRadius(radius);
        controller.SetSpeed(speed);
    }
}
