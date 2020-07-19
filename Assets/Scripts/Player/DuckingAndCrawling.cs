using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DuckingAndCrawling : PlayerBehaviors
{
    private CapsuleCollider2D collider2d;
    private Vector2 colliderOffset;
    public float colliderOffsetY;
    public float scale = 0.5f;
    public bool isDucking;


    protected override void Awake()
    {
        base.Awake();
        collider2d = this.GetComponent<CapsuleCollider2D>();
        colliderOffset = this.collider2d.offset;
    }


    private void Update()
    {
        if (GameController.inputEnabled)
        {
            bool down = inputState.GetButtonValue(buttons[0]);
            if (down && !isDucking && collisionState.isStanding)
                Duck(true);
            else if (!down && isDucking)
                Duck(false);
        }
    }


    protected virtual void Duck(bool isDucking)
    {
        this.isDucking = isDucking;

        Vector2 colliderSize = collider2d.size;
        float constant;
        float newOffsetY;

        if (isDucking)
        {
			collider2d.direction = CapsuleDirection2D.Horizontal;
            constant = scale;
            newOffsetY = collider2d.offset.y - (colliderSize.y / 2 * colliderOffsetY);
        }
        else
        {
			collider2d.direction = CapsuleDirection2D.Vertical;
            constant = 1 / scale;
            newOffsetY = colliderOffset.y;
        }

		colliderSize.y *= constant;
        collider2d.size = colliderSize;
        collider2d.offset = new Vector2(collider2d.offset.x, newOffsetY);
    }
}
