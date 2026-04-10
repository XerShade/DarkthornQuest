using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Darkthorn.Quest.Client;

public class GameThread : Game
{
    protected GraphicsDeviceManager GraphicsDeviceManager { get; private set; }
    protected SpriteBatch SpriteBatch { get; private set; }

    protected Texture2D SpriteTexture { get; private set; }
    protected Vector2 SpritePosition { get; private set; } = Vector2.Zero;

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

        this.SpriteTexture = this.Content.Load<Texture2D>("Graphics/Characters/TimeFantasy/chara1");

        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if(Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            this.Exit();
        }

        if (Keyboard.GetState().IsKeyDown(Keys.W))
        {
            this.SpritePosition = new Vector2(this.SpritePosition.X, this.SpritePosition.Y - 1);
        }

        if (Keyboard.GetState().IsKeyDown(Keys.S))
        {
            this.SpritePosition = new Vector2(this.SpritePosition.X, this.SpritePosition.Y + 1);
        }

        if (Keyboard.GetState().IsKeyDown(Keys.A))
        {
            this.SpritePosition = new Vector2(this.SpritePosition.X - 1, this.SpritePosition.Y);
        }

        if (Keyboard.GetState().IsKeyDown(Keys.D))
        {
            this.SpritePosition = new Vector2(this.SpritePosition.X + 1, this.SpritePosition.Y);
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        this.GraphicsDevice.Clear(Color.CornflowerBlue);

        this.SpriteBatch.Begin();

        if(this.SpriteTexture != null)
        {
            this.SpriteBatch.Draw(this.SpriteTexture,
                new Rectangle((int)this.SpritePosition.X, (int)this.SpritePosition.Y, this.SpriteTexture.Width / 4 / 3, this.SpriteTexture.Height / 2 / 4),
                new Rectangle(this.SpriteTexture.Width / 4 / 3, 0, this.SpriteTexture.Width / 4 / 3, this.SpriteTexture.Height / 2 / 4),
                Color.White);
        }

        this.SpriteBatch.End();

        base.Draw(gameTime);
    }
}