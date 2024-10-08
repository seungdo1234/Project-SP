using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public PlayerStatData Data { get; private set; }
    
    public PlayerBehaviorController Controller { get; private set; }
    public PlayerAttackSystem Attack { get; private set; }
    public PlayerDetactSystem Detact { get; private set; }
    public PlayerAnimationEventHandler Animation { get; private set; }

    private void Awake()
    {
        Controller = GetComponent<PlayerBehaviorController>();
        Attack = GetComponent<PlayerAttackSystem>();
        Detact = GetComponent<PlayerDetactSystem>();
        Animation = GetComponentInChildren<PlayerAnimationEventHandler>();
    }
    // Start is called before the first frame update00
    void Start()
    {
        GameManager.Instance.Player = this;
    }


    public void PlayerInit()
    {
        Attack.PlayerAttackInit(this);
        Detact.PlayerDetactInit(this);
        Controller.PlayerBehaviorInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
