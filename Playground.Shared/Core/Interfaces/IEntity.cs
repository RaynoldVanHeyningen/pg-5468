using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Playground.Shared.Core.Interfaces;

public interface IEntity
{
    void Update(GameTime gameTime);
    void Draw(SpriteBatch spriteBatch);
}