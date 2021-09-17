using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int danceHash;
    int isSleepHash;
    int isSitHash;
    bool isDance = false;
    bool isSleep = false;
    bool isSit = false;
    int lastMove = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        danceHash = Animator.StringToHash("dance");
        isSleepHash = Animator.StringToHash("isSleep");
        isSitHash = Animator.StringToHash("isSit");
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Dance();
        Sleep();
        Sit();
    }
    void Walk()
    {
        bool keyMove = Input.GetKey("w");
        bool isWalking = animator.GetBool(isWalkingHash);
        if (!isWalking && keyMove)
        {
            isDance = false;
            animator.SetBool(isSleepHash, false);
            animator.SetBool(isSitHash, false);
            animator.SetBool(isWalkingHash, true);
        }

        if (isWalking && !keyMove)
        {
            animator.SetBool(isWalkingHash, false);
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
    void Sit()
    {
        bool keySit = Input.GetKeyDown("r");
        if (keySit)
        {
            isDance = false;
            isSit = !isSit;
            animator.SetBool(isSitHash, isSit);
        }
    }
}
