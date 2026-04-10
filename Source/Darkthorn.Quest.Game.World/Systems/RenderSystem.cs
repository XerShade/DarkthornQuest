using Darkthorn.Quest.Game.World.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;

namespace Darkthorn.Quest.Game.World.Systems;

public class RenderSystem(SpriteBatch spriteBatch) 
    : EntityDrawSystem(Aspect.All(typeof(TransformComponent), typeof(Texture2D)))
{
    protected ComponentMapper<TransformComponent> TransformMapper { get; private set; }
    protected ComponentMapper<Texture2D> TextureMapper { get; private set; }
    protected SpriteBatch SpriteBatch { get; private set; } = spriteBatch;

    public override void Initialize(IComponentMapperService mapperService)
    {
        this.TransformMapper = mapperService.GetMapper<TransformComponent>();
        this.TextureMapper = mapperService.GetMapper<Texture2D>();
    }

    public override void Draw(GameTime gameTime)
    {
        foreach (int entity in this.ActiveEntities)
        {
            TransformComponent transform = this.TransformMapper.Get(entity);
            Texture2D texture = this.TextureMapper.Get(entity);
            Rectangle texture_size = new(0, 0, texture.Width / 4 / 3, texture.Height / 2 / 4);

            this.SpriteBatch.Draw(texture, 
                new Rectangle((int)transform.Position.X, (int)transform.Position.Y, texture_size.Width, texture_size.Height),
                new Rectangle(texture_size.Width, 0, texture_size.Width, texture_size.Height), Color.White);
        }
    }
}