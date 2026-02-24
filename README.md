# Christian ELibrary Management Site

### Project Description
The Christian ELibrary Management Site is a specialized web application designed to manage a digital collection of Christian literature, including books, devotionals, and theological resources. The platform serves as a centralized hub where administrators can organize library assets and users can browse or manage their reading lists.

### Technologies Used
The project is built using a modern technology stack to ensure performance, scalability, and ease of maintenance:

*   **Backend:** ASP.NET (C#) / .NET Framework or Core
*   **Database:** Microsoft SQL Server
*   **Frontend:** HTML5, CSS3, JavaScript
*   **Styling:** Bootstrap Framework
*   **Data Access:** Entity Framework / ADO.NET
*   **Development Environment:** Visual Studio

### Site Utilities
The application provides several core utilities to facilitate library management and user interaction:

*   **User Authentication:** Secure registration and login system for members and administrators.
*   **Inventory Management:** Complete CRUD (Create, Read, Update, Delete) operations for books, authors, and genres.
*   **Search and Filter:** Advanced search functionality to find books by title, author, or category.
*   **Role-Based Access Control:** Separate interfaces and permissions for regular members and administrative staff.
*   **Database Connectivity:** Robust integration with SQL Server for persistent data storage and retrieval.

### Created Pages
The following pages have been developed to support the site's functionality:

*   <u>**Home Page**</u>: The landing page featuring a welcome message and highlighted book collections.
*   <u>**User Login Page**</u>: Secure entry point for registered users and administrators.
*   <u>**User Sign Up Page**</u>: Form for new users to create an account within the library system.
*   <u>**Book Inventory Page**</u>: Administrative interface for adding, updating, or removing books from the database.
*   <u>**Author Management Page**</u>: Dedicated section for managing author profiles and their associated works.
*   <u>**Genre/Category Page**</u>: Interface for organizing books into specific Christian literature categories.
*   <u>**Book Issuing Page**</u>: Utility for tracking which books are currently borrowed by members.
*   <u>**Member Management Page**</u>: Admin-only view for overseeing user accounts and their activities.
*   <u>**Books Viewing Page**</u>: Public or member-facing catalog where users can browse all available titles.

### Project Screenshots
You can find the visual representation of each page below:

#### Home Page
![Home Page](/ElibraryManagement/github_images/homepage1.jpgpng)
![Home Page](/ElibraryManagement/github_images/homepage2.jpgpng)

#### User Login and Sign Up
![Login Page](path/to/your/image_login.png)
![Sign Up Page](path/to/your/image_signup.png)

#### Admin Dashboard and Inventory
![Book Inventory](path/to/your/image_inventory.png)
![Author Management](path/to/your/image_authors.png)
![Genre Management](path/to/your/image_genres.png)

#### Member Management
![Member List](path/to/your/image_members.png)

#### Book Catalog
![Book View](path/to/your/image_bookview.png)

### Installation and Setup
1.  Clone the repository: `git clone https://github.com/emanuelco07/Christian_ELibrary_Management_Site.git`
2.  Open the solution file (`.sln`) in Visual Studio.
3.  Update the connection string in `web.config` or `appsettings.json` to point to your local SQL Server instance.
4.  Apply migrations or run the provided SQL script to set up the database.
5.  Run the project using IIS Express or the Kestrel server.
