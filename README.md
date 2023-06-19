# Webdev Assignment 1
## ASP.NET CORE APP


### ADDED PACKAGES:
- dotenv
  - A library used to read configs from a `.env` file
- Microsoft.EntityFrameworkCore.SqlServer
  - A library to interface with the database engine (MSSQL)

### SASS:
To install sass, run the following commands:
```bash
npm install --global sass
```
All SASS files go into `./Styles` and will be automatically compiled from `site.scss` to `./wwwroot/css/site.css`

### This application depends on an SQL Server
After using [this link](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15) to download SQL Server Config Manager, 
Enter the SQL SERVER NETWORK CONFIGURATION (not 32 bit) and enable everything for protocols.
Next, disconnect from everything in SQL for SQL Server Object Explorer then added SQLEXPRESS.
The next step is to right click on your SQLEXPRESS and press properties
Then if you scroll to the very top of the properties, you will see "Connection String"
copy that and paste it into Startup.cs and appsettings.json
then re-run the program and it will work
