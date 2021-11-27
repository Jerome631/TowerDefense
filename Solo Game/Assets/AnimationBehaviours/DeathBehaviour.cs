using UnityEngine;
using System.Collections;

/// <summary>
/// This script is attached to the monster's death animation
/// It makes sure that the monster is recycled inside the object pool
/// </summary>
public class DeathBehaviour : StateMachineBehaviour {

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Releases the monster after it has died, so that it can be reused later
        animator.GetComponent<Monster>().Release();
  
    }

}
