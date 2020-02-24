using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using AsteroidGame.VisualObjects;
using AsteroidGame.VisualObjects.Interfaces;

namespace AsteroidGame
{
    static class Game
    {
        /// <summary>Таймаут отрисовки одной сцены</summary>
        private const int __FrameTimeout = 10;

        public static int Width { get; set; }
        public static int Height { get; set; }

        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;
        private static Timer __Timer;

        private static List<IVisualObject> __GameObjects = new List<IVisualObject>();

        public static void Initialize(Form form)
        {
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            __Context = BufferedGraphicsManager.Current;
            __Buffer = __Context.Allocate(form.CreateGraphics(), new Rectangle(0, 0, Width, Height));
            __Timer = new Timer { Interval = __FrameTimeout };
            __Timer.Tick += OnTimerTick;

            Load();
        }

        private static void Load()
        {
            var rnd = new Random();

            const int stars_count = 150;
            const int star_size_min = 1;
            const int star_size_max = 5;
            const int star_max_speed = 20;

            for (var i = 0; i < stars_count; i++)
                __GameObjects.Add(new Star(
                    new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                    new Point(-rnd.Next(0, star_max_speed), 0),
                    rnd.Next(star_size_min, star_size_max)));
        }

        public static void Show()
        {
            Update();
            Draw();
        }

        public static bool IsPaused() => !__Timer.Enabled;

        public static void Run() => __Timer.Start();

        public static void Stop() => __Timer.Stop();

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        private static void Update()
        {
            foreach (IVisualObject gameObject in __GameObjects) gameObject?.Update();
        }

        private static void Draw()
        {
            __Buffer.Graphics.Clear(Color.Black);
            foreach (IVisualObject gameObject in __GameObjects) gameObject?.Draw(__Buffer.Graphics);
            __Buffer.Render();
        }
    }
}
