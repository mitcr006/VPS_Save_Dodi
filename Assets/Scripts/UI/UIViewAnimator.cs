using UnityEngine;

namespace GHOST.UI
{
    public class UIViewAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private static readonly int Active = Animator.StringToHash("Active");
    
        public void Show() => _animator.SetBool(Active, true);

        public void Hide() => _animator.SetBool(Active, false);
    }
}