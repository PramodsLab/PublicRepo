using Elevator.Core;
using System;
using System.Threading.Tasks;

namespace Elevator.Labs
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Elevator! All elevator is on the ground floor to start off.!");

            EnqueueFirstSetRequests();

            Task.Run(() => ElevatorManager.StartAsync(ElevatorManager.UpDirectionQueue));
            Task.Run(() => ElevatorManager.StartAsync(ElevatorManager.DownDirectionQueue));

            EnqueueSecondSetRequests();

            Console.ReadLine();
        }

        private static void EnqueueFirstSetRequests()
        {
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 4, Direction = Direction.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 8, Direction = Direction.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 10, Direction = Direction.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 2, Direction = Direction.Up });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 10, Direction = Direction.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 3, Direction = Direction.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 4, Direction = Direction.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 8, Direction = Direction.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 5, Direction = Direction.Down });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 8, Direction = Direction.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 9, Direction = Direction.Up });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 1, Direction = Direction.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 2, Direction = Direction.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 3, Direction = Direction.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 4, Direction = Direction.Up });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 5, Direction = Direction.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 6, Direction = Direction.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 7, Direction = Direction.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 8, Direction = Direction.Up });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 9, Direction = Direction.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 10, Direction = Direction.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 11, Direction = Direction.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 12, Direction = Direction.Up });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 13, Direction = Direction.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 14, Direction = Direction.Up });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 8, Direction = Direction.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 9, Direction = Direction.Up });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 15, Direction = Direction.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 14, Direction = Direction.Down });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 13, Direction = Direction.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 12, Direction = Direction.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 11, Direction = Direction.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 10, Direction = Direction.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 9, Direction = Direction.Down });
        }

        private static void EnqueueSecondSetRequests()
        {
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 1, Direction = Direction.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = -1, Direction = Direction.Up });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 18, Direction = Direction.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 15, Direction = Direction.Down });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 15, Direction = Direction.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 16, Direction = Direction.Up });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 17, Direction = Direction.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 18, Direction = Direction.Up });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 10, Direction = Direction.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 3, Direction = Direction.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 4, Direction = Direction.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 8, Direction = Direction.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 5, Direction = Direction.Down });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 18, Direction = Direction.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 17, Direction = Direction.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 16, Direction = Direction.Down });
        }
    }
}