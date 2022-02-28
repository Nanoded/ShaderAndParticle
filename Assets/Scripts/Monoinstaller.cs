using UnityEngine;
using Zenject;

public class Monoinstaller : MonoInstaller
{
    [SerializeField] private PlayerMovement _playerMovement;
    public override void InstallBindings()
    {
        Container.Bind<PlayerMovement>().FromInstance(_playerMovement);
    }
}