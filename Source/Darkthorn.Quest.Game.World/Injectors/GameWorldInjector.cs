using Darkthorn.Quest.Engine.Enumerations;
using Darkthorn.Quest.Engine.Game;
using Darkthorn.Quest.Game.World.Entities;
using Darkthorn.Quest.Game.World.Entities.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Darkthorn.Quest.Game.World.Injectors;

public class GameWorldInjector(WorldManager worldManager, PlayerEntityFactory playerEntityFactory) : IGameDrawInjector, IGameUpdateInjector, IGameInputInjector
{
    public string Name
        => "Game World Logic Injector";

    public string Description
        => "Injects game world logic into the game engine.";

    public Type[] Dependencies
        => [];

    public Platform Platform
        => Platform.All;

    protected WorldManager WorldManager { get; init; } = worldManager;
    protected PlayerEntityFactory PlayerEntityFactory { get; init; } = playerEntityFactory;
    protected PlayerEntity Player { get; private set; }

    public void HandleInput(GameTime gameTime, KeyboardState keyboardState, MouseState mouseState)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Space))
        {
            this.Player?.Despawn();
            this.Player = this.PlayerEntityFactory.Spawn();
        }
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        => this.WorldManager.Draw(gameTime);

    public void Update(GameTime gameTime)
        => this.WorldManager.Update(gameTime);
}