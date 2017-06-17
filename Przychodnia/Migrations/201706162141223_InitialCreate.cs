namespace Przychodnia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DYZURs",
                c => new
                    {
                        ID_DYZUR = c.Int(nullable: false, identity: true),
                        DZIEN_DYZURU = c.DateTime(),
                        OD = c.DateTime(),
                        DO = c.DateTime(),
                        ID_PRACOWNIK = c.Int(nullable: false),
                        ID_ODDZIAL = c.Int(),
                    })
                .PrimaryKey(t => t.ID_DYZUR)
                .ForeignKey("dbo.ODDZIALs", t => t.ID_ODDZIAL)
                .ForeignKey("dbo.PRACOWNIKs", t => t.ID_PRACOWNIK, cascadeDelete: true)
                .Index(t => t.ID_PRACOWNIK)
                .Index(t => t.ID_ODDZIAL);
            
            CreateTable(
                "dbo.ODDZIALs",
                c => new
                    {
                        ID_ODDZIAL = c.Int(nullable: false, identity: true),
                        NAZWA = c.String(),
                        MIEJSCOWOSC = c.String(),
                        ID_PLACOWKA = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_ODDZIAL)
                .ForeignKey("dbo.PLACOWKAs", t => t.ID_PLACOWKA, cascadeDelete: true)
                .Index(t => t.ID_PLACOWKA);
            
            CreateTable(
                "dbo.ODDZIAL_PRACOWNIK",
                c => new
                    {
                        ID_ODDZIAL_PRACOWNIK = c.Int(nullable: false, identity: true),
                        ID_PRACOWNIK = c.Int(),
                        ID_ODDZIAL = c.Int(),
                    })
                .PrimaryKey(t => t.ID_ODDZIAL_PRACOWNIK)
                .ForeignKey("dbo.ODDZIALs", t => t.ID_ODDZIAL)
                .ForeignKey("dbo.PRACOWNIKs", t => t.ID_PRACOWNIK)
                .Index(t => t.ID_PRACOWNIK)
                .Index(t => t.ID_ODDZIAL);
            
            CreateTable(
                "dbo.PRACOWNIKs",
                c => new
                    {
                        ID_PRACOWNIK = c.Int(nullable: false, identity: true),
                        IMIE = c.String(),
                        NAZWISKO = c.String(),
                        ADRES = c.String(),
                        EMAIL_KONTAKTOWY = c.String(),
                        ID_SPECJALIZACJA = c.Int(),
                    })
                .PrimaryKey(t => t.ID_PRACOWNIK)
                .ForeignKey("dbo.SPECJALIZACJAs", t => t.ID_SPECJALIZACJA)
                .Index(t => t.ID_SPECJALIZACJA);
            
            CreateTable(
                "dbo.SPECJALIZACJAs",
                c => new
                    {
                        ID_SPECJALIZACJA = c.Int(nullable: false, identity: true),
                        NAZWA = c.String(),
                    })
                .PrimaryKey(t => t.ID_SPECJALIZACJA);
            
            CreateTable(
                "dbo.PLACOWKAs",
                c => new
                    {
                        ID_PLACOWKA = c.Int(nullable: false, identity: true),
                        NAZWA = c.String(),
                        MIEJSCOWOSC = c.String(),
                        ADRES = c.String(),
                    })
                .PrimaryKey(t => t.ID_PLACOWKA);
            
            CreateTable(
                "dbo.PACJENTs",
                c => new
                    {
                        ID_PACJENT = c.Int(nullable: false, identity: true),
                        IMIE = c.String(),
                        NAZWISKO = c.String(),
                        ADRES = c.String(),
                        PESEL = c.Long(),
                        TELEFON_KONTAKTOWY = c.String(),
                        EMAIL_KONTAKTOWY = c.String(),
                    })
                .PrimaryKey(t => t.ID_PACJENT);
            
            CreateTable(
                "dbo.WIZYTAs",
                c => new
                    {
                        ID_WIZYTA = c.Int(nullable: false, identity: true),
                        DATA_WIZYTY = c.DateTime(),
                        ID_SALA = c.Int(),
                        ID_PRACOWNIK = c.Int(),
                        ID_ODDZIAL = c.Int(),
                        ID_PACJENT = c.Int(),
                        ID_RECEPTA = c.Int(),
                        UWAGI = c.String(),
                    })
                .PrimaryKey(t => t.ID_WIZYTA)
                .ForeignKey("dbo.ODDZIALs", t => t.ID_ODDZIAL)
                .ForeignKey("dbo.PACJENTs", t => t.ID_PACJENT)
                .ForeignKey("dbo.PRACOWNIKs", t => t.ID_PRACOWNIK)
                .ForeignKey("dbo.RECEPTAs", t => t.ID_RECEPTA)
                .ForeignKey("dbo.SALAs", t => t.ID_SALA)
                .Index(t => t.ID_SALA)
                .Index(t => t.ID_PRACOWNIK)
                .Index(t => t.ID_ODDZIAL)
                .Index(t => t.ID_PACJENT)
                .Index(t => t.ID_RECEPTA);
            
            CreateTable(
                "dbo.RECEPTAs",
                c => new
                    {
                        ID_RECEPTA = c.Int(nullable: false, identity: true),
                        DATA_WYKORZYSTANIA = c.DateTime(),
                        NAZWA_LEKU = c.String(),
                        UWAGI = c.String(),
                    })
                .PrimaryKey(t => t.ID_RECEPTA);
            
            CreateTable(
                "dbo.SALAs",
                c => new
                    {
                        ID_SALA = c.Int(nullable: false, identity: true),
                        NUMER_SALI = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_SALA);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WIZYTAs", "ID_SALA", "dbo.SALAs");
            DropForeignKey("dbo.WIZYTAs", "ID_RECEPTA", "dbo.RECEPTAs");
            DropForeignKey("dbo.WIZYTAs", "ID_PRACOWNIK", "dbo.PRACOWNIKs");
            DropForeignKey("dbo.WIZYTAs", "ID_PACJENT", "dbo.PACJENTs");
            DropForeignKey("dbo.WIZYTAs", "ID_ODDZIAL", "dbo.ODDZIALs");
            DropForeignKey("dbo.DYZURs", "ID_PRACOWNIK", "dbo.PRACOWNIKs");
            DropForeignKey("dbo.DYZURs", "ID_ODDZIAL", "dbo.ODDZIALs");
            DropForeignKey("dbo.ODDZIALs", "ID_PLACOWKA", "dbo.PLACOWKAs");
            DropForeignKey("dbo.PRACOWNIKs", "ID_SPECJALIZACJA", "dbo.SPECJALIZACJAs");
            DropForeignKey("dbo.ODDZIAL_PRACOWNIK", "ID_PRACOWNIK", "dbo.PRACOWNIKs");
            DropForeignKey("dbo.ODDZIAL_PRACOWNIK", "ID_ODDZIAL", "dbo.ODDZIALs");
            DropIndex("dbo.WIZYTAs", new[] { "ID_RECEPTA" });
            DropIndex("dbo.WIZYTAs", new[] { "ID_PACJENT" });
            DropIndex("dbo.WIZYTAs", new[] { "ID_ODDZIAL" });
            DropIndex("dbo.WIZYTAs", new[] { "ID_PRACOWNIK" });
            DropIndex("dbo.WIZYTAs", new[] { "ID_SALA" });
            DropIndex("dbo.PRACOWNIKs", new[] { "ID_SPECJALIZACJA" });
            DropIndex("dbo.ODDZIAL_PRACOWNIK", new[] { "ID_ODDZIAL" });
            DropIndex("dbo.ODDZIAL_PRACOWNIK", new[] { "ID_PRACOWNIK" });
            DropIndex("dbo.ODDZIALs", new[] { "ID_PLACOWKA" });
            DropIndex("dbo.DYZURs", new[] { "ID_ODDZIAL" });
            DropIndex("dbo.DYZURs", new[] { "ID_PRACOWNIK" });
            DropTable("dbo.SALAs");
            DropTable("dbo.RECEPTAs");
            DropTable("dbo.WIZYTAs");
            DropTable("dbo.PACJENTs");
            DropTable("dbo.PLACOWKAs");
            DropTable("dbo.SPECJALIZACJAs");
            DropTable("dbo.PRACOWNIKs");
            DropTable("dbo.ODDZIAL_PRACOWNIK");
            DropTable("dbo.ODDZIALs");
            DropTable("dbo.DYZURs");
        }
    }
}
