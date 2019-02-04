/*
 ***********************************************************************************
 *Name      : ElevatorManager.cs
 *Purpose   : Has 2 Global priority Queues of Up Direction Requests and Down direction requests.
 *            Primary purpose of Elevator Manager is to serve the Requests by assigning an elevator to serve the request.
 *Author    : Pramod
 *Date      : 03/02/2019
 ***********************************************************************************
*/

using Elevator.Core.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Elevator.Core
{
    /// <summary></summary>
    public static class ElevatorManager
    {
        /// <summary>The assign elevator synchronize lock</summary>
        private static readonly object AssignElevatorSyncLock = new object();

        /// <summary>The minimum floor</summary>
        public static readonly int MinFloor;

        /// <summary>The maximum floor</summary>
        public static readonly int MaxFloor;

        /// <summary>The elevator list</summary>
        public static readonly List<Elevator> ElevatorList;

        /// <summary>Global queue of all Up direction elevator request. This would be Min Heap</summary>
        public static PriorityQueue<ElevatorRequest> UpDirectionQueue;

        /// <summary>Global queue of all Up direction elevator request.This would be a Max Heap.</summary>
        public static PriorityQueue<ElevatorRequest> DownDirectionQueue;

        /// <summary>Initializes the <see cref="ElevatorManager"/> class.
        /// Initializes the List of elevators read from ElevatorConfig.xml.
        /// The min and max floor served is configurable from App Settings.
        /// </summary>
        static ElevatorManager()
        {
            //Initializes the List of elevators read from ElevatorConfig.xml.
            //The min and max floor served is configurable from App Settings.
            ElevatorList = new List<Elevator>(ConfigManager.ElevatorConfig.Elevators);
            MinFloor = Convert.ToInt32(ConfigurationManager.AppSettings["MinFloor"]);
            MaxFloor = Convert.ToInt32(ConfigurationManager.AppSettings["MaxFloor"]);

            UpDirectionQueue = new PriorityQueue<ElevatorRequest>();
            DownDirectionQueue = new PriorityQueue<ElevatorRequest>();
        }

        /// <summary>Starts the asynchronous process of assigning Elevators to the requests.</summary>
        /// <param name="queue">The queue.</param>
        /// <returns></returns>
        public static async Task StartAsync(PriorityQueue<ElevatorRequest> queue)
        {
            while (!queue.IsEmpty()) //continue till all the requests in the queue is served
            {
                // Logic to assign elevator to the requests. When the elevator is being assigned to the request; no two threads should should assign the
                // elevator to the same request; hence the piece of logic is under lock for execution by 2 threads.
                // -- Find elevators moving in the same direction as that of the request.
                // -- Out of the elevators moving in the same direction; select the elevator that is closest to the requested floor.
                // -- If no elevator found; pick an elevator which is idle and let it serve the request
                // -- If no idle elevator found pick an elevators moving in the opposite direction;
                // -- Out of the elevators moving in the opposite direction; select the elevator which would arrive the fastest to the requested floor.

                lock (AssignElevatorSyncLock)
                {
                    var request = queue.Peek();
                    Elevator servingElevator = null;
                    //Find elevators moving in the same direction as the requested direction
                    var elevatorInSameDirection = ElevatorList.Where(i => i.Direction == request.Direction && !i.CapacityReached).ToList();

                    if (elevatorInSameDirection.Any())
                    {
                        //Find elevator Closest to the requested Floor.
                        servingElevator = elevatorInSameDirection.Aggregate((x, y) =>
                            Math.Abs(x.CurrentFloor - request.CurrentFloor) < Math.Abs(y.CurrentFloor - request.CurrentFloor) ? x : y);
                    }
                    //If no elevator in same direction; pick an elevator which is idle
                    if (servingElevator == null)
                    {
                        servingElevator = ElevatorList.Where(i => i.Direction == Status.Idle).FirstOrDefault();
                    }

                    //If no elevator in same direction or no elevator which is idle; pick elevators moving in opposite direction
                    if (servingElevator == null)
                    {
                        var requestOppDirection = request.Direction == Status.Up ? Status.Down : Status.Up;
                        var elevatorInOppDirection = ElevatorList.Where(i => i.Direction == requestOppDirection && !i.CapacityReached).ToList();

                        if (elevatorInOppDirection.Any())
                        {
                            servingElevator = elevatorInOppDirection.Aggregate((x, y) =>
                                Math.Abs(x.CurrentFloor - request.CurrentFloor) > Math.Abs(y.CurrentFloor - request.CurrentFloor) ? x : y);
                        }
                    }

                    if (servingElevator != null)
                    {
                        servingElevator.Direction = servingElevator.CurrentFloor < request.CurrentFloor ? Status.Up : Status.Down;
                        servingElevator.EnqueueRequest(request); // Enqueue the request to an elevator which would serve the request.
                        queue.Dequeue();
                    }
                }

                await Task.Delay(100);
            }
        }

        /// <summary>Enqueues the request served by elavator Manager</summary>
        /// <param name="request">The request.</param>
        public static void EnqueueRequest(ElevatorRequest request)
        {
            if (request.Direction == Status.Up)
            {
                UpDirectionQueue.Enqueue(request);
            }

            if (request.Direction == Status.Down)
            {
                DownDirectionQueue.Enqueue(request);
            }
        }
    }
}