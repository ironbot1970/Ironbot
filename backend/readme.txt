
https://db4free.net/phpMyAdmin/index.php?route=/

generating model from DB:
cd irobotservice
dotnet ef dbcontext scaffold "Server=db4free.net;Port=3306;Database=ironbot1970;User Id=USER_ID;Password=PSWD;" Pomelo.EntityFrameworkCore.MySql -o Models
