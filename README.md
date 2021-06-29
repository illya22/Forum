 Firstly, copy the contents of the db file to your SQL Server database folder.
 
Then open the project, and in it the Web.config file. Fing line 60, here you will se conection.

In my case it is source=DESKTOP-S7GB93D\SQLEXPRESS. 
You need to change this fragment with the name of your SQL server.

 To see db diagram open:
 
 Forum/Models/DB.edmx or dbo.Diagram in ForumDB.mdf
