using Autofac;
using Darkthorn.Quest.Engine.Injectors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Darkthorn.Quest.Engine.Game;

public interface IGameLifecycleInjector : IInjector
{

}

public interface IGameRegisterServicesInjector : IGameLifecycleInjector
{
    void OnRegisterServices(ContainerBuilder builder);
}

public interface IGameConfigureServicesInjector: IGameLifecycleInjector
{
    void OnConfigureServices(IServiceProvider provider);
}

public interface IGameInputInjector : IGameLifecycleInjector
{
    void HandleInput(GameTime gameTime, KeyboardState keyboardState, MouseState mouseState);
}

public interface IGameUpdateInjector : IGameLifecycleInjector
{
    void Update(GameTime gameTime);
}

public interface IGameDrawInjector : IGameLifecycleInjector
{
    void Draw(GameTime gameTime, SpriteBatch spriteBatch);
}