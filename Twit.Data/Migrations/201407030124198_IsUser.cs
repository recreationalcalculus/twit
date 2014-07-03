namespace Twit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "IsUser", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "IsUser");
        }
    }
}
