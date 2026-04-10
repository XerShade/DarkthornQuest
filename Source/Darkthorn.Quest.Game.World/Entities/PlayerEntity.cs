using Darkthorn.Quest.Game.World.Components;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.ECS;

namespace Darkthorn.Quest.Game.World.Entities;

public class PlayerEntity
{
    protected Entity Entity { get; set; }

    public TransformComponent Transform => this.Entity.Get<TransformComponent>();
    public VelocityComponent Velocity => this.Entity.Get<VelocityComponent>();

    public PlayerEntity(Entity entity, ContentManager contentManager)
    {
        this.Entity = entity;

        this.Entity.Attach<TransformComponent>(new TransformComponent());
        this.Entity.Attach<VelocityComponent>(new VelocityComponent());
        this.Entity.Attach<Texture2D>(contentManager.Load<Texture2D>("Graphics/Characters/TimeFantasy/chara1"));
    }

    public void Despawn() 
        => this.Entity.Destroy();
}