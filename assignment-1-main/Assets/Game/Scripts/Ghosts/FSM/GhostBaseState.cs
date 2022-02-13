using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBaseState : FSMBaseState
{
    protected GhostController ghostController;

    public override void Init(GameObject _owner, FSM _fsm)
    {
        base.Init(_owner, _fsm);

        GhostFSM ghostFSM = (GhostFSM)fsm;
        ghostController = ghostFSM.ghost;
    }
}
