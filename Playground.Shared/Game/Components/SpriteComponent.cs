using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Playground.Shared.Game.Components;

public class SpriteComponent : Component
{
    public Texture2D Texture { get; set; }
    public Rectangle? SourceRectangle { get; set; }
    public Color Color { get; set; }
    public Vector2 Origin { get; set; }
    public SpriteEffects SpriteEffects { get; set; }
    public float LayerDepth { get; set; }

    public SpriteComponent(Texture2D texture, Rectangle? sourceRectangle = null, Color? color = null, Vector2? origin = null, SpriteEffects spriteEffects = SpriteEffects.None, float layerDepth = 0f)
    {
        Texture = texture;
        SourceRectangle = sourceRectangle;
        Color = color ?? Color.White;
        Origin = origin ?? Vector2.Zero;
        SpriteEffects = spriteEffects;
        LayerDepth = layerDepth;
    }

    public override void Update(GameTime gameTime)
    {
        // Update sprite
    }
}