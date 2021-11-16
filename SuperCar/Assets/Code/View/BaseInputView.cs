﻿using UnityEngine;

public abstract class BaseInputView : MonoBehaviour
{
    protected float _speed;
    private SubscriptionProperty<float> _leftMove;
    private SubscriptionProperty<float> _rightMove;

    public virtual void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
    {
        _speed = speed;
        _leftMove = leftMove;
        _rightMove = rightMove;
    }

    protected virtual void OnLeftMove(float value)
    {
        _leftMove.Value = value;
    }

    protected virtual void OnRightMove(float value)
    {
        _rightMove.Value = value;
    }
}
