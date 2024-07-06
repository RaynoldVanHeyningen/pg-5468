using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Playground.Shared.Game.Components;
using Playground.Shared.Game.Entities;

namespace Playground.Shared.Game.Systems;

public class RenderSystem : System
{
    private readonly SpriteBatch _spriteBatch;

    public RenderSystem(SpriteBatch spriteBatch)
    {
        _spriteBatch = spriteBatch;
    }

    protected override bool IsEntityCompatible(Entity entity)
    {
        return entity.HasComponent<TransformComponent>() && entity.HasComponent<SpriteComponent>();
    }

    public void Draw(GameTime gameTime)
    {
        foreach (var entity in Entities)
        {
            var transform = entity.GetComponent<TransformComponent>();
            var sprite = entity.GetComponent<SpriteComponent>();
            
            _spriteBatch.Draw(sprite.Texture, transform.Position, sprite.SourceRectangle, sprite.Color, transform.Rotation, sprite.Origin, transform.Scale, sprite.SpriteEffects, sprite.LayerDepth);
        }
    }

    public override void Update(GameTime gameTime)
    {
        // RenderSystem does not update entities, it only draws them
    }
}