using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{

    public AudioClip footstep;
    public AudioClip pigAttack;
    // public AudioClip sword;
    public AudioSource feetAudioSource;
    public AudioSource headAudioSource;
    private Animator anim;
    private bool combat;
    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
    anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      // currentLeftFootstep = anim.GetFloat("leftFootstep");
      // Debug.Log(currentLeftFootstep);
      // if (currentLeftFootstep > 0 && lastLeftFootstep < 0){
      //   Footsteps();
      // }
      // lastLeftFootstep = anim.GetFloat("leftFootstep");
      //
      // currentRightFootstep = anim.GetFloat("rightFootstep");
      // Debug.Log(currentRightFootstep);
      // if (currentRightFootstep < 0 && lastRightFootstep > 0){
      //   Footsteps();
      // }
      // lastRightFootstep = anim.GetFloat("rightFootstep");
      movementSpeed = anim.GetFloat("speedPercent");
      combat = anim.GetBool("inCombat");


    }

    void Footsteps(){
      if (movementSpeed > 0.1){
        feetAudioSource.PlayOneShot(footstep);
      }
    }

    void AttackSound(){
      if (combat == true){
        headAudioSource.PlayOneShot(pigAttack);
      }
    }
}
