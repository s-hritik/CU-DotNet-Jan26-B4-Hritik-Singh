using Microsoft.Data.SqlClient;
using System;

// Load the .env file from the API directory
DotNetEnv.Env.Load("../LibraryManagementApi/.env");

string targetConnectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection") 
    ?? throw new InvalidOperationException("Connection string not found in environment variables.");

// Since we need to connect to master to create the DB, we replace Database=LibraryDB with Database=master
string masterConnectionString = targetConnectionString.Replace("Database=LibraryDB", "Database=master");

try
{
    using (SqlConnection connection = new SqlConnection(masterConnectionString))
    {
        connection.Open();
        
        // Check if database exists, create if not
        string createDbQuery = @"
            IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'LibraryDB')
            BEGIN
                CREATE DATABASE LibraryDB;
            END;
        ";
        using (SqlCommand cmd = new SqlCommand(createDbQuery, connection))
        {
            cmd.ExecuteNonQuery();
            Console.WriteLine("Database LibraryDB created or already exists.");
        }
    }

    // Now connect to LibraryDB and create tables
    using (SqlConnection connection = new SqlConnection(targetConnectionString))
    {
        connection.Open();
        
        string createTablesQuery = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Authors' AND xtype='U')
            BEGIN
                CREATE TABLE Authors (
                    Id INT PRIMARY KEY IDENTITY(1,1),
                    Name NVARCHAR(100) NOT NULL,
                    Bio NVARCHAR(MAX)
                );
            END;

            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Books' AND xtype='U')
            BEGIN
                CREATE TABLE Books (
                    Id INT PRIMARY KEY IDENTITY(1,1),
                    Title NVARCHAR(200) NOT NULL,
                    Description NVARCHAR(MAX),
                    AuthorId INT NOT NULL,
                    FOREIGN KEY (AuthorId) REFERENCES Authors(Id)
                );
            END;
        ";
        
        using (SqlCommand cmd = new SqlCommand(createTablesQuery, connection))
        {
            cmd.ExecuteNonQuery();
            Console.WriteLine("Tables Authors and Books created or already exist.");
        }

        string seedDataQuery = @"
            IF NOT EXISTS (SELECT * FROM Authors)
            BEGIN
                INSERT INTO Authors (Name, Bio) VALUES 
                ('J.K. Rowling', 'British author, best known for Harry Potter.'),
                ('George R.R. Martin', 'American novelist, known for A Song of Ice and Fire.'),
                ('J.R.R. Tolkien', 'English writer, known for The Lord of the Rings.');

                INSERT INTO Books (Title, Description, AuthorId) VALUES 
                ('Harry Potter and the Sorcerer''s Stone', 'A young boy discovers he is a wizard.', 1),
                ('A Game of Thrones', 'Noble families fight for control of the Iron Throne.', 2),
                ('The Fellowship of the Ring', 'A hobbit sets out on a journey to destroy the One Ring.', 3);
            END;
        ";
        using (SqlCommand cmd = new SqlCommand(seedDataQuery, connection))
        {
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
                Console.WriteLine("Seed data successfully inserted into Authors and Books.");
            else
                Console.WriteLine("Seed data already exists, skipping insertion.");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
