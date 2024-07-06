using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Playground.Shared.Core.Interfaces;

namespace Playground.Shared.Game.Scenes;

public class MainMenuScene : IScene
{
    private Texture2D _testTexture;
    private Vector2 _testTexturePosition = new(100, 100);

    public void Initialize()
    {
        //
    }

    public void LoadContent(ContentManager content)
    {
        // _testTexture = content.Load<Texture2D>("sprites/ball");
    }
    
    public void Update(GameTime gameTime)
    {
        // Update logic for main menu
        
        // Example move texture with arrow keys
        // if (InputManager.IsKeyHeld(Keys.Right)) _testTexturePosition.X += 10;
        // if (InputManager.IsKeyHeld(Keys.Left)) _testTexturePosition.X -= 10;
        // if (InputManager.IsKeyHeld(Keys.Up)) _testTexturePosition.Y -= 10;
        // if (InputManager.IsKeyHeld(Keys.Down)) _testTexturePosition.Y += 10;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Draw logic for main menu
        // spriteBatch.Draw(_testTexture, _testTexturePosition, Color.White);
    }
}