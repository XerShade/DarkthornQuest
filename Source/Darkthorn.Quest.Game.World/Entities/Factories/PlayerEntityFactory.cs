using Microsoft.Xna.Framework.Content;

namespace Darkthorn.Quest.Game.World.Entities.Factories;

public class PlayerEntityFactory(ContentManager contentManager, WorldManager worldManager)
{
    protected ContentManager ContentManager { get; init; } = contentManager;
    protected WorldManager WorldManager { get; init; } = worldManager;

    public PlayerEntity Spawn()
        => new(this.WorldManager.CreateEntity(), this.ContentManager);
}