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
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 4, Direction = Status.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 8, Direction = Status.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 10, Direction = Status.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 2, Direction = Status.Up });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 10, Direction = Status.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 3, Direction = Status.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 4, Direction = Status.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 8, Direction = Status.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 5, Direction = Status.Down });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 8, Direction = Status.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 9, Direction = Status.Up });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 1, Direction = Status.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 2, Direction = Status.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 3, Direction = Status.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 4, Direction = Status.Up });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 5, Direction = Status.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 6, Direction = Status.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 7, Direction = Status.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 8, Direction = Status.Up });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 9, Direction = Status.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 10, Direction = Status.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 11, Direction = Status.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 12, Direction = Status.Up });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 13, Direction = Status.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 14, Direction = Status.Up });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 8, Direction = Status.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 9, Direction = Status.Up });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 15, Direction = Status.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 14, Direction = Status.Down });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 13, Direction = Status.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 12, Direction = Status.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 11, Direction = Status.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 10, Direction = Status.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 9, Direction = Status.Down });
        }

        private static void EnqueueSecondSetRequests()
        {
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 1, Direction = Status.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = -1, Direction = Status.Up });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 18, Direction = Status.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 15, Direction = Status.Down });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 15, Direction = Status.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 16, Direction = Status.Up });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 17, Direction = Status.Up });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 18, Direction = Status.Up });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 10, Direction = Status.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 3, Direction = Status.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 4, Direction = Status.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 8, Direction = Status.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 5, Direction = Status.Down });

            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 18, Direction = Status.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 17, Direction = Status.Down });
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 16, Direction = Status.Down });
        }
    }
}