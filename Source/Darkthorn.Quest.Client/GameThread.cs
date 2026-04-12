using Autofac;
using Autofac.Extensions.DependencyInjection;
using Darkthorn.Quest.Game.World;
using Darkthorn.Quest.Game.World.Entities;
using Darkthorn.Quest.Game.World.Entities.Factories;
using Darkthorn.Quest.Game.World.Systems;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using GameBase = Microsoft.Xna.Framework.Game;

namespace Darkthorn.Quest.Client;

public class GameThread : GameBase
{
    protected ContainerBuilder Builder { get; private set; }
    protected IServiceProvider Provider { get; private set; }

    protected GraphicsDeviceManager GraphicsDeviceManager { get; private set; }
    protected SpriteBatch SpriteBatch { get; private set; }

    protected WorldManager WorldManager { get; private set; }
    protected PlayerEntity Player { get; private set; }

    public GameThread()
    {
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
        _ = this.Builder.RegisterType<WorldManager>().As<WorldManager>().SingleInstance();
        _ = this.Builder.RegisterType<PlayerEntityFactory>().As<PlayerEntityFactory>().InstancePerDependency();
        _ = this.Builder.RegisterType<MovementSystem>().AsImplementedInterfaces().InstancePerDependency();
        _ = this.Builder.RegisterType<InputSystem>().AsImplementedInterfaces().InstancePerDependency();
        _ = this.Builder.RegisterType<RenderSystem>().AsImplementedInterfaces().InstancePerDependency();

        this.Provider = new AutofacServiceProvider(this.Builder.Build());

        this.WorldManager = this.Provider.GetRequiredService<WorldManager>();
        this.Player = this.Provider.GetRequiredService<PlayerEntityFactory>().Spawn();

        base.BeginRun();
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            this.Exit();
        }

        if (Keyboard.GetState().IsKeyDown(Keys.Space))
        {
            this.Player.Despawn();
            this.Player = this.Provider.GetRequiredService<PlayerEntityFactory>().Spawn();
        }

        this.WorldManager.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        this.GraphicsDevice.Clear(Color.CornflowerBlue);

        this.SpriteBatch.Begin();

        this.WorldManager.Draw(gameTime);

        this.SpriteBatch.End();

        base.Draw(gameTime);
    }
}