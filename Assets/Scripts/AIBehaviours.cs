using UnityEngine;
using SFTool;

public class AIBehaviours : MonoBehaviour
{
    private Transform trans_Eye;
    private Animator animator;

    public bool isWalk;
    public bool isRun;

    private void Awake()
    {
        trans_Eye = transform.Find("Eye");
        animator = GetComponent<Animator>();

        //���г�ʼ������
        SceneLinkedSMB<AIBehaviours>.Initialise(animator, this);
    }

    private void FixedUpdate()
    {
        CheckForObstacle();

        if (isWalk)
        {
            Walk();
        }
        if (isRun)
        {
            Run();
        }
    }

    //���ǰ���Ƿ����ϰ�
    public GameObject CheckForObstacle()
    {
        Debug.DrawRay(trans_Eye.position, transform.right * 0.3f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(trans_Eye.position, transform.right, 0.3f, 1 << 6);
        if (hit)
        {
            return hit.collider.gameObject;
        }
        else
        {
            return null;
        }
    }

    //����
    public void Walk()
    {
        animator.SetBool("Walk", true);

        transform.Translate(new Vector3(2, 0, 0) * Time.deltaTime);
    }

    //����
    public void Run()
    {
        animator.SetBool("Run", true);

        transform.Translate(new Vector3(4, 0, 0) * Time.deltaTime);
    }

    //��ͷ
    public void Back()
    {
        transform.eulerAngles = new Vector3(0, -180, 0);
        transform.Translate(new Vector3(2, 0, 0) * Time.deltaTime);
    }
}
