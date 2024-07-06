using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Playground.Shared.Core.Managers;
using Playground.Shared.Core.Utils;
using Playground.Shared.Game.Components;
using Playground.Shared.Game.Entities;
using Playground.Shared.Game.Scenes;
using Playground.Shared.Game.Systems;

namespace Playground.Shared;

public class Game1 : Microsoft.Xna.Framework.Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private SceneManager _sceneManager;
    private TransformSystem _transformSystem;
    private RenderSystem _renderSystem;
    private Texture2D _testTexture;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        
        Logger.Initialize();
        ConfigManager.Initialize();
        Logger.Log("Game constructed");
    }

    protected override void Initialize()
    {
        Logger.Log("Game initializing...");
        ApplyConfig();
        
        _sceneManager = new SceneManager();
        _sceneManager.AddScene("MainMenu", new MainMenuScene());
        _sceneManager.SetActiveScene("MainMenu");
        
        // Initialize ECS
        _transformSystem = new TransformSystem();
        
        base.Initialize();
        Logger.Log("Game initialized.");
    }

    private void ApplyConfig()
    {
        var config = ConfigManager.GetConfig();

        _graphics.PreferredBackBufferWidth = config.ScreenWidth;
        _graphics.PreferredBackBufferHeight = config.ScreenHeight;

        _graphics.IsFullScreen = config.FullScreen;
        _graphics.ApplyChanges();
    }

    private void InitializeEntities()
    {
        var entity = new Entity();
        entity.AddComponent(new TransformComponent(new Vector2(200, 250)));
        entity.AddComponent(new SpriteComponent(_testTexture));
        
        _transformSystem.AddEntity(entity);
        _renderSystem.AddEntity(entity);
    }

    protected override void LoadContent()
    {
        Logger.Log("Loading content...");
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _sceneManager.LoadContent(Content);

        _testTexture = Content.Load<Texture2D>("sprites/ball");

        _renderSystem = new RenderSystem(_spriteBatch);
        
        InitializeEntities();
        
        Logger.Log("Content loaded.");
    }

    protected override void Update(GameTime gameTime)
    {
        InputManager.Update();
        _sceneManager.Update(gameTime);
        
        // Update ECS
        _transformSystem.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _spriteBatch.Begin();
        _sceneManager.Draw(_spriteBatch);
        _renderSystem.Draw(gameTime);
        _spriteBatch.End();
        
        base.Draw(gameTime);
    }

    protected override void OnExiting(object sender, EventArgs args)
    {
        Logger.Log("Exiting game...");
        Logger.Close();
        base.OnExiting(sender, args);
    }
}