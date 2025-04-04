using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework2DGame.Base;

namespace Framework2DGame
{
    public class World(ReadConfig config)
    {
        
        public int MaxX = config.maxX;
        public int MaxY = config.maxY;
        public string Level = config.level;

        public List<Creature> creatures = new List<Creature>();
        public List<WorldObject> objects = new List<WorldObject>();


    }
}
