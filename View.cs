using UnityEngine;

[RequireComponent(typeof(GoldUI))]
public class View : MonoBehaviour
{
    [SerializeField] private Base _base;

    private GoldUI _ui;

    private void Awake()
    {
        _ui = GetComponent<GoldUI>();
    }

    private void OnEnable()
    {
        _base.ResourseCollected += IncreaseGoldAmount;
    }

    private void IncreaseGoldAmount()
    {
        _ui.UpdateText(_base.CollectedResounrseAmount);
    }
}
