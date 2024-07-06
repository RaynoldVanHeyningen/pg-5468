using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Playground.Shared.Core.Interfaces;

namespace Playground.Shared.Core.Managers;

public class SceneManager
{
    private Dictionary<string, IScene> _scenes = new();
    private IScene _currentScene;

    public void AddScene(string name, IScene scene)
    {
        _scenes[name] = scene;
    }

    public void SetActiveScene(string name)
    {
        if (_scenes.ContainsKey(name))
        {
            _currentScene = _scenes[name];
            _currentScene.Initialize();
        }
    }

    public void LoadContent(ContentManager content)
    {
        _currentScene?.LoadContent(content);
    }

    public void Update(GameTime gameTime)
    {
        _currentScene?.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _currentScene?.Draw(spriteBatch);
    }
}