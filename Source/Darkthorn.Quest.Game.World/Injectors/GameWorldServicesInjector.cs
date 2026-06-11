using Autofac;
using Darkthorn.Quest.Engine.Enumerations;
using Darkthorn.Quest.Engine.Game;
using Darkthorn.Quest.Game.World.Entities.Factories;
using Darkthorn.Quest.Game.World.Systems;
using System;

namespace Darkthorn.Quest.Game.World.Injectors;

public class GameWorldServicesInjector : IGameRegisterServicesInjector
{
    public string Name
        => "Game World Services Injector";

    public string Description
        => "Injects game world services into the game engine.";

    public Type[] Dependencies
        => [];

    public Platform Platform
        => Platform.All;

    public void OnRegisterServices(ContainerBuilder builder)
    {
        _ = builder.RegisterType<GameWorldInjector>().AsImplementedInterfaces().SingleInstance();

        _ = builder.RegisterType<WorldManager>().As<WorldManager>().SingleInstance();

        _ = builder.RegisterType<PlayerEntityFactory>().As<PlayerEntityFactory>().InstancePerDependency();

        _ = builder.RegisterType<MovementSystem>().AsImplementedInterfaces().InstancePerDependency();
        _ = builder.RegisterType<InputSystem>().AsImplementedInterfaces().InstancePerDependency();
        _ = builder.RegisterType<RenderSystem>().AsImplementedInterfaces().InstancePerDependency();
    }
}