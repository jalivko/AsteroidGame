﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame.VisualObjects.Interfaces
{
    internal interface ICollision: IGameObject
    {
        Rectangle Rect { get; }

        void Collision(ICollision obj);
    }
}
