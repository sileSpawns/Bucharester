using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerState :State<Enemy>
{
    public override void OnEnter(Enemy agent)
    {
        Debug.Log("Following Player State");
    }

    public override void Execute(Enemy agent)
    {
        agent.agent.SetDestination(agent.player.position);

        if (!agent.targetFound(agent.player))
            agent.ChangeState(new LookForPlayer());
    }

    public override void OnExit(Enemy agent)
    {
        Debug.LogWarning("Im out");
    }
}
