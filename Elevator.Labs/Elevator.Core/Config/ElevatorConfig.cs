using System;
using System.Collections.ObjectModel;

namespace Elevator.Core.Config
{
    [Serializable]
    public class ElevatorConfig
    {
        public Collection<Elevator> Elevators { get; set; }
    }
}