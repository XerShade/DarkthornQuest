using Autofac;
using Autofac.Extensions.DependencyInjection;
using Darkthorn.Quest.Engine.Services;
using Darkthorn.Quest.Engine.Services.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using GameBase = Microsoft.Xna.Framework.Game;

namespace Darkthorn.Quest.Engine.Game;

public class GameLifecycle : GameBase
{
    protected IInjectorService InjectorService { get; private set; }
    protected ContainerBuilder Builder { get; private set; }
    protected IServiceProvider Provider { get; private set; }

    protected GraphicsDeviceManager GraphicsDeviceManager { get; private set; }
    protected SpriteBatch SpriteBatch { get; private set; }

    public GameLifecycle()
    {
        this.InjectorService = new InjectorService().AddAssemblies(AppDomain.CurrentDomain.GetAssemblies());

        this.Builder = new();
        this.GraphicsDeviceManager = new GraphicsDeviceManager(this);
        this.Content.RootDirectory = "Assets";
        this.IsMouseVisible = true;
        this.IsFixedTimeStep = true;

        _ = this.Builder.RegisterInstance(this.Content).As<ContentManager>().SingleInstance();
    }

    protected override void Initialize()
    {
        _ = this.Builder.RegisterInstance(this.GraphicsDevice).As<GraphicsDevice>().SingleInstance();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        this.SpriteBatch = new(this.GraphicsDevice);
        _ = this.Builder.RegisterInstance(this.SpriteBatch).As<SpriteBatch>().SingleInstance();

        base.LoadContent();
    }

    protected override void BeginRun()
    {
        this.InjectorService.ExecuteInjectors<IGameRegisterServicesInjector>(injector => injector.OnRegisterServices(this.Builder));

        this.Provider = new AutofacServiceProvider(this.Builder.Build());

        this.InjectorService.ExecuteInjectors<IGameConfigureServicesInjector>(injector => injector.OnConfigureServices(this.Provider));

        _ = this.InjectorService.SetServiceProvider(this.Provider);

        base.BeginRun();
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            this.Exit();
        }

        this.InjectorService.ExecuteInjectors<IGameInputInjector>(injector => injector.HandleInput(gameTime, Keyboard.GetState(), Mouse.GetState()));

        this.InjectorService.ExecuteInjectors<IGameUpdateInjector>(injector => injector.Update(gameTime));

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        this.GraphicsDevice.Clear(Color.CornflowerBlue);

        this.SpriteBatch.Begin();

        this.InjectorService.ExecuteInjectors<IGameDrawInjector>(injector => injector.Draw(gameTime, this.SpriteBatch));

        this.SpriteBatch.End();

        base.Draw(gameTime);
    }
}