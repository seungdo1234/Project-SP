using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetactSystem : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    [SerializeField] private Vector3 detactOffset;
    [SerializeField] private Vector3 detactSize;

    private Player player;
    private Vector2 detactVec;
    public void PlayerDetactInit(Player player)
    {
        this.player = player;

        player.Controller.OnDetactEvent += TryDetactTarget;
    }
    private HealthSystem TryDetactTarget()
    {
        Collider2D detaction = Physics2D.OverlapBox(player.transform.position + detactOffset, detactSize, 0, layer);

        if(detaction != null && detaction.TryGetComponent(out HealthSystem target))
        {
            Debug.Log(target.name);
            return target;
        }

        return null;
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
            return;

        // ����� ���� ����
        Gizmos.color = Color.red;

        // �÷��̾� ��ġ�� �������� ���� �߽��� ���
        Vector3 boxCenter = player.transform.position + detactOffset;

        // OverlapBox�� ũ��� ȸ�� ������ �����Ͽ� �׸���
        Gizmos.DrawWireCube(boxCenter, detactSize);
    }
}
