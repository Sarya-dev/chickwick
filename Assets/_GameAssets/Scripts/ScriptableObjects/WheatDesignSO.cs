using UnityEngine;

[CreateAssetMenu(fileName = "WheatDesignSO", menuName = "ScriptableObjects/WheatDesignSO", order = 1)]
public class WheatDesignSO : ScriptableObject
{
    [SerializeField] private float _incrreaseDecreaseMultiplier;
    [SerializeField] private float _resetBoostDuration;

    public float IncrreaseDecreaseMultiplier => _incrreaseDecreaseMultiplier;
    public float ResetBoostDuration => _resetBoostDuration;


}
