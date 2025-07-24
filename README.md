# Vitura Health Backend Api

This repository contains a simple Vitura Health Backend Api, designed to expose 3 main endpoints for the client application.

## Technologies Used

### Backend (.NET Core)
* **Framework:** .NET 8.0
* **Language:** C#
* **Database:** In-memory database (for simplicity of demo)
* **API:** RESTful Web API
* **Validation:** FluentValidation

## How to Run the Application (Directions for Interviewer)

Please follow these steps to get both the backend API and the React frontend up and running.

### 1. Prerequisites

Before you start, ensure you have the following installed:
* **.NET SDK 8.0** or later: [Download .NET](https://dotnet.microsoft.com/download)

### 2. Backend Setup (C# .NET API)

1.  **Navigate to the Backend Directory:**
    Open your terminal or command prompt and go into the backend folder.
    ```bash
    cd YourMicroservice.Api # Or whatever your backend folder is named (e.g., CodeChallenge/YourMicroservice.Api)
    ```
2.  **Restore Dependencies:**
    ```bash
    dotnet restore
    ```
3.  **Run the Backend API:**
    ```bash
    dotnet run
    ```
    The API should start, typically listening on `https://localhost:7111` (check the console output for the exact URL). Keep this terminal window open.


## Future Improvements

* Implement proper backend pagination and filtering for prescriptions.
* Add more robust client-side form validation.
* Implement authentication and authorization.
* Add delete/edit functionality for prescriptions.
* Resolve the Tailwind CSS rendering inconsistency for a fully styled UI.

---