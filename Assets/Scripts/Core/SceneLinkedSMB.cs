using UnityEngine;
using UnityEngine.Animations;

namespace SFTool
{
    /// <summary>
    /// 场景链接SMB
    /// </summary>
    public class SceneLinkedSMB<TMonoBehaviour> : SealedSMB where TMonoBehaviour : MonoBehaviour
    {
        protected TMonoBehaviour m_MonoBehaviour;

        bool m_FirstFrameHappened;
        bool m_LastFrameHappened;

        //Mono成员进行初始化
        public static void Initialise(Animator animator, TMonoBehaviour monoBehaviour)
        {
            SceneLinkedSMB<TMonoBehaviour>[] sceneLinkedSMBs = animator.GetBehaviours<SceneLinkedSMB<TMonoBehaviour>>();
            for (int i = 0; i < sceneLinkedSMBs.Length; i++)
            {
                sceneLinkedSMBs[i].InternalInitialise(animator, monoBehaviour);
            }
        }

        protected void InternalInitialise(Animator animator, TMonoBehaviour monoBehaviour)
        {
            m_MonoBehaviour = monoBehaviour;
            OnStart(animator);
        }

        public sealed override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
        {
            m_FirstFrameHappened = false;

            OnSLStateEnter(animator, stateInfo, layerIndex);
            OnSLStateEnter(animator, stateInfo, layerIndex, controller);
        }

        public sealed override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
        {
            if (!animator.gameObject.activeSelf)
                return;

            if (animator.IsInTransition(layerIndex) && animator.GetNextAnimatorStateInfo(layerIndex).fullPathHash == stateInfo.fullPathHash)
            {
                OnSLTransitionToStateUpdate(animator, stateInfo, layerIndex);
                OnSLTransitionToStateUpdate(animator, stateInfo, layerIndex, controller);
            }

            if (!animator.IsInTransition(layerIndex) && m_FirstFrameHappened)
            {
                OnSLStateNoTransitionUpdate(animator, stateInfo, layerIndex);
                OnSLStateNoTransitionUpdate(animator, stateInfo, layerIndex, controller);
            }

            if (animator.IsInTransition(layerIndex) && !m_LastFrameHappened && m_FirstFrameHappened)
            {
                m_LastFrameHappened = true;

                OnSLStatePreExit(animator, stateInfo, layerIndex);
                OnSLStatePreExit(animator, stateInfo, layerIndex, controller);
            }

            if (!animator.IsInTransition(layerIndex) && !m_FirstFrameHappened)
            {
                m_FirstFrameHappened = true;

                OnSLStatePostEnter(animator, stateInfo, layerIndex);
                OnSLStatePostEnter(animator, stateInfo, layerIndex, controller);
            }

            if (animator.IsInTransition(layerIndex) && animator.GetCurrentAnimatorStateInfo(layerIndex).fullPathHash == stateInfo.fullPathHash)
            {
                OnSLTransitionFromStateUpdate(animator, stateInfo, layerIndex);
                OnSLTransitionFromStateUpdate(animator, stateInfo, layerIndex, controller);
            }
        }

        public sealed override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
        {
            m_LastFrameHappened = false;

            OnSLStateExit(animator, stateInfo, layerIndex);
            OnSLStateExit(animator, stateInfo, layerIndex, controller);
        }

        public virtual void OnStart(Animator animator) { }
        public virtual void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
        public virtual void OnSLTransitionToStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
        public virtual void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
        public virtual void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
        public virtual void OnSLStatePreExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
        public virtual void OnSLTransitionFromStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
        public virtual void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
        public virtual void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller) { }
        public virtual void OnSLTransitionToStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller) { }
        public virtual void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller) { }
        public virtual void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller) { }
        public virtual void OnSLStatePreExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller) { }
        public virtual void OnSLTransitionFromStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller) { }
        public virtual void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller) { }
    }

    //StateMachineBehaviour是一个可添加到状态机状态的组件。它是一个基类，所有状态脚本都派生自该类。
    public abstract class SealedSMB : StateMachineBehaviour
    {
        //当状态机评估此状态时，在第一个 Update 帧上进行调用。
        public sealed override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
        //除第一帧和最后一帧外，在每个 Update 帧上进行调用。
        public sealed override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
        //当状态机评估此状态时，在最后一个 Update 帧上进行调用。
        public sealed override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
    }
}