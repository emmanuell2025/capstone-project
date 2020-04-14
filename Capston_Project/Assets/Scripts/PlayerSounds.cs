using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{

    public AudioClip footstep;
    public AudioSource audioS;
    private Animator anim;
    public float currentLeftFootstep;
    public float currentRightFootstep;
    public float lastLeftFootstep;
    public float lastRightFootstep;
    // Start is called before the first frame update
    void Start()
    {
    anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      currentLeftFootstep = anim.GetFloat("leftFootstep");
      Debug.Log(currentLeftFootstep);
      if (currentLeftFootstep > 0 && lastLeftFootstep < 0){
        Footsteps();
      }
      lastLeftFootstep = anim.GetFloat("leftFootstep");

      currentRightFootstep = anim.GetFloat("rightFootstep");
      Debug.Log(currentRightFootstep);
      if (currentRightFootstep < 0 && lastRightFootstep > 0){
        Footsteps();
      }
      lastRightFootstep = anim.GetFloat("rightFootstep");

    }

    void Footsteps(){
      audioS.PlayOneShot(footstep);
    }
}
