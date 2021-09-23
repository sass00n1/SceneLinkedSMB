using UnityEngine;
using SFTool;

public class WalkSMB : SceneLinkedSMB<AIBehaviours>
{
    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //����״̬ʱ�����ϰ��AI����ת����
        GameObject obstacle = m_MonoBehaviour.CheckForObstacle();
        if (obstacle != null)
        {
            m_MonoBehaviour.Back();
        }
    }
}
