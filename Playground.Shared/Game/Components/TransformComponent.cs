using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;

namespace Playground.Shared.Game.Components;

public class TransformComponent : Component
{
    public Vector2 Position { get; set; }
    public float Rotation { get; set; }
    public Vector2 Scale { get; set; }

    public TransformComponent(Vector2 position, float rotation = 0f, Vector2? scale = null)
    {
        Position = position;
        Rotation = rotation;
        Scale = scale ?? Vector2.One;
    }

    public override void Update(GameTime gameTime)
    {
        // Update transform
    }
}