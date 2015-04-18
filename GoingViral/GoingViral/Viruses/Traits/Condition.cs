using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingViral
{
    public class Condition
    {
        public Condition()
        {
        }
        /// <summary>
        /// The name of this condition
        /// </summary>
        public string Name;
        /// <summary>
        /// The amount that this condition will increase infectiousness
        /// by. This is a multiplier.
        /// </summary>
        public double InfectiousnessMultiplier;
        /// <summary>
        /// The amount that this condition will affect how long hosts can
        /// survive with this virus. This is a multiplier.
        /// </summary>
        public double SurvivabilityMultiplier;
        /// <summary>
        /// The amount that this condition will affect how visible the virus
        /// is. This is a multiplier
        /// </summary>
        public double VisibilityMultiplier;
    }
}
