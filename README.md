# Coding Challenge

####  Requires
- angular cli
- Node
- .NET
- MySQL

#### Description
The frontend and backend have been developed completely decoupled from each other. I favour this approach as it allows other front applications to consume also consume this RESTful API.

Development of the front-end was done using WebStorm IDE.
Development of the back-end was done using Visual Studio 2019.

Images are uploaded and stored as a static file on the server.
The back end analyses the image data before storing it into MySQL.

On the view images page, all images are sorted into the applicable formats via individual tables.
The user can click on the view button and a modal displays the image.

#### Error Handling
In angular, I have implemented http error handling to ensure the user is provided the relevant feedback.
In .NET, validation is performed on the image files.
To configure the allowed image properties, open Api\Services\Validator.cs and make any desired changes.

Current config -
Supported image formats: PNG, png, jpeg, jpg, svg and gif.
Maximum image size: 1 megabyte.

backend port: 5001
frontend port: 4200
Cors is enabled with allowed origin set to: http://localhost:4200

#### Installation  Steps

- In MySQL create a new schema called "image-tool"
- Open a query console for that newly created schema, and copy paste the content from the file "image_tool-DDL.txt"
- Open the back-end folder in Visual Studio
- In Api\Services\Database.cs configure your MySQL connection settings.
- Build and run the project. Swagger UI should now open in your browser.
- Open the front-end folder in your IDE of choice.
- Run `npm install`
- If the backend port is not 5001, set the changes to the angular environment file.
- Run `npm start`

#### Unit testing
For angular I have created 3 unit tests. 1 for a service and 2 for components.
*Would have loved more time to spend on unit testing.