USE [master]
GO
CREATE LOGIN [epicvitamins] WITH PASSWORD=N'password', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [epicvitamins]
GO
USE [EpicVitamins]
GO
CREATE USER [epicvitamins] FOR LOGIN [epicvitamins]
GO
