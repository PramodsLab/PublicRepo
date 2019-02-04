Elevator System Design.

There are 2 main components in Elevator Design
1) Elevator Manager 
2) Elevator

Elevator Manager
-------------------
Any elevator up or down requested by the user would be pushed to a Global Priority Queue.
Elevator Manager would me managing this queue. There would be 2 queues managing one in up and another in down direction.

Elevator Manager would assign the request to the appropriate elevator; taking in to account the below criteria.

1) Elevator which is moving in the same direction and yet to cross the requested floor.
2) Elevator which is idle.
3) Elevator moving in opposite direction; and would arrive at the requested floor the fastest.

Assigning the request to Elevator is done under syncronization lock; so that same request is not assigned to 2 elevator.


Elevator
------------------
Elevator configuration is maintained in /Config/ElevatorConfig.xml. Additionl elevators can be added to ElevatorConfig.xml.
After the Elevator Manager assigns the request to Elevator; its the Elevators responsibility to serve the request.
Once the passenger enters the elevator; passeneger enters the destination floor; in any direction. 
This is maintained by the elevator as a List of desitination floor. 
Whenever the elevator crosses the floor included in the destination floor; the elevator need to stop.
