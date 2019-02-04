using Elevator.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elevator.UnitTests
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        public void MinHeap_Enqueue_Dequeue_Test()
        {
            PriorityQueue<ElevatorRequest> priorityQueue = new PriorityQueue<ElevatorRequest>();
            priorityQueue.Enqueue(new ElevatorRequest { CurrentFloor = 10, Direction = Status.Up });
            priorityQueue.Enqueue(new ElevatorRequest { CurrentFloor = 9, Direction = Status.Up });
            priorityQueue.Enqueue(new ElevatorRequest { CurrentFloor = 6, Direction = Status.Up });
            priorityQueue.Enqueue(new ElevatorRequest { CurrentFloor = 7, Direction = Status.Up });
            priorityQueue.Enqueue(new ElevatorRequest { CurrentFloor = 8, Direction = Status.Up });

            Assert.AreEqual(6, priorityQueue.Dequeue().CurrentFloor);
            Assert.AreEqual(7, priorityQueue.Dequeue().CurrentFloor);
            Assert.AreEqual(8, priorityQueue.Dequeue().CurrentFloor);
            Assert.AreEqual(9, priorityQueue.Dequeue().CurrentFloor);
            Assert.AreEqual(10, priorityQueue.Dequeue().CurrentFloor);
        }

        [TestMethod]
        public void MaxHeap_Enqueue_Dequeue_Test()
        {
            PriorityQueue<ElevatorRequest> priorityQueue = new PriorityQueue<ElevatorRequest>();
            priorityQueue.Enqueue(new ElevatorRequest { CurrentFloor = 10, Direction = Status.Down });
            priorityQueue.Enqueue(new ElevatorRequest { CurrentFloor = 9, Direction = Status.Down });
            priorityQueue.Enqueue(new ElevatorRequest { CurrentFloor = 6, Direction = Status.Down });
            priorityQueue.Enqueue(new ElevatorRequest { CurrentFloor = 7, Direction = Status.Down });
            priorityQueue.Enqueue(new ElevatorRequest { CurrentFloor = 8, Direction = Status.Down });

            Assert.AreEqual(10, priorityQueue.Dequeue().CurrentFloor);
            Assert.AreEqual(9, priorityQueue.Dequeue().CurrentFloor);
            Assert.AreEqual(8, priorityQueue.Dequeue().CurrentFloor);
            Assert.AreEqual(7, priorityQueue.Dequeue().CurrentFloor);
            Assert.AreEqual(6, priorityQueue.Dequeue().CurrentFloor);
        }
    }
}