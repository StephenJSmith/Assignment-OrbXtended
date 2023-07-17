# Top Products Task
We want to see how you would structure your code to meet this simple requirement and how you would verify correct functionality. Please don’t spend any more than 2 hours on this task and feel free to add a file explaining your design decisions and any other thoughts.

Hint: get started by running `dotnet new angular`.

## In the ASP.NET Core application:
1. Load the following URL in your browser and look at the structure of the product data:
  https://web.goog.cdn.orbxdirect.com/misc/orbxproducts.json
   - Each product can support multiple simulators.
2. Create a simple database schema using EF core to hold this data.
   - Create an in-memory database provider.
   - Design an appropriate database schema with relationships.
3. Create a GET endpoint that takes a Simulator sim string as a parameter.
   - An example of a simulator name would be "fsx" or "p3dv1". The valid options are available in the product data JSON.
   - Get the products from the database and filter them to only include those belonging to the simulator requested.
   - Return to the client a response containing only the top 10 products in order of most to least expensive.

## In the Angular ClientApp:
1. Create a form with a simple text input field and submit button to request the top products for a particular simulator.
2. On submission of the form fetch the top products from the API endpoint you created.
3. Display the products in a table along with the current price.
   - Included table columns should be:
     - Product Name (Hyperlinked to the product link URL)
     - Platform
     - Current Price
     - Supported simulators
   - Clicking the table headers should sort the table by this column

Once complete, please commit and push your changes and create a pull request for review.

## To start the application
1. Server runs on port localhost:5000
   >cd API
   >dotnet run

2. Angular client runs on port localhost:4200
   >cd client
   >npm start

3. Go to browser tab 
   >localhost:4200

## Github workflow
My intention was 
- to create a TopProducts branch off the master
- commit my work to this branch
- create a Pull Request for code review prior to being able to merge to the master branch

NB ReadMe.txt file lists items not included because
   - unable to find solution to implement
   - project time constraints 
   - out of scope
