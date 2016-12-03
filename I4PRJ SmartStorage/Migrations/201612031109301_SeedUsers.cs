namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Firstname], [Middlename], [Lastname], [ProfilePicture], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f3abad6c-8cfc-4d08-a07d-52315eec257d', N'Admin', N'Admin', N'Admin', NULL, N'no-reply@smartstorage.com', 0, N'AGPGSHyu/ZmNcOlixV/zMigWwazupH+N062mJqrVdW8a7K5GqWMQeuFUu31sojLnWg==', N'5b313315-c94f-411d-ae2a-d3f6ff3697fe', N'12345678', 0, 0, NULL, 1, 0, N'admin')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ee6528f2-3bd7-4003-92e0-b8a29dfbe0f8', N'Admin')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f3abad6c-8cfc-4d08-a07d-52315eec257d')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
