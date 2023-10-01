namespace IISAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autobus",
                c => new
                    {
                        id_aut = c.Int(nullable: false, identity: true),
                        kap_aut = c.Int(nullable: false),
                        reg_aut = c.String(),
                        obrisan = c.Boolean(nullable: false),
                        autoprev_id_prev = c.Int(),
                    })
                .PrimaryKey(t => t.id_aut)
                .ForeignKey("dbo.Autoprevozniks", t => t.autoprev_id_prev)
                .Index(t => t.autoprev_id_prev);
            
            CreateTable(
                "dbo.Autoprevozniks",
                c => new
                    {
                        id_prev = c.Int(nullable: false, identity: true),
                        naziv_prev = c.String(),
                    })
                .PrimaryKey(t => t.id_prev);
            
            CreateTable(
                "dbo.Kartas",
                c => new
                    {
                        id_karte = c.Int(nullable: false, identity: true),
                        broj_sedista = c.Int(nullable: false),
                        cena = c.Int(nullable: false),
                        vrsta_karte = c.String(),
                        vazeca = c.String(),
                        obrisan = c.Boolean(nullable: false),
                        rezervisana = c.Int(nullable: false),
                        datum = c.String(),
                        salterski_radnik = c.String(),
                        korisnik_id_kor = c.Int(),
                        voznja_id_voz = c.Int(),
                    })
                .PrimaryKey(t => t.id_karte)
                .ForeignKey("dbo.Korisniks", t => t.korisnik_id_kor)
                .ForeignKey("dbo.Voznjas", t => t.voznja_id_voz)
                .Index(t => t.korisnik_id_kor)
                .Index(t => t.voznja_id_voz);
            
            CreateTable(
                "dbo.Korisniks",
                c => new
                    {
                        id_kor = c.Int(nullable: false, identity: true),
                        ime = c.String(),
                        prezime = c.String(),
                        tip_korisnika = c.String(),
                        status_korisnika = c.String(),
                        email = c.String(),
                        username = c.String(),
                        password = c.String(),
                        obrisan = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id_kor);
            
            CreateTable(
                "dbo.Voznjas",
                c => new
                    {
                        id_voz = c.Int(nullable: false, identity: true),
                        dol_sat = c.String(),
                        pol_sat = c.String(),
                        obrisan = c.Boolean(nullable: false),
                        preko = c.String(),
                        brSlobodnih = c.Int(nullable: false),
                        cena = c.Single(nullable: false),
                        datum = c.String(),
                        popustPovratna = c.Single(nullable: false),
                        popustStudentska = c.Single(nullable: false),
                        popustPenzioner = c.Single(nullable: false),
                        autobus_id_aut = c.Int(),
                        krajnja_stan_id_stan = c.Int(),
                        peron_id_per = c.Int(),
                        polazna_stan_id_stan = c.Int(),
                    })
                .PrimaryKey(t => t.id_voz)
                .ForeignKey("dbo.Autobus", t => t.autobus_id_aut)
                .ForeignKey("dbo.Stanicas", t => t.krajnja_stan_id_stan)
                .ForeignKey("dbo.Perons", t => t.peron_id_per)
                .ForeignKey("dbo.Stanicas", t => t.polazna_stan_id_stan)
                .Index(t => t.autobus_id_aut)
                .Index(t => t.krajnja_stan_id_stan)
                .Index(t => t.peron_id_per)
                .Index(t => t.polazna_stan_id_stan);
            
            CreateTable(
                "dbo.Stanicas",
                c => new
                    {
                        id_stan = c.Int(nullable: false, identity: true),
                        naz_stan = c.String(),
                        grad_stan = c.String(),
                        obrisan = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id_stan);
            
            CreateTable(
                "dbo.Perons",
                c => new
                    {
                        id_per = c.Int(nullable: false, identity: true),
                        naz_per = c.String(),
                        obrisan = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id_per);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kartas", "voznja_id_voz", "dbo.Voznjas");
            DropForeignKey("dbo.Voznjas", "polazna_stan_id_stan", "dbo.Stanicas");
            DropForeignKey("dbo.Voznjas", "peron_id_per", "dbo.Perons");
            DropForeignKey("dbo.Voznjas", "krajnja_stan_id_stan", "dbo.Stanicas");
            DropForeignKey("dbo.Voznjas", "autobus_id_aut", "dbo.Autobus");
            DropForeignKey("dbo.Kartas", "korisnik_id_kor", "dbo.Korisniks");
            DropForeignKey("dbo.Autobus", "autoprev_id_prev", "dbo.Autoprevozniks");
            DropIndex("dbo.Voznjas", new[] { "polazna_stan_id_stan" });
            DropIndex("dbo.Voznjas", new[] { "peron_id_per" });
            DropIndex("dbo.Voznjas", new[] { "krajnja_stan_id_stan" });
            DropIndex("dbo.Voznjas", new[] { "autobus_id_aut" });
            DropIndex("dbo.Kartas", new[] { "voznja_id_voz" });
            DropIndex("dbo.Kartas", new[] { "korisnik_id_kor" });
            DropIndex("dbo.Autobus", new[] { "autoprev_id_prev" });
            DropTable("dbo.Perons");
            DropTable("dbo.Stanicas");
            DropTable("dbo.Voznjas");
            DropTable("dbo.Korisniks");
            DropTable("dbo.Kartas");
            DropTable("dbo.Autoprevozniks");
            DropTable("dbo.Autobus");
        }
    }
}
