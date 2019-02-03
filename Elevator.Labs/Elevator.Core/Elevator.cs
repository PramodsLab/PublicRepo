/*
 ***********************************************************************************
 *Name      : Elevator.cs
 *Purpose   : Elevator Manager would assign the request to each elevator which would serve the requests.
 *            Each elevator also maintains a list of Destination floors; which each passenger can input after entering the elevator
 *            The requested and destination floors are served by stopping on the floor.
 *Author    : Pramod
 *Date      : 03/02/2019
 ***********************************************************************************
*/

using System;
using System.Collections.Generic;

namespace Elevator.Core
{
    [Serializable]
    public class Elevator
    {
        private List<int> _destinationFloorList;

        private PriorityQueue<ElevatorRequest> _requests;

        /// <summary>Gets or sets the name of the Elevator</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        public string Make { get; set; }

        /// <summary>Gets or sets the fore ground color of the console for the elevator.</summary>
        /// <value>The foreground color of the console for the elevator.</value>
        public int ConsoleForeColor { get; set; }

        /// <summary>Gets or sets the direction of the elevator</summary>
        /// <value>The direction of the elevator.</value>
        public Direction Direction { get; set; }

        /// <summary>Gets or sets the current floor; where the elevator currently is.</summary>
        /// <value>The current floor.</value>
        public int CurrentFloor { get; set; }

        /// <summary>Gets or sets a value indicating whether elevators capacity has reached.</summary>
        /// <value>
        ///   <c>true</c> if [capacity reached]; otherwise, <c>false</c>.</value>
        public bool CapacityReached { get; set; }

        /// <summary>Lets the Elevator Manager; Enqueues the request to the elevator.</summary>
        /// <param name="request">Elevator request.</param>
        public void EnqueueRequest(ElevatorRequest request)
        {
            if (_requests == null)
            {
                _requests = new PriorityQueue<ElevatorRequest>();
            }
            Console.ForegroundColor = (ConsoleColor)this.ConsoleForeColor;
            _requests.Enqueue(request);
            Operate();
        }

        private void Operate()
        {
            while (!_requests.IsEmpty()) // Continue till all the requests assigned to the elevator is complete
            {
                var req = _requests.Peek();

                while (this.CurrentFloor != req.CurrentFloor) // move up or down till the elevator reaches the requested floor
                {
                    switch (this.Direction)
                    {
                        case Direction.Up:
                            if (this.CurrentFloor == ElevatorManager.MaxFloor) // change direction after reaching max floor
                            {
                                MoveDown();
                                this.Direction = Direction.Down;
                            }
                            else
                            {
                                MoveUp();
                            }

                            break;

                        case Direction.Down:
                            if (CurrentFloor == ElevatorManager.MinFloor) // change direction after reaching in floor.
                            {
                                MoveUp();
                                this.Direction = Direction.Up;
                            }
                            else
                            {
                                MoveDown();
                            }
                            break;
                    }
                }

                var request = _requests.Dequeue();
                Console.WriteLine($"{this.Name} serving request at Floor {request.CurrentFloor} moving {this.Direction.ToString()}");
                OpenDoor();

                var d = this.Direction; // temp direction to hold the elevators current direction
                this.Direction = Direction.Loading;
                CloseDoor();

                this.Direction = d; // assign the initial direction after loading or unloading the passengers
            }
        }

        /// <summary>Lets passengers enter the destination floor; which would be served by the elevator</summary>
        /// <param name="floor">Destination floor number.</param>
        public void AddDestinationFloor(int floor)
        {
            if (_destinationFloorList == null)
            {
                _destinationFloorList = new List<int>();
            }

            _destinationFloorList.Add(floor);
        }

        /// <summary>Determines whether [is requests empty].</summary>
        /// <returns>
        ///   <c>true</c> if [is requests empty]; otherwise, <c>false</c>.</returns>
        public bool IsRequestsEmpty()
        {
            return _requests == null || _requests.IsEmpty();
        }

        private void MoveUp()
        {
            //Serve destination floor when moving up or down
            ServeDestinationFloor();
            Console.WriteLine($"{Name} is going { this.Direction.ToString()} and crossing {this.CurrentFloor} Floor");
            this.CurrentFloor += 1;
        }

        private void MoveDown()
        {
            //Serve destination floor when moving up or down
            ServeDestinationFloor();
            Console.WriteLine($"{Name} is going { this.Direction.ToString()} and crossing {this.CurrentFloor} Floor");
            this.CurrentFloor -= 1;
        }

        private void ServeDestinationFloor()
        {
            if (_destinationFloorList != null && _destinationFloorList.Contains(this.CurrentFloor))
            {
                OpenDoor();
                _destinationFloorList.Remove(this.CurrentFloor);
                CloseDoor();
            }
        }

        private void OpenDoor()
        {
        }

        private void CloseDoor()
        {
        }
    }
}