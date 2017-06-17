namespace Przychodnia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PRACOWNIKs", "ID_SPECJALIZACJA", "dbo.SPECJALIZACJAs");
            DropForeignKey("dbo.ODDZIALs", "ID_PLACOWKA", "dbo.PLACOWKAs");
            DropIndex("dbo.ODDZIALs", new[] { "ID_PLACOWKA" });
            DropIndex("dbo.PRACOWNIKs", new[] { "ID_SPECJALIZACJA" });
            DropColumn("dbo.ODDZIALs", "MIEJSCOWOSC");
            DropColumn("dbo.ODDZIALs", "ID_PLACOWKA");
            DropColumn("dbo.PRACOWNIKs", "ADRES");
            DropColumn("dbo.PRACOWNIKs", "EMAIL_KONTAKTOWY");
            DropColumn("dbo.PRACOWNIKs", "ID_SPECJALIZACJA");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PRACOWNIKs", "ID_SPECJALIZACJA", c => c.Int());
            AddColumn("dbo.PRACOWNIKs", "EMAIL_KONTAKTOWY", c => c.String());
            AddColumn("dbo.PRACOWNIKs", "ADRES", c => c.String());
            AddColumn("dbo.ODDZIALs", "ID_PLACOWKA", c => c.Int(nullable: false));
            AddColumn("dbo.ODDZIALs", "MIEJSCOWOSC", c => c.String());
            CreateIndex("dbo.PRACOWNIKs", "ID_SPECJALIZACJA");
            CreateIndex("dbo.ODDZIALs", "ID_PLACOWKA");
            AddForeignKey("dbo.ODDZIALs", "ID_PLACOWKA", "dbo.PLACOWKAs", "ID_PLACOWKA", cascadeDelete: true);
            AddForeignKey("dbo.PRACOWNIKs", "ID_SPECJALIZACJA", "dbo.SPECJALIZACJAs", "ID_SPECJALIZACJA");
        }
    }
}
