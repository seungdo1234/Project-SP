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

    private HealthSystem prevTarget;
    public void PlayerDetactInit(Player player)
    {
        this.player = player;

        player.Controller.OnDetactEvent += TryDetactTarget;
    }
    private HealthSystem TryDetactTarget()
    {
        Collider2D detaction = Physics2D.OverlapBox(player.transform.position + detactOffset, detactSize, 0, layer);

        if(detaction != null)
        {
            if(prevTarget != null && detaction.gameObject == prevTarget.gameObject)
            {
                return prevTarget;
            }
            else if(detaction.TryGetComponent(out HealthSystem target))
            {
                prevTarget = target;
                return target;
            }
        }

        return null;
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
            return;

        // 기즈모 색상 설정
        Gizmos.color = Color.red;

        // 플레이어 위치와 오프셋을 더한 중심점 계산
        Vector3 boxCenter = player.transform.position + detactOffset;

        // OverlapBox의 크기와 회전 각도를 설정하여 그리기
        Gizmos.DrawWireCube(boxCenter, detactSize);
    }
}
