using UnityEngine;
using System.Collections;

/// <summary>
/// This is attached to our porjectiles
/// It makes sure to recycle the projectile when an impact has happend
/// </summary>
public class ImpactBehaviour : StateMachineBehaviour {

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Releases the projectile, so that our object pool can reuse it later
        GameManager.Instance.Pool.ReleaseObject(animator.gameObject);
        
    }
}
