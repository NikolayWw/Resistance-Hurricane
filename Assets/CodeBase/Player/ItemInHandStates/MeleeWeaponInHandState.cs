using CodeBase.Data.Items;
using CodeBase.Logic.CustomTimer;
using CodeBase.Logic.Health;
using CodeBase.Services.Input;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Items.Weapon.MeleeWeapon;
using UnityEngine;

namespace CodeBase.Player.ItemInHandStates
{
    public class MeleeWeaponInHandState : IBasePlayerItemInHandState
    {
        private readonly PlayerAnimation _playerAnimation;
        private readonly IInputService _inputService;
        private readonly IStaticDataService _dataService;
        private readonly PlayerLookAt _lookAt;
        private readonly CustomTimer _timer;
        private readonly Transform _attackPoint;

        private MeleeWeaponInventoryData _data;
        private MeleeWeaponConfig _config;

        private float _currentAttackDelay;

        public MeleeWeaponInHandState(PlayerAnimation playerAnimation, PlayerLookAt lookAt, CustomTimer timer, Transform attackPoint, IInputService inputService, IStaticDataService dataService)
        {
            _lookAt = lookAt;
            _timer = timer;
            _playerAnimation = playerAnimation;
            _inputService = inputService;
            _dataService = dataService;
            _attackPoint = attackPoint;

        }

        public void Enter(MeleeWeaponInventoryData itemData)
        {
            _data = itemData;
            _config = _dataService.ForMeleeWeapon(_data.Id);
            _inputService.Hit += Hit;
            _currentAttackDelay = _config.DelayBeforeAttack;
        }

        public void Exit()
        {
            _timer.Stop();
            _inputService.Hit -= Hit;
        }

        public void Update()
        {
            _currentAttackDelay += Time.deltaTime;
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(_attackPoint.position, _config.AttackRadius);
        }

        private void Hit(bool isRightDirection)
        {
            _lookAt.LookAt(isRightDirection);

            if (_currentAttackDelay < _config.DelayBeforeAttack)
                return;

            _currentAttackDelay = 0;
            _timer.Stop();
            _playerAnimation.Play(_config.AttackAnimationName);
            _timer.Start(_config.DelayBeforeApplyDamage, HitProcess);
        }

        private void HitProcess()
        {

            Collider2D[] colliders = Physics2D.OverlapCircleAll(_attackPoint.position, _config.AttackRadius);

            foreach (Collider2D collision in colliders)
            {
                if (collision.isTrigger)
                    continue;

                Rigidbody2D attachedRigidbody = collision.attachedRigidbody;
                if (attachedRigidbody != null && attachedRigidbody.TryGetComponent(out IApplyDamage apply))
                {
                    apply.ApplyDamage(_config.Damage);
                    break;
                }
            }
        }
    }
}