using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private Enemy target;
    private Camera mainCamera;

    private readonly float raycastDistance = 100f;

    private bool isClick;
    private void Awake()
    {
        mainCamera = Camera.main;
    }
    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, transform.forward, raycastDistance, layerMask);
            if (hit && hit.collider.TryGetComponent(out Enemy enemy))
            {
                target = enemy;
                UIManager.Instance.StatusUI.ActivateStatusUI(target);
            }
            else
            {
                if (target != null)
                {
                    UIManager.Instance.StatusUI.DeActivateStatusUI();
                    target = null;
                }
            }
        }
        
    }
}
