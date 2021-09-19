using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class SitDown : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;
    bool isWalkingTowards = false;
    bool isSitting = false;
    Animator anim;
    private ThirdPersonCharacter character;
    private int isSitHash;
    private void OnMouseDown()
    {
        if (!isSitting)
        {
            isWalkingTowards = true;
            Debug.Log("is siting "+isSitting);
            Debug.Log("is walk"+isWalkingTowards);
        }        
    }

    private void Start()
    {
        anim = player.GetComponent<Animator>();
        character = player.GetComponent<ThirdPersonCharacter>();
        agent = player.GetComponent<NavMeshAgent>();
        isSitHash = Animator.StringToHash("isSit");
    }

    private void Update()
    {
        if (isWalkingTowards)
        {
            if(agent.remainingDistance <= agent.stoppingDistance)
            {
                //character.Move(Vector3.zero, false, false);
                anim.SetBool(isSitHash, true);
                Debug.Log(isSitHash);

                player.transform.rotation = transform.rotation;

                isWalkingTowards = false;
                isSitting = true;
            }

        }
    }
}
