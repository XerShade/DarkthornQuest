using Microsoft.Xna.Framework;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;
using System.Collections.Generic;
using ExtendedWorld = MonoGame.Extended.ECS.World;

namespace Darkthorn.Quest.Game.World;

public class WorldManager
{
    protected ExtendedWorld World { get; set; }

    public WorldManager(IEnumerable<IUpdateSystem> updateSystems, IEnumerable<IDrawSystem> drawSystems)
    {
        WorldBuilder builder = new();

        foreach(IUpdateSystem system in updateSystems)
        {
            _ = builder.AddSystem(system);
        }

        foreach(IDrawSystem system in drawSystems)
        {
            _ = builder.AddSystem(system);
        }

        this.World = builder.Build();
    }

    public void Update(GameTime gameTime)
        => this.World.Update(gameTime);

    public void Draw(GameTime gameTime)
        => this.World.Draw(gameTime);

    public Entity CreateEntity() 
        => this.World.CreateEntity();
}