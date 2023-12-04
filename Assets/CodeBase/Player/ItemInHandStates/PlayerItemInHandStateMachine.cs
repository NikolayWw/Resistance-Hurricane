using CodeBase.Data.Items;
using CodeBase.Infrastructure.Logic;
using CodeBase.Logic.CustomTimer;
using CodeBase.Services.Input;
using CodeBase.Services.PersistentProgress;
using CodeBase.Services.StaticData;
using UnityEngine;

namespace CodeBase.Player.ItemInHandStates
{
    public class PlayerItemInHandStateMachine : MonoBehaviour, ICoroutineRunner
    {
        private MeleeWeaponInHandState _meleeWeaponState;

        private IInputService _inputService;
        private IStaticDataService _dataService;

        [SerializeField] private Transform _attackPoint;
        [SerializeField] private PlayerLookAt _lookAt;
        [SerializeField] private PlayerAnimation _playerAnimation;

        private IBasePlayerItemInHandState _currentState = new LoopItemInHandState();
        private IPersistentProgressService _persistentProgressService;

        public void Construct(IInputService inputService, IStaticDataService dataService, IPersistentProgressService persistentProgressService)
        {
            _inputService = inputService;
            _dataService = dataService;
            _persistentProgressService = persistentProgressService;
            _persistentProgressService.PlayerProgress.OnHappened += Happened;
            InitStates();
        }

        private void OnDestroy()
        {
            _persistentProgressService.PlayerProgress.OnHappened -= Happened;
        }

        private void Update()
        {
            _currentState.Update();
        }

        private void FixedUpdate()
        {
            _currentState.FixedUpdate();
        }

        public void EnterMeleeWeapon(MeleeWeaponInventoryData meleeData)
        {
            _currentState.Exit();
            _meleeWeaponState.Enter(meleeData);
            _currentState = _meleeWeaponState;
        }

        private void Happened()
        {
            _currentState.Exit();
            _currentState = new LoopItemInHandState();
            _playerAnimation.PlayDie();
        }

        private void InitStates()
        {
            _meleeWeaponState = new MeleeWeaponInHandState(_playerAnimation, _lookAt, new CustomTimer(this), _attackPoint, _inputService, _dataService);
        }

        private void OnDrawGizmos()
        {
            if (_currentState != null)
                _currentState.OnDrawGizmos();
        }
    }
}