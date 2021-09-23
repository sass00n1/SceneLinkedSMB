using UnityEngine;
using SFTool;

public class RunSMB : SceneLinkedSMB<AIBehaviours>
{
    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //奔跑状态时遇到障碍物，AI将冲破障碍物。
        GameObject obstacle = m_MonoBehaviour.CheckForObstacle();
        if (obstacle != null)
        {
            Destroy(obstacle);
        }
    }
}
