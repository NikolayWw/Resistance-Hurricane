using CodeBase.Data;
using CodeBase.Infrastructure.Logic;
using CodeBase.Services;
using CodeBase.Services.Cleanup;
using CodeBase.Services.Factory;
using CodeBase.Services.Input;
using CodeBase.Services.LogicFactory;
using CodeBase.Services.PersistentProgress;
using CodeBase.Services.StaticData;
using CodeBase.UI.Services.Factory;
using static CodeBase.Data.GameConstants;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;
        private readonly ICoroutineRunner _coroutineRunner;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services, ICoroutineRunner coroutineRunner)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            _coroutineRunner = coroutineRunner;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(InitSceneKey, OnLoaded);
        }

        public void Exit()
        { }

        private void RegisterServices()
        {
            _services.RegisterSingle<IGameStateMachine>(_stateMachine);
            RegisterStaticData();
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services));
            _services.RegisterSingle<ILogicFactory>(new LogicFactory(_services, _coroutineRunner));
            _services.RegisterSingle<IUIFactory>(new UIFactory(_services));
            RegisterPersistentProgress();
            _services.RegisterSingle<IInputService>(new InputService());

            _services.RegisterSingle<ICleanupService>(new CleanupService(
                _services.Single<IInputService>(),
                _services.Single<ILogicFactory>(),
                _services.Single<IPersistentProgressService>(),
                _services.Single<IStaticDataService>()));
        }

        private void RegisterPersistentProgress()
        {
            float startHealth = _services.Single<IStaticDataService>().PlayerData.StartHealth;
            PersistentProgressService progressService = new();
            progressService.PlayerProgress = new PlayerProgress(startHealth);
            _services.RegisterSingle<IPersistentProgressService>(progressService);
        }

        private void OnLoaded()
        {
            _stateMachine.Enter<LoadLevelState, string>(MainSceneKey);
        }

        private void RegisterStaticData()
        {
            var service = new StaticDataService();
            service.Load();
            _services.RegisterSingle<IStaticDataService>(service);
        }
    }
}