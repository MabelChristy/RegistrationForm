# RegistrationForm # Registration Form with Report Generation

## Overview
This is an **ASP.NET Web Forms** project that allows users to register and manage their details. The application includes CRUD (Create, Read, Update, Delete) operations for user registration and a **Report Viewer** for generating reports from the database.

## Features
- **User Registration** with fields: M.No, Name, DOB, Address, PAN, and Aadhar.
- **Database Integration** using `SQL Server`.
- **CRUD Operations** (Add, Save, Edit, Delete) for managing user data.
- **Auto-generated M.No** for new users.
- **Real-time Fetching** of user details based on M.No.
- **Data Validation** for PAN and Aadhar.
- **Report Generation** using `RDLC Report Viewer`.

## Technologies Used
- **ASP.NET Web Forms**
- **C#**
- **SQL Server**
- **RDLC Report Viewer**
- **Bootstrap (for UI Styling, optional)**

## Project Structure
```
|-- App_Code
|   |-- DbConnection.cs  # Database Connection Helper
|-- Site.Master          # Master Page
|-- Register.aspx        # Registration Page (UI)
|-- Register.aspx.cs     # Registration Logic
|-- Report.aspx          # Report Viewer Page
|-- Report.aspx.cs       # Report Logic
|-- Styles/              # CSS Styles
```

## Database Setup
1. **Create the Database**: `MemberDb`
2. **Create the Table**: `Users`
```sql
CREATE TABLE Users (
    MNo INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    DOB DATE,
    Address NVARCHAR(255),
    PAN NVARCHAR(10),
    Aadhar NVARCHAR(12)
);
```
3. **Update Connection String** in `DbConnection.cs`
```csharp
public static class DbHelper
{
    private static string connStr = "Server=(local)\\SQLEXPRESS;Database=MemberDb;Integrated Security=True;";
    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connStr);
    }
}
```

## Installation & Setup
1. **Clone the Repository**:
   ```sh
   git clone https://github.com/yourusername/yourrepository.git
   ```
2. **Open in Visual Studio** (2010 or later).
3. **Ensure Database Connection is Correct** in `DbConnection.cs`.
4. **Run the Project** (`Ctrl + F5`).

## Usage
- **Register a User**: Enter details and click **Save**.
- **Edit Details**: Enter M.No and click **Edit**.
- **Delete a User**: Enter M.No and click **Delete**.
- **Generate Report**: Click **Report** to view the data in `RDLC Report Viewer`.

## Contribution
Feel free to fork, contribute, and submit a pull request! 😊

## License
This project is **open-source**. Modify and use as needed!

