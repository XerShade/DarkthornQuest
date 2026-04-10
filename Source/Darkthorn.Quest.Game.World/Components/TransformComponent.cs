using Microsoft.Xna.Framework;

namespace Darkthorn.Quest.Game.World.Components;

public class TransformComponent
{
    public Vector2 Position { get; set; } = Vector2.Zero;
    public Quaternion Rotation { get; set; } = Quaternion.Identity;
}