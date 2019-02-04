using Elevator.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elevator.UnitTests
{
    [TestClass]
    public class ElevatorTests
    {
        [TestMethod]
        public void Serve_Up_Request_Test()
        {
            var request = new ElevatorRequest() { CurrentFloor = 5, Direction = Status.Up };
            var servingElevator = new Core.Elevator() { Direction = Status.Up };
            servingElevator.EnqueueRequest(request);

            Assert.IsTrue(servingElevator.IsRequestsEmpty());
        }

        [TestMethod]
        public void Serve_Down_Request_Test()
        {
            var request = new ElevatorRequest() { CurrentFloor = 5, Direction = Status.Down };
            var servingElevator = new Core.Elevator() { Direction = Status.Down };
            servingElevator.EnqueueRequest(request);

            Assert.IsTrue(servingElevator.IsRequestsEmpty());
        }
    }
}