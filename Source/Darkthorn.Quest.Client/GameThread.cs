using Darkthorn.Quest.Game.World;
using Darkthorn.Quest.Game.World.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameBase = Microsoft.Xna.Framework.Game;

namespace Darkthorn.Quest.Client;

public class GameThread : GameBase
{
    protected GraphicsDeviceManager GraphicsDeviceManager { get; private set; }
    protected SpriteBatch SpriteBatch { get; private set; }

    protected WorldManager WorldManager { get; private set; }
    protected PlayerEntity Player { get; private set; }

    public GameThread()
    {
        this.GraphicsDeviceManager = new GraphicsDeviceManager(this);
        this.Content.RootDirectory = "Assets";
        this.IsMouseVisible = true;
        this.IsFixedTimeStep = true;
    }

    protected override void LoadContent()
    {
        this.SpriteBatch = new(this.GraphicsDevice);

        this.WorldManager = new(this.Content, this.SpriteBatch);
        this.Player = this.WorldManager.SpawnPlayer();

        base.LoadContent();
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
            this.Player = this.WorldManager.SpawnPlayer();
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