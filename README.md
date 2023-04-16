# Password Generator API

This project provides a simple API for generating random passwords based on user-defined criteria, such as length and character types (upper case, numbers, and symbols).

## Features

* Generate random passwords with a user-defined length
* Include or exclude upper case characters, numbers, and symbols in the generated passwords
* RESTful API for easy integration into other applications
* Swagger UI for easy API documentation and testing

# Getting Started

## Prerequisites

    .NET SDK (5.0 or later)

## Installing

  Clone the repository:

    git clone https://github.com/GMoreyra/PasswordGenerator.git

  Navigate to the project folder:

    cd PasswordGenerator

  Restore the NuGet packages:

    dotnet restore

  Build the solution:

    dotnet build

#  Running the API

  Navigate to the PasswordGenerator folder:

    cd PasswordGenerator

  Run the API:

    dotnet run

  Open a web browser and navigate to https://localhost:5001/swagger to access the Swagger UI and test the API.

## Usage

Generate a random password

Make a GET request to the /api/passwordgenerator endpoint with the following query parameters:

* `length` (int, required): The length of the generated password
* `upperCase` (bool, required): Include upper case characters in the generated password
* `numbers` (bool, required): Include numbers in the generated password
* `symbols` (bool, required): Include symbols in the generated password

Example request:

    GET /api/passwordgenerator?length=12&upperCase=true&numbers=true&symbols=false

Example response:

    json

    {
      "password": "gH3kP8qC0sT1"
    }

## Running the tests

To run the unit tests for this project, navigate to the PasswordGenerator.Tests folder and execute the following command:

    dotnet test

## License

This project is licensed under the MIT License.
