using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    [SerializeField]
    private AIBehaviours AI;

    [SerializeField]
    private Button btnWalk;

    [SerializeField]
    private Button btnRun;

    private void Awake()
    {
        btnWalk.onClick.AddListener(() => { AI.isWalk = true; btnWalk.interactable = false;btnRun.interactable = false; });
        btnRun.onClick.AddListener(() => { AI.isRun = true; btnWalk.interactable = false; btnRun.interactable = false; });
    }
}
