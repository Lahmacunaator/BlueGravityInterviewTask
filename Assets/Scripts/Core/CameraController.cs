using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Transform player;
    public float zoomInSize = 2.0f;
    public float zoomOutSize = 5.0f;
    public float zoomSpeed = 2.0f;
    
    private bool isZoomedIn = false;
    private Coroutine zoomCoroutine;

    private void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main; // Default to the main camera if not set
        }
        ToggleZoom();
    }
    
    public void ToggleZoom()
    {
        if (zoomCoroutine != null)
        {
            StopCoroutine(zoomCoroutine);
        }

        var targetSize = isZoomedIn ? zoomOutSize : zoomInSize;
        var targetPosition = isZoomedIn ? new Vector3(0, 0, -10) : new Vector3(player.position.x, player.position.y, -10);

        zoomCoroutine = StartCoroutine(SmoothZoom(targetSize, targetPosition));
        isZoomedIn = !isZoomedIn;
    }

    System.Collections.IEnumerator SmoothZoom(float targetSize, Vector3 targetPosition)
    {
        var startSize = mainCamera.orthographicSize;
        var startPosition = mainCamera.transform.position;
        var t = 0.0f;

        while (t < 1.0f)
        {
            t += Time.deltaTime * zoomSpeed;
            mainCamera.orthographicSize = Mathf.Lerp(startSize, targetSize, t);
            mainCamera.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        mainCamera.orthographicSize = targetSize;
        mainCamera.transform.position = targetPosition;
    }
}