using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class MilitiaState
{
    public bool isGrounded;
    protected virtual Vector2 moveToward(Vector3 followerPosition, Vector3 targetPosition,
        ref float xVelocity, ref float yVelocity, float time)
    {
        float newXPosition = Mathf.SmoothDamp(followerPosition.x, targetPosition.x,
            ref xVelocity, time);
        float newYPosition = Mathf.SmoothDamp(followerPosition.y, targetPosition.y,
            ref yVelocity, time);
        followerPosition = new Vector3(newXPosition, newYPosition, targetPosition.z);
        return followerPosition;
    }

    public abstract void Handle();
}
