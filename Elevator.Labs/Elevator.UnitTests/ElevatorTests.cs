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
            var request = new ElevatorRequest() { CurrentFloor = 5, Direction = Direction.Up };
            var servingElevator = new Core.Elevator() { Direction = Direction.Up };
            servingElevator.EnqueueRequest(request);

            Assert.IsTrue(servingElevator.IsRequestsEmpty());
        }

        [TestMethod]
        public void Serve_Down_Request_Test()
        {
            var request = new ElevatorRequest() { CurrentFloor = 5, Direction = Direction.Down };
            var servingElevator = new Core.Elevator() { Direction = Direction.Down };
            servingElevator.EnqueueRequest(request);

            Assert.IsTrue(servingElevator.IsRequestsEmpty());
        }
    }
}