using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraBehavior : MonoBehaviour
{
    public new Camera camera;
    public GameObject player;
    protected bool shaking;
    protected FollowPlayer followPlayer;
    protected const float CAMERA_SIZE_ZOOM_IN = 46f;
    protected const float CAMERA_SIZE_ZOOM_OUT = 52f;
    protected InputState playerInputState;
    protected Rigidbody2D playerBody2d;
    protected float cameraYPos = 30f;
    private ZoomIn zoomIn;
    private ZoomOut zoomOut;
    private Shake shake;
    private float xOffset = 6f;

    void Awake()
    {
        followPlayer = camera.GetComponent<FollowPlayer>();
        zoomOut = GetComponent<ZoomOut>();
        shake = GetComponent<Shake>();
        zoomIn = camera.GetComponent<ZoomIn>();
        playerInputState = player.GetComponent<InputState>();
        playerBody2d = player.GetComponent<Rigidbody2D>();
    }

    protected void EnableFollowPlayerBehavior()
    {
        followPlayer.enabled = true;
    }

    protected void DisableFollowPlayerBehavior()
    {
        followPlayer.enabled = false;
    }

    protected void EnableZoomOut()
    {
        zoomOut.enabled = true;
    }

    protected void DisableZoomOut()
    {
        zoomOut.enabled = false;
    }

    protected void EnableZoomIn()
    {
        zoomIn.enabled = true;
    }

    protected void DisableZoomIn()
    {
        zoomIn.enabled = false;
    }

    protected void Shake()
    {
        shaking = true;
        shake.enabled = true;
    }

    protected void Unshake()
    {
        shaking = false;
        shake.enabled = false;
    }

    protected Vector3 SmoothMotion(Vector3 followerPosition, Vector3 targetPosition, ref float xVelocity,
        ref float yVelocity, float smoothTime)
    {
        float newXPosition = Mathf.SmoothDamp(followerPosition.x, targetPosition.x, ref xVelocity, smoothTime);
        float newYPosition = Mathf.SmoothDamp(followerPosition.y, targetPosition.y, ref yVelocity, 3f);
        followerPosition = new Vector3(newXPosition, newYPosition, targetPosition.z);
        return followerPosition;
    }

    protected void FreezePlayerPosition()
    {
        if (player.transform.position.x < (camera.transform.position.x - camera.orthographicSize * camera.aspect) + xOffset)
        {
            Vector3 pos = camera.WorldToViewportPoint(player.transform.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            player.transform.position = camera.ViewportToWorldPoint(pos);
        }
    }
}
