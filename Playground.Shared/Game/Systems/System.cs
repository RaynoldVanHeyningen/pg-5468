using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Playground.Shared.Game.Entities;

namespace Playground.Shared.Game.Systems;

public abstract class System
{
    protected readonly List<Entity> Entities;

    protected System()
    {
        Entities = new List<Entity>();
    }

    public void AddEntity(Entity entity)
    {
        if (IsEntityCompatible(entity))
        {
            Entities.Add(entity);
        }
    }

    public void RemoveEntity(Entity entity)
    {
        Entities.Remove(entity);
    }

    protected abstract bool IsEntityCompatible(Entity entity);
    public abstract void Update(GameTime gameTime);
}