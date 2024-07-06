using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Playground.Shared.Core.Interfaces;
using Playground.Shared.Game.Components;

namespace Playground.Shared.Game.Entities;

public class Entity : IEntity
{
    private readonly Dictionary<Type, Component> _components;

    public Entity()
    {
        _components = new Dictionary<Type, Component>();
    }

    public void AddComponent<T>(T component) where T : Component
    {
        _components[typeof(T)] = component;
    }

    public T GetComponent<T>() where T : Component
    {
        _components.TryGetValue(typeof(T), out var component);

        return (T)component;
    }

    public bool HasComponent<T>() where T : Component
    {
        return _components.ContainsKey(typeof(T));
    }

    public void RemoveComponent<T>() where T : Component
    {
        _components.Remove(typeof(T));
    }

    public void Update(GameTime gameTime)
    {
        foreach (var component in _components)
        {
            component.Value.Update(gameTime);
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Implement drawing logic for the entity here
    }
}