namespace Twit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Followers1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FollowerId = c.Int(nullable: false),
                        FolloweeId = c.Int(nullable: false),
                        Followee_PersonId = c.Int(),
                        Follower_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Followee_PersonId)
                .ForeignKey("dbo.People", t => t.Follower_PersonId)
                .Index(t => t.Followee_PersonId)
                .Index(t => t.Follower_PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Follows", "Follower_PersonId", "dbo.People");
            DropForeignKey("dbo.Follows", "Followee_PersonId", "dbo.People");
            DropIndex("dbo.Follows", new[] { "Follower_PersonId" });
            DropIndex("dbo.Follows", new[] { "Followee_PersonId" });
            DropTable("dbo.Follows");
        }
    }
}
