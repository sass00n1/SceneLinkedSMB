using UnityEngine;
using SFTool;

public class RunSMB : SceneLinkedSMB<AIBehaviours>
{
    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //����״̬ʱ�����ϰ��AI�������ϰ��
        GameObject obstacle = m_MonoBehaviour.CheckForObstacle();
        if (obstacle != null)
        {
            Destroy(obstacle);
        }
    }
}
