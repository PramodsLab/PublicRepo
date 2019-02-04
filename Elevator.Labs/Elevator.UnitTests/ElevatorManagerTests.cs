using Elevator.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace Elevator.UnitTests
{
    [TestClass]
    public class ElevatorManagerTests
    {
        [TestMethod]
        public void Serve_One_Elevator_Up_Request()
        {
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 4, Direction = Status.Up });

            Task.Run(() => ElevatorManager.StartAsync(ElevatorManager.UpDirectionQueue));

            Thread.Sleep(2000);

            Assert.IsTrue(ElevatorManager.UpDirectionQueue.IsEmpty());
        }

        [TestMethod]
        public void Do_Not_Serve_One_Elevator_Up_Request()
        {
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 4, Direction = Status.Up });

            Task.Run(() => ElevatorManager.StartAsync(ElevatorManager.DownDirectionQueue));

            Thread.Sleep(2000);

            Assert.IsFalse(ElevatorManager.UpDirectionQueue.IsEmpty());
        }

        [TestMethod]
        public void Serve_One_Elevator_Down_Request()
        {
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 4, Direction = Status.Down });

            Task.Run(() => ElevatorManager.StartAsync(ElevatorManager.DownDirectionQueue));

            Thread.Sleep(2000);

            Assert.IsTrue(ElevatorManager.DownDirectionQueue.IsEmpty());
        }

        [TestMethod]
        public void Do_Not_Serve_One_Elevator_Down_Request()
        {
            ElevatorManager.EnqueueRequest(new ElevatorRequest() { CurrentFloor = 4, Direction = Status.Down });

            Task.Run(() => ElevatorManager.StartAsync(ElevatorManager.UpDirectionQueue));

            Thread.Sleep(2000);

            Assert.IsFalse(ElevatorManager.DownDirectionQueue.IsEmpty());
        }
    }
}