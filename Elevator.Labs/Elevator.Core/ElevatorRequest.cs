/*
 ***********************************************************************************
 *Name      : ElevatorRequest.cs
 *Purpose   : Represents the elements in the Priority Queue. Priority Queue in Up direction represents a Min Heap.
 *            Priority queue in down direction is Max Heap. Max and Min Heap implementation switch is done by changing
 *             CompareTo method implementation
 *Author    : Pramod
 *Date      : 03/02/2019
 ***********************************************************************************
*/
using System;

namespace Elevator.Core
{
    public class ElevatorRequest : IComparable<ElevatorRequest>
    {
        /// <summary>Gets or sets the current floor.</summary>
        /// <value>The current floor.</value>
        public int CurrentFloor { get; set; }

        /// <summary>Gets or sets the direction.</summary>
        /// <value>The direction.</value>
        public Direction Direction { get; set; }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="other" /> in the sort order.  Zero This instance occurs in the same position in the sort order as <paramref name="other" />. Greater than zero This instance follows <paramref name="other" /> in the sort order.
        /// </returns>
        public int CompareTo(ElevatorRequest other)
        {
            var result = 0;
            switch (this.Direction)
            {
                case Direction.Up:
                    result = CurrentFloor.CompareTo(other.CurrentFloor);
                    break;

                case Direction.Down:
                    result = CurrentFloor.CompareTo(other.CurrentFloor) * -1;
                    break;
            }

            return result;
        }
    }
}