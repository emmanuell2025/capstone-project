using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{

    public AudioClip footstep;
    public AudioSource audioS;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Footsteps(){
      audioS.PlayOneShot(footstep);
    }
}
