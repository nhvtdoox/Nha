using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    private ThirdPersonCharacter character;
    public Camera cam;
    public NavMeshAgent agent;
    private Animator animator;
    private int isWalkingHash;
    private int danceHash;
    private int isSleepHash;
    private int isSitHash;
    private bool isDance = false;
    private bool isSleep = false;
    private bool isSit = false;
    private int lastMove = 1;

    private void Start()
    {
        //agent.updateRotation = false;
        character = GetComponent<ThirdPersonCharacter>();
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        danceHash = Animator.StringToHash("dance");
        isSleepHash = Animator.StringToHash("isSleep");
        isSitHash = Animator.StringToHash("isSit");
    }

    private void Update()
    {
        Walk();
    }

    private void Walk()
    {
        bool keyMove = Input.GetMouseButtonDown(0);

        if (keyMove)
        {
            isDance = false;
            animator.SetBool(isSleepHash, false);
            animator.SetBool(isSitHash, false);
            animator.SetBool(isWalkingHash, true);
            Debug.Log(animator.GetBool(isWalkingHash));
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        

        //if (agent.remainingDistance == 0)
        //{
        //    animator.SetBool(isWalkingHash, false);
        //}

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
            animator.SetBool(isWalkingHash, false);
        }
    }
}