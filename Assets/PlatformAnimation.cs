using UnityEngine;

public class PlatformAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.updateMode = AnimatorUpdateMode.Fixed;
    }
}
