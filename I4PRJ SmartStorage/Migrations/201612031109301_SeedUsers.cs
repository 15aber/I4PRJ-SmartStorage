namespace I4PRJ_SmartStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Firstname], [Middlename], [Lastname], [ProfilePicture], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'61b10f89-4f17-4821-aa33-73520ffe3739', N'Victor', NULL, N'Busk', N'https://scontent.xx.fbcdn.net/v/t1.0-1/p200x200/14656375_1414186365262679_9099103651852753464_n.jpg?oh=f98f3b06e676a0cbc15be0d04e19f666&oe=58BAE4D8', N'victorbusk@hotmail.com', 0, NULL, N'1bfed30c-29f9-4bb3-98aa-e6f53425a11e', N'30828723', 1, 0, NULL, 1, 0, N'victor')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Firstname], [Middlename], [Lastname], [ProfilePicture], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f3abad6c-8cfc-4d08-a07d-52315eec257d', N'Admin', N'Admin', N'Admin', NULL, N'victorbusk@gmail.com', 0, N'AGPGSHyu/ZmNcOlixV/zMigWwazupH+N062mJqrVdW8a7K5GqWMQeuFUu31sojLnWg==', N'5b313315-c94f-411d-ae2a-d3f6ff3697fe', N'30828723', 0, 0, NULL, 1, 0, N'admin')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ee6528f2-3bd7-4003-92e0-b8a29dfbe0f8', N'Admin')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f3abad6c-8cfc-4d08-a07d-52315eec257d', N'ee6528f2-3bd7-4003-92e0-b8a29dfbe0f8')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
