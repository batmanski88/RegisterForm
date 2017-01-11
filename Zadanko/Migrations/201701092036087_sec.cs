namespace Zadanko.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sec : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Interests", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "Interests");
        }
    }
}
