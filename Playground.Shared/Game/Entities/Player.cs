using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Playground.Shared.Core.Interfaces;

namespace Playground.Shared.Game.Entities;

public class Player : IEntity
{
    private Texture2D _texture;
    private Vector2 _position;

    public Player(Texture2D texture, Vector2 position)
    {
        _texture = texture;
        _position = position;
    }

    public void Update(GameTime gameTime)
    {
        // Player update logic
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, Color.White);
    }
}