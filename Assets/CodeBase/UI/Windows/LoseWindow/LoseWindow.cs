using CodeBase.Data;
using CodeBase.Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows.LoseWindow
{
    public class LoseWindow : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;
        private IGameStateMachine _gameStateMachine;

        public void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
            _restartButton.onClick.AddListener(() => _gameStateMachine.Enter<LoadLevelState, string>(GameConstants.MainSceneKey));
            _exitButton.onClick.AddListener(Application.Quit);
        }
    }
}