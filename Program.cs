using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Demo
{
    public class Program
    {
        static void Main(string[] _)
       {
            // Create a settings object for the window, this is where we can configure
            // our window before we create it.
            ContextSettings settings = new ContextSettings();
            settings.AntialiasingLevel = 8;

            // Create our window, we are setting a fixed window size & wont support resize
            RenderWindow window = new RenderWindow(
               new VideoMode(1280, 720),
               "Game",
               Styles.Default,
               settings);

            // When the window's 'X' button is clicked to close it, the window.Closed event will
            // start, the += notation is a way of telling C# to call the method 'OnWindowClose'
            // is the X button is ever pressed.
            window.Closed += OnWindowClose;

            // Create the rectangle that we are going to draw on the screen.
            Vector2f rectangleSize = new Vector2f(200, 200);
            RectangleShape rectangle = new RectangleShape(rectangleSize);
            rectangle.Position = new Vector2f(100, 100);
            rectangle.OutlineThickness = 2;
            rectangle.OutlineColor = Color.Black;

            Texture texture = new Texture("Resources/Image.png");
            rectangle.Texture = texture;

            // Create a timer
            Clock timer = new Clock();

            while (window.IsOpen)
            {
                // Calculate how many miliseconds have passed since the last frame
                float frameTime = timer.Restart().AsSeconds();

                // Let the window class perform all of its update logic,
                // this includes things like checking if the minimize / close buttons have been pressed.
                window.DispatchEvents();

                // As we draw frames on top of the frame before, the first thing we need to do
                // is to clear the whole screen a new blank colour.
                //window.Clear(Color.Blue);

                // If the D key is pressed...
                if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                {
                    // We want to move the rectangle 200 pixels per second to the right.
                    rectangle.Position = rectangle.Position + new Vector2f(200 * frameTime, 0);
                }

                // If the s key is pressed...
                if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                {
                    // We want to move the rectangle 200 pixels per second to the right.
                    rectangle.Position = rectangle.Position - new Vector2f(200 * frameTime, 0);
                }

                // If the s key is pressed...
                if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                {
                    // We want to move the rectangle 200 pixels per second to the right.
                    rectangle.Position = rectangle.Position + new Vector2f(0, 200 * frameTime);
                }

                // If the s key is pressed...
                if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                {
                    // We want to move the rectangle 200 pixels per second to the right.
                    rectangle.Position = rectangle.Position - new Vector2f(0, 200 * frameTime);
                }

                // The screen has been cleared, whatever we want to draw, we can do so now, 
                // Note: things draw on top of one another so order matters
                // Note: we are drawing to a buffer, it wont get shown on the screen until we call
                // 'Display()'
                window.Draw(rectangle);

                // Copy the buffer to the window
                window.Display();
            }
        }

        private static void OnWindowClose(object sender, EventArgs e)
        {
            // Cast the sender to a RenderWindow, and call its close method.
            ((RenderWindow)sender).Close();
        }
    }
}