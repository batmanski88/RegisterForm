namespace Zadanko.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdditionalInterests",
                c => new
                    {
                        AdditionalInterestID = c.Int(nullable: false, identity: true),
                        Interest = c.String(),
                        Client_ClientID = c.Int(),
                    })
                .PrimaryKey(t => t.AdditionalInterestID)
                .ForeignKey("dbo.Clients", t => t.Client_ClientID)
                .Index(t => t.Client_ClientID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Receipt = c.Binary(),
                    })
                .PrimaryKey(t => t.ClientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdditionalInterests", "Client_ClientID", "dbo.Clients");
            DropIndex("dbo.AdditionalInterests", new[] { "Client_ClientID" });
            DropTable("dbo.Clients");
            DropTable("dbo.AdditionalInterests");
        }
    }
}
