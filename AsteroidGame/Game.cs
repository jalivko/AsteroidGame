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
        private const int __FrameTimeout = 15;
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static SpaceShip Player { get; private set; }

        public static bool IsPaused { get; set; } = true;

        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;
        private static Timer __Timer;

        private static List<IGameObject> __RemovedGameObjects = new List<IGameObject>();
        private static List<IGameObject> __AddedGameObjects = new List<IGameObject>();
        private static List<IGameObject> __GameObjects = new List<IGameObject>();
        private static List<IVisualObject> __VisualGameObjects = new List<IVisualObject>();
        private static List<ICollision> __CollisionGameObjects = new List<ICollision>();

        public static void Initialize(Form form)
        {
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            __Context = BufferedGraphicsManager.Current;
            __Buffer = __Context.Allocate(form.CreateGraphics(), new Rectangle(0, 0, Width, Height));
            __Timer = new Timer { Interval = __FrameTimeout };
            __Timer.Tick += OnTimerTick;

            LoadObjects();
        }

        public static T RegisterGameObject<T>(T GameObject) where T : IGameObject
        {
            if (!__AddedGameObjects.Contains(GameObject)) __AddedGameObjects.Add(GameObject);
            return GameObject;
        }
        public static void UnregisterGameObject(IGameObject GameObject)
        {
            if (!__RemovedGameObjects.Contains(GameObject))
                __RemovedGameObjects.Add(GameObject);
        }

        public static void Run() => __Timer.Start();

        public static void Restart()
        {
            ClearObjects();
            LoadObjects();
        }

        private static void LoadObjects()
        {
            // Создаёс космос
            var stars_count = 150;
            var space = new Space(stars_count);
            RegisterGameObject(space);

            // Создаём оружие
            var weapon = new Weapon();
            RegisterGameObject(weapon);

            // Создаём игрока
            var ship_position = new Point(10, Height / 2);
            var ship_size = new Size(100, 60);
            Player = new SpaceShip(ship_position, ship_size, weapon);
            RegisterGameObject(Player);

            // Создаём респаун астероидов
            var respawn_place = new Rectangle(Width, 50, 10, Height - 100);
            var asteroids_speed = new Point(-7, 0);
            var span_timeout = 40;
            var asteroids_respawn = new AsteroidsRespawn(respawn_place, asteroids_speed, span_timeout);
            RegisterGameObject(asteroids_respawn);

            // Создаём датчики здоровья и очков
            var player_stats = new PlayerStats(Player);
            RegisterGameObject(player_stats);
        }

        private static void ClearObjects()
        {
            foreach (var game_object in __GameObjects) UnregisterGameObject(game_object);
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            if (!IsPaused) Update();
            RemoveUnregisteredGameObjects();
            AddRegisteredGameObjects();
            Draw();
        }

        private static void AddRegisteredGameObjects()
        {
            foreach (var game_object in __AddedGameObjects)
            {
                if (!__GameObjects.Contains(game_object))
                    __GameObjects.Add(game_object);
                if (game_object is IVisualObject visual_object && !__VisualGameObjects.Contains(visual_object))
                    __VisualGameObjects.Add(visual_object);
                if (game_object is ICollision collision_object && !__CollisionGameObjects.Contains(collision_object))
                    __CollisionGameObjects.Add(collision_object);
            }
            __AddedGameObjects.Clear();
        }

        private static void RemoveUnregisteredGameObjects()
        {
            foreach (var game_object in __RemovedGameObjects)
            {
                __GameObjects.Remove(game_object);
                if (game_object is IVisualObject visual_object)
                    __VisualGameObjects.Remove(visual_object);
                if (game_object is ICollision collision_object)
                    __CollisionGameObjects.Remove(collision_object);
            }
            __RemovedGameObjects.Clear();
        }

        private static void Update()
        {
            foreach (IGameObject gameObject in __GameObjects) gameObject?.Update();

            for (var i = 0; i < __CollisionGameObjects.Count; i++)
                for (var j = i + 1; j < __CollisionGameObjects.Count; j++)
                {
                    if (CheckCollision(__CollisionGameObjects[i], __CollisionGameObjects[j]))
                    {
                        __CollisionGameObjects[i].Collision(__CollisionGameObjects[j]);
                        __CollisionGameObjects[j].Collision(__CollisionGameObjects[i]);
                    }
                }
        }

        private static bool CheckCollision(ICollision Left, ICollision Right)
        {
            var rect_left = Left.Rect;
            var rect_right = Right.Rect;
            return rect_left != null && rect_right != null && rect_left.IntersectsWith(rect_right);
        }

        private static void Draw()
        {
            __Buffer.Graphics.Clear(Color.Black);
            foreach (IVisualObject gameObject in __VisualGameObjects) gameObject?.Draw(__Buffer.Graphics);
            __Buffer.Render();
        }
    }
}
