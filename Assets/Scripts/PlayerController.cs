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
    private bool isDance = false;
    private bool isSleep = false;
    private int lastMove = 1;

    private void Awake()
    {
        //agent.updateRotation = false;
        character = GetComponent<ThirdPersonCharacter>();
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        danceHash = Animator.StringToHash("dance");
        isSleepHash = Animator.StringToHash("isSleep");
        //isSitHash = Animator.StringToHash("isSit");
    }

    private void Update()
    {
        Walk();
        Dance();
        Sleep();
        //Sit();
    }

    private void Walk()
    {
        //bool keyMove = Input.GetMouseButtonDown(0);

        if (Input.GetMouseButton(0))
        {
            isDance = false;
            animator.SetBool(isSleepHash, false);
            animator.SetInteger("isWalking", 1);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {               
                agent.SetDestination(hit.point);
            }
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);

        }
        else
        {
            character.Move(Vector3.zero, false, false);
            animator.SetInteger("isWalking", 0);
        }
    }
    void Dance()
    {
        bool keyDance = Input.GetKeyDown("q");
        if (keyDance)
        {
            isDance = !isDance;
            animator.SetInteger(danceHash, lastMove);
        }
        if (isDance)
        {
            DanceMoves();
        }
        else if (!isDance)
        {
            animator.SetInteger(danceHash, 0);
        }
    }
    void DanceMoves()
    {
        if (Input.GetKey("1"))
        {
            animator.SetInteger(danceHash, 1);
            lastMove = 1;
        }
        if (Input.GetKey("2"))
        {
            animator.SetInteger(danceHash, 2);
            lastMove = 2;
        }
        if (Input.GetKey("3"))
        {
            animator.SetInteger(danceHash, 3);
            lastMove = 3;
        }
        if (Input.GetKey("4"))
        {
            animator.SetInteger(danceHash, 4);
            lastMove = 4;
        }
        if (Input.GetKey("5"))
        {
            animator.SetInteger(danceHash, 5);
            lastMove = 5;
        }
    }
    void Sleep()
    {
        bool keySleep = Input.GetKeyDown("e");
        if (keySleep)
        {
            isDance = false;
            isSleep = !isSleep;
            animator.SetBool(isSleepHash, isSleep);
        }
    }
    //void Sit()
    //{
    //    bool keySit = Input.GetKeyDown("r");
    //    if (keySit)
    //    {
    //        isDance = false;
    //        isSit = !isSit;
    //        animator.SetBool(isSitHash, isSit);
    //    }

    //}
}