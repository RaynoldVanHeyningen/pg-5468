using Microsoft.Xna.Framework.Input;

namespace Playground.Shared.Core.Managers;

public static class InputManager
{
    private static KeyboardState _currentKeyState;
    private static KeyboardState _previousKeyState;

    public static void Update()
    {
        _previousKeyState = _currentKeyState;
        _currentKeyState = Keyboard.GetState();
    }

    public static bool IsKeyPressed(Keys key)
    {
        return _currentKeyState.IsKeyDown(key) && !_previousKeyState.IsKeyDown(key);
    }

    public static bool IsKeyReleased(Keys key)
    {
        return !_currentKeyState.IsKeyDown(key) && _previousKeyState.IsKeyDown(key);
    }

    public static bool IsKeyHeld(Keys key)
    {
        return _currentKeyState.IsKeyDown(key);
    }
}