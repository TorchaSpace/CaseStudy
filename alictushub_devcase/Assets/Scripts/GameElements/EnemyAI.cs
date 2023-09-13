using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float attackRangeSquared = 100f;
    [SerializeField] private Animator animator;

    private Transform playerTransform;
    private bool playerInRange = false;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogWarning("Player with tag '" + playerTag + "' not found.");
        }
    }

    private void Update()
    {
        if (playerTransform == null)
        {
            return;
        }

        float distanceToPlayerSquared = (playerTransform.position - transform.position).sqrMagnitude;

        LookAtPlayer();

        if (distanceToPlayerSquared >= attackRangeSquared)
        {
            FollowPlayer();
            playerInRange = false;
        }
        else
        {
            if (!playerInRange)
            {
                StopMoving();
                ChangeAnimationState("isStopped");
                playerInRange = true;
            }
        }
    }

    private void LookAtPlayer()
    {
        if (playerTransform != null)
        {
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void FollowPlayer()
    {
        if (playerTransform != null)
        {
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            Vector3 moveDirection = directionToPlayer.normalized;
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    private void StopMoving()
    {
        moveSpeed = 0;
    }

    private void ChangeAnimationState(string newState)
    {
        animator.SetBool(newState, true);
    }
}
