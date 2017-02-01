# Shop-Product

##Summary
This application is split into three parts which cover some of the most common usages of the .NET platform

###Shop Product.Parsing
This project parses and deserializes rows of data in CSV, XML, and JSON format into lists of POCOs. The lists are then saved to persistent storage using the data layer.

###Shop Product.Data
This project contains the database-first model (edmx) which visualizes a SQL Server Express database containing shop product data. it also contains classes which interface with the database and returns data from it.

Involves usage of Entity Framework as an ORM to provide easy usage with LINQ and intellisense support.

###Shop Product.Viewer
A basic ASP.NET MVC Application listing shop products from the SQL Server Express database which includes searching and paging functionality and is formatted using Bootstrap.

##Technologies
- ASP.NET MVC
- Entity Framework
- LINQ
- Newtonsoft.NET
- XML deserialization
- Bootstrap
