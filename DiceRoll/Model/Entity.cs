using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoll.Model
{
    public abstract class Entity
    {
        public Entity()
        {
            Guid = Guid.NewGuid();
        }

        public Guid Guid { get; set; }
    }
}
