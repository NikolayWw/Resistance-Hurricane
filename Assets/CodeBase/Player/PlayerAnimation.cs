using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private readonly int DieHash = Animator.StringToHash("Die");

        [SerializeField] private Animator _animator;

        public void Play(string clipName) =>
            _animator.Play(clipName, 0, 0);

        public void PlayDie() => 
            _animator.Play(DieHash, 0, 0);
    }
}