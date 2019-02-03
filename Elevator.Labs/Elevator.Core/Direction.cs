namespace Elevator.Core
{
    /// <summary>Represents the direction of the elevator or elevator request.</summary>
    public enum Direction
    {
        /// <summary>Elevator in idle state</summary>
        Idle = 0,

        /// <summary>Elevator going Up or Elevator Up requested</summary>
        Up = 1,

        /// <summary>Elevator going down or Elevator down requested</summary>
        Down = 2,

        /// <summary>Elevator loading or unloading passengers</summary>
        Loading = 3
    }
}