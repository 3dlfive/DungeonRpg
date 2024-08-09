using Godot;
using System;

public partial class EnemyReturnState : EnemyState
{
    private Vector3 destination;

    public override void _Ready()
    {
        base._Ready();

        Vector3 localPos = characterNode.Pathnode.Curve.GetPointPosition(0);
        Vector3 globalPos = characterNode.Pathnode.GlobalPosition;
        destination = localPos + globalPos;
    }
    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameConstants
        .ANIM_MOVE
        );

    }
    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.GlobalPosition == destination)
        {
            return;
        }
        characterNode.Velocity = characterNode.GlobalPosition.DirectionTo(destination);

        characterNode.MoveAndSlide();
    }
}
