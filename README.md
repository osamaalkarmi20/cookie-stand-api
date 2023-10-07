# CookieStand API Documentation

This is the documentation for the CookieStand API, which provides endpoints for managing cookie stands and their hourly sales data.


## Introduction

The CookieStand API is a web service for managing information about cookie stands. It allows you to create, retrieve, update, and delete cookie stands. Additionally, it provides information about hourly sales for each cookie stand.

## API Endpoints

### Create a Cookie Stand

- **Endpoint**: `POST /CookieStand`
- **Description**: Create a new cookie stand with the provided details.
- **Request Body**: CREATCookieStandDTO
- **Response**: Returns the created CookieStand object.
- **Example Request**:
  ```json
  {
    "Location": "New York",
    "Description": "A new cookie stand in the heart of the city",
    "MinimumCustomersPerHour": 10,
    "MaximumCustomersPerHour": 50,
    "AverageCookiesPerSale": 5.5,
    "Owner": "John Doe"
  }
  ```
- **Example Response**:
  ```json
  {
    "Id": 1,
    "Location": "New York",
    "Description": "A new cookie stand in the heart of the city",
    "MinimumCustomersPerHour": 10,
    "MaximumCustomersPerHour": 50,
    "AverageCookiesPerSale": 5.5,
    "Owner": "John Doe"
  }
  ```

### Get All Cookie Stands

- **Endpoint**: `GET /CookieStand`
- **Description**: Retrieve a list of all cookie stands with their hourly sales data.
- **Response**: Returns a list of CookieStandDTO objects.
- **Example Response**:
  ```json
  [
    {
      "Id": 1,
      "Location": "New York",
      "Description": "A new cookie stand in the heart of the city",
      "MinimumCustomersPerHour": 10,
      "MaximumCustomersPerHour": 50,
      "AverageCookiesPerSale": 5.5,
      "Owner": "John Doe",
      "hourlySales": [25, 30, 20, 45, 35, 40, 50, 60, 70, 55, 45, 30]
    },
    {
      "Id": 2,
      "Location": "Los Angeles",
      "Description": "Cookie stand on the beach",
      "MinimumCustomersPerHour": 15,
      "MaximumCustomersPerHour": 60,
      "AverageCookiesPerSale": 6.0,
      "Owner": "Jane Smith",
      "hourlySales": [35, 40, 25, 55, 45, 50, 65, 75, 85, 70, 60, 40]
    }
  ]
  ```

### Get a Cookie Stand by ID

- **Endpoint**: `GET /CookieStand/{id}`
- **Description**: Retrieve a specific cookie stand by its ID with its hourly sales data.
- **Response**: Returns a CookieStandDTO object.
- **Example Response**:
  ```json
  {
    "Id": 1,
    "Location": "New York",
    "Description": "A new cookie stand in the heart of the city",
    "MinimumCustomersPerHour": 10,
    "MaximumCustomersPerHour": 50,
    "AverageCookiesPerSale": 5.5,
    "Owner": "John Doe",
    "hourlySales": [25, 30, 20, 45, 35, 40, 50, 60, 70, 55, 45, 30]
  }
  ```

### Delete a Cookie Stand

- **Endpoint**: `DELETE /CookieStand/{id}`
- **Description**: Delete a specific cookie stand by its ID.
- **Response**: No content.
- **Example Response**: 204 No Content

### Update a Cookie Stand

- **Endpoint**: `PUT /CookieStand/{id}`
- **Description**: Update a specific cookie stand by its ID with the provided details.
- **Request Body**: CREATCookieStandDTO
- **Response**: Returns the updated CookieStandDTO object.
- **Example Request**:
  ```json
  {
    "Location": "Updated Location",
    "Description": "Updated Description",
    "MinimumCustomersPerHour": 20,
    "MaximumCustomersPerHour": 70,
    "AverageCookiesPerSale": 6.5,
    "Owner": "Updated Owner"
  }
  ```
- **Example Response**:
  ```json
  {
    "Id": 1,
    "Location": "Updated Location",
    "Description": "Updated Description",
    "MinimumCustomersPerHour": 20,
    "MaximumCustomersPerHour": 70,
    "AverageCookiesPerSale": 6.5,
    "Owner": "Updated Owner",
    "hourlySales": [30, 35, 25, 55, 45, 50, 70, 80, 90, 75, 65, 40]
  }
  ```

## Data Models

### CookieStand

- **Description**: Represents a cookie stand with hourly sales data.
- **Properties**:
  - `Id` (int): The unique identifier for the cookie stand.
  - `Location` (string): The location of the cookie stand.
  - `Description` (string): A description of the cookie stand.
  - `hourlySales` (List of int): Hourly sales data for the cookie stand.
  - `MinimumCustomersPerHour` (int): The minimum number of customers per hour.
  - `MaximumCustomersPerHour` (int): The maximum number of customers per hour.
  - `AverageCookiesPerSale` (double): The average number of cookies sold per customer.
  - `Owner` (string): The owner of the cookie stand.

### OneHourSales

- **Description**: Represents hourly sales data for a cookie stand.
- **Properties**:
  - `Id` (int): The unique identifier for the hourly sales data.
  - `hour` (int): The hour of sales data.
  - `CookieStandId` (int): The ID of the associated cookie stand.
  - `cookieStand` (CookieStand): The associated cookie stand.

## DTOs

### CREATCookieStandDTO



- **Description**: Data transfer object for creating a cookie stand.
- **Properties**:
  - `Location` (string): The location of the cookie stand.
  - `Description` (string): A description of the cookie stand.
  - `MinimumCustomersPerHour` (int): The minimum number of customers per hour.
  - `MaximumCustomersPerHour` (int): The maximum number of customers per hour.
  - `AverageCookiesPerSale` (double): The average number of cookies sold per customer.
  - `Owner` (string): The owner of the cookie stand.

### CookieStandDTO

- **Description**: Data transfer object for a cookie stand with hourly sales data.
- **Properties**:
  - `Id` (int): The unique identifier for the cookie stand.
  - `Location` (string): The location of the cookie stand.
  - `Description` (string): A description of the cookie stand.
  - `hourlySales` (List of int): Hourly sales data for the cookie stand.
  - `MinimumCustomersPerHour` (int): The minimum number of customers per hour.
  - `MaximumCustomersPerHour` (int): The maximum number of customers per hour.
  - `AverageCookiesPerSale` (double): The average number of cookies sold per customer.
  - `Owner` (string): The owner of the cookie stand.

## Program

### Program.cs

- **Description**: The entry point of the CookieStand API application.
- **Dependencies**:
  - CookieStandDbContext
  - OneHourSaleService
- **Configuration**:
  - Uses Entity Framework Core for database access.
  - Configures Swagger for API documentation.

## Services

### OneHourSaleService.cs

- **Description**: Service for generating random hourly sales data for a cookie stand.
- **Dependencies**:
  - CookieStandDbContext
- **Methods**:
  - `randomHourSales(CookieStand stand)`: Generates and updates hourly sales data for a given cookie stand.

