using Darkthorn.Quest.Game.World.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;

namespace Darkthorn.Quest.Game.World.Systems;

public class InputSystem() 
    : EntityUpdateSystem(Aspect.All(typeof(VelocityComponent)))
{
    protected ComponentMapper<VelocityComponent> VelocityMapper;

    public override void Initialize(IComponentMapperService mapperService) 
        => this.VelocityMapper = mapperService.GetMapper<VelocityComponent>();

    public override void Update(GameTime gameTime)
    {
        KeyboardState keyboardState = Keyboard.GetState();

        foreach(int entity in this.ActiveEntities)
        {
            VelocityComponent transform = this.VelocityMapper.Get(entity);

            int x = 0;
            int y = 0;

            if (keyboardState.IsKeyDown(Keys.W))
            {
                y--;
            }

            if (keyboardState.IsKeyDown(Keys.S))
            {
                y++;
            }

            if (keyboardState.IsKeyDown(Keys.A))
            {
                x--;
            }

            if (keyboardState.IsKeyDown(Keys.D))
            {
                x++;
            }

            transform.Value = new Vector2(x * 2, y * 2);
            transform.Value.Normalize();
        }
    }
}