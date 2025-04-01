# RankTracker

RankTracker is a web application that allows users to track the ranking of their websites for specific keywords on various search engines. Currently, we have implemented Google and Bing search engine tracking. The framework is designed to be easily extensible to other search engines.

**Important Notes:**

* Due to current restrictions imposed by Google Search, we are temporarily unable to automatically update Google search rankings. Manual updates or alternative scraping methods may be required.
* For Bing search rankings, we have a limitation of checking only the top 10 results. While Bing allows pagination, we have chosen not to implement it at this time to avoid potential IP blocking or rate limiting issues.

## Table of Contents

- [About](#about)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Running the Application](#running-the-application)
- [Application Functionality](#application-functionality)
- [Application Design & Coding](#application-design--coding)
- [Testing](#testing)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## About

RankTracker simplifies the process of monitoring website rankings for targeted keywords. It provides a user-friendly interface to add websites, keywords, and track their performance across search engines like Google and Bing. This project was developed as a personal project to demonstrate full-stack development skills using ASP.NET Core Web API and Angular.

## Technologies Used

- **Backend:**
  - ASP.NET Core 9.0 Web API (in `server` folder)
  - Entity Framework Core with InMemory and SQL Server Express Support
  - C#
- **Frontend:**
  - Angular 19 (in `client` folder)
  - TypeScript
  - Latest version of Bootstrap
- **Database:**
  - InMemory Database (for development/testing)
  - SQL Server Express

## Getting Started

### Prerequisites

- [.NET SDK 9.0](https://dotnet.microsoft.com/download)
- [Node.js 16 or later](https://nodejs.org/en/download/)
- [Angular CLI 19](https://angular.io/cli)
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Optional, for SQL Server Express database support)

### Installation

1.  Clone the repository:
    ```bash
    git clone [https://github.com/themihirsolanki/RankTracker](https://github.com/themihirsolanki/RankTracker)
    ```
2.  Navigate to the project directory:
    ```bash
    cd RankTracker
    ```
3.  Navigate to the backend directory:
    ```bash
    cd server
    ```
4.  Restore backend dependencies:
    ```bash
    dotnet restore
    ```
5.  Navigate to the frontend directory:
    ```bash
    cd ../client
    ```
6.  Install frontend dependencies:
    ```bash
    npm install
    ```
7.  Configure the database connection:
    -   **Note:** You only need to install and configure SQL Server Express if you prefer to use it. For demonstration purposes, the InMemory database is recommended.
    -   If no changes are made to the `appsettings.json`, the InMemory database will be used.
    -   For using SQL Server Express, update the `appsettings.json` file in the `server` directory (API project: `RankTracker.Api`) with your SQL Server Express connection string.
    -   Create the database and tables by running the SQL script located in the `database` folder, named `RankTracker.sql`, using SQL Server Management Studio or a similar tool.

### Running the Application

1.  Start the backend server:
    ```bash
    cd ../server
    dotnet run --project RankTracker.Api
    ```
2.  Start the frontend development server:
    ```bash
    cd ../client
    ng serve
    ```
3.  Open your browser and navigate to `http://localhost:4200`.

    **Note:** The ASP.NET Core backend is configured to allow Cross-Origin Resource Sharing (CORS) from any port. Therefore, if the Angular client is running on a different port than 4200, it will still function correctly.

## Application Functionality

Upon first launch, users are presented with a setup screen where they are prompted to enter a domain name followed by a list of keywords, each on a new line.

If the Web API is not running or is unreachable, the user will receive an error message: "The website is currently unable to connect to the API. Please check your API connection and click 'Retry' to try again."

Once the domain and keywords are entered, users are directed to the dashboard. The dashboard displays all the added keywords, their current rankings, and provides options to:

* Add more keywords.
* Refresh the ranking status of individual keywords.
* Refresh the ranking status of all keywords.
* Delete keywords.

A chart icon is also displayed next to each keyword. Ideally, this icon would display the historical ranking data for the keyword, but this feature is currently not implemented.

## Application Design & Coding

The application is designed and coded with a focus on maintainability and scalability. We have strived to adhere to several key software development principles:

* **SOLID Principles:** The backend architecture is structured to follow the SOLID principles, promoting modularity and ease of extension.
* **Clean Code:** We have aimed for clean and readable code, using meaningful variable names and well-organized functions and classes.
* **DRY (Don't Repeat Yourself):** Redundant code is minimized through the use of reusable components and functions.
* **Meaningful Comments:** Code is accompanied by meaningful comments to enhance understanding and maintainability.

## Testing

1.  Due to time constraints, unit tests are not implemented in this project. However, in an ideal development scenario, I strongly prefer a unit test-first approach.
2.  API testing can be performed using Postman or similar tools.

## Contributing

Contributions are not currently accepted.

## License

This project is licensed under the [MIT License](LICENSE) - see the [LICENSE](LICENSE) file for details.

## Contact

-   LinkedIn: [https://www.linkedin.com/in/mihirsolanki/](https://www.linkedin.com/in/mihirsolanki/)