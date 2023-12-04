using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerLookAt : MonoBehaviour
    {
        [SerializeField] private Transform _bodyTransform;
        private float _startScaleX;

        private void Start()
        {
            _startScaleX = _bodyTransform.localScale.x;
        }

        public void LookAt(bool isRight)
        {
            Vector3 scale = _bodyTransform.localScale;
            scale.x = isRight ? _startScaleX : -_startScaleX;
            _bodyTransform.localScale = scale;
        }
    }
}