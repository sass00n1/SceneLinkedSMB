using UnityEngine;
using SFTool;

public class WalkSMB : SceneLinkedSMB<AIBehaviours>
{
    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //行走状态时遇到障碍物，AI将调转方向。
        GameObject obstacle = m_MonoBehaviour.CheckForObstacle();
        if (obstacle != null)
        {
            m_MonoBehaviour.Back();
        }
    }
}
