using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 offset = new Vector3(0f, 5f, -10f);
    [SerializeField] private float smoothness = 5f;

    private void LateUpdate()
    {
        if (playerTransform == null)
        {
            Debug.LogWarning("Player cannot found!");
            return;
        }

        
        Vector3 desiredPosition = playerTransform.position + offset;

 
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothness * Time.deltaTime);
    }

    public void SetPlayerTransform(Transform newPlayerTransform)
    {
        playerTransform = newPlayerTransform;
    }
}
