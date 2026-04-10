using Darkthorn.Quest.Game.World.Entities;
using Darkthorn.Quest.Game.World.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.ECS;
using ExtendedWorld = MonoGame.Extended.ECS.World;

namespace Darkthorn.Quest.Game.World;

public class WorldManager
{
    protected ContentManager ContentManager { get; set; }
    protected SpriteBatch SpriteBatch { get; set; }
    protected ExtendedWorld World { get; set; }

    public WorldManager(ContentManager contentManager, SpriteBatch spriteBatch)
    {
        WorldBuilder builder = new WorldBuilder()
            .AddSystem(new InputSystem())
            .AddSystem(new MovementSystem())
            .AddSystem(new RenderSystem(spriteBatch));

        this.World = builder.Build();
        this.ContentManager = contentManager;
        this.SpriteBatch = spriteBatch;
    }

    public void Update(GameTime gameTime)
        => this.World.Update(gameTime);

    public void Draw(GameTime gameTime)
        => this.World.Draw(gameTime);

    public PlayerEntity SpawnPlayer() 
        => new(this.World.CreateEntity(), this.ContentManager);
}