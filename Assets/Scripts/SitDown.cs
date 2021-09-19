using UnityEngine;
using UnityEngine.AI;

public class SitDown : MonoBehaviour
{
    public GameObject player;
    private Animator p_animator;
    private NavMeshAgent p_agent;
    private Rigidbody p_rigidbody;

    private bool isWalkingTowards = false;
    private bool isSittingOn = false;

    private int isSitHash;

    private void OnMouseDown()
    {
        if (!isSittingOn)
        {
            isWalkingTowards = true;
        }
    }

    private void Awake()
    {
        p_animator = player.GetComponent<Animator>();
        p_agent = player.GetComponent<NavMeshAgent>();
        p_rigidbody = player.GetComponent<Rigidbody>();
        isSitHash = Animator.StringToHash("isSit");
    }

    private void Update()
    {
        if (isWalkingTowards)
        {
            if (p_agent.remainingDistance <= p_agent.stoppingDistance)
            {
                Quaternion quaternion = new Quaternion(0f, 180f, 0f, 1f);
                quaternion = quaternion.normalized;
                p_animator.SetBool(isSitHash, true);

                //p_rigidbody.rotation = quaternion;
                player.transform.Rotate(0f, 180f, 0f);
                p_rigidbody.position = new Vector3(1.73f, 1f, -2.85f);

                isWalkingTowards = false;
                isSittingOn = true;
            }
        }
    }
}