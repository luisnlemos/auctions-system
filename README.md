AuctionsApp
I decided to implement a solution without a database or front-end, due to time management considerations, focusing instead on meeting the requirements and delivering a well-structured, scalable system. 
I opted for the use of the Factory pattern to build the Car model (superclass) and Car types – Sedan, Truck, Hatchback, and SUV – (subclasses). 
This choice was made because of the distinct properties between the four types of cars, allowing the system to be prepared to handle new car types in the future. 
This modularity also ensures that car types can be extended with new attributes without impacting the existing classes, thus improving maintainability.
As mentioned, since I didn’t implement database persistence, I created in-memory inventories for cars and auctions, leveraging these objects for unit testing. 
In the setup for the integration tests in the CarManagementSystemTests/CMSTests.cs class, which cover the listed requirements, I chose to populate the car and auction inventories to create a shared Arrange phase across all tests. 
This simplifies the Arrange phase for each individual test.
Regarding the search requirement, due to the use of “or” in the prompt – “Search for vehicles by type, manufacturer, model, or year” – I assumed that the search criteria would be based on one field at a time. 
Therefore, the search method receives a single property and its value as parameters.
