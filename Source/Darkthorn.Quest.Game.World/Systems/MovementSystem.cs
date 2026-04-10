using Darkthorn.Quest.Game.World.Components;
using Microsoft.Xna.Framework;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;

namespace Darkthorn.Quest.Game.World.Systems;

public class MovementSystem() 
    : EntityUpdateSystem(Aspect.All(typeof(VelocityComponent), typeof(TransformComponent)))
{
    protected ComponentMapper<TransformComponent> TransformMapper { get; set; }
    protected ComponentMapper<VelocityComponent> VelocityMapper { get; set; }

    public override void Initialize(IComponentMapperService mapperService)
    {
        this.TransformMapper = mapperService.GetMapper<TransformComponent>();
        this.VelocityMapper = mapperService.GetMapper<VelocityComponent>();
    }

    public override void Update(GameTime gameTime)
    {
        foreach(int entity in this.ActiveEntities)
        {
            TransformComponent transform = this.TransformMapper.Get(entity);
            VelocityComponent velocity = this.VelocityMapper.Get(entity);

            transform.Position = new Vector2(transform.Position.X + velocity.Value.X, transform.Position.Y + velocity.Value.Y);
        }
    }
}