using Microsoft.Xna.Framework;
using Playground.Shared.Game.Components;
using Playground.Shared.Game.Entities;
using NotImplementedException = System.NotImplementedException;

namespace Playground.Shared.Game.Systems;

public class TransformSystem : System
{
    protected override bool IsEntityCompatible(Entity entity)
    {
        return entity.HasComponent<TransformComponent>();
    }

    public override void Update(GameTime gameTime)
    {
        foreach (var entity in Entities)
        {
            var transform = entity.GetComponent<TransformComponent>();
            
            // Example code to update the position of the transform component
            transform.Position += new Vector2(10, 1) * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}