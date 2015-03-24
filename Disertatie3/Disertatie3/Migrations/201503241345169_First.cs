namespace Disertatie3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        IsDeleted = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Consums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        MaterieId = c.Int(),
                        UserId = c.Int(),
                        Cantitate = c.Int(nullable: false),
                        Materii_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MateriiPrimes", t => t.Materii_Id)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.Materii_Id)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MateriiPrimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                        UserId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.StocMateriis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        MaterieId = c.Int(),
                        Cantitate = c.Int(nullable: false),
                        Materii_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MateriiPrimes", t => t.Materii_Id)
                .Index(t => t.Materii_Id);
            
            CreateTable(
                "dbo.Retetes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProdusId = c.Int(),
                        MaterieId = c.Int(),
                        Cantitate = c.Int(nullable: false),
                        UserId = c.Int(),
                        Produse_Id = c.Int(),
                        Materii_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produses", t => t.Produse_Id)
                .ForeignKey("dbo.MateriiPrimes", t => t.Materii_Id)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.Produse_Id)
                .Index(t => t.Materii_Id)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Produses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.StocProduses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        ProdusId = c.Int(),
                        Cantitate = c.Int(nullable: false),
                        Produse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produses", t => t.Produse_Id)
                .Index(t => t.Produse_Id);
            
            CreateTable(
                "dbo.Platis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Plata = c.Boolean(nullable: false),
                        Catre = c.String(),
                        DocumentPlata = c.String(),
                        Factura = c.String(),
                        Valoare = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Incasaris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Incasat = c.Boolean(nullable: false),
                        DeLa = c.String(),
                        Data = c.DateTime(nullable: false),
                        FacturaInc = c.String(),
                        DocumentInc = c.String(),
                        ValoareInc = c.Int(nullable: false),
                        Scadenta = c.DateTime(nullable: false),
                        Scontare = c.String(),
                        Girat = c.String(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Incasaris", new[] { "UserId" });
            DropIndex("dbo.Platis", new[] { "UserId" });
            DropIndex("dbo.StocProduses", new[] { "Produse_Id" });
            DropIndex("dbo.Produses", new[] { "UserId" });
            DropIndex("dbo.Retetes", new[] { "UserId" });
            DropIndex("dbo.Retetes", new[] { "Materii_Id" });
            DropIndex("dbo.Retetes", new[] { "Produse_Id" });
            DropIndex("dbo.StocMateriis", new[] { "Materii_Id" });
            DropIndex("dbo.MateriiPrimes", new[] { "UserId" });
            DropIndex("dbo.Consums", new[] { "UserId" });
            DropIndex("dbo.Consums", new[] { "Materii_Id" });
            DropForeignKey("dbo.Incasaris", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Platis", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.StocProduses", "Produse_Id", "dbo.Produses");
            DropForeignKey("dbo.Produses", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Retetes", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Retetes", "Materii_Id", "dbo.MateriiPrimes");
            DropForeignKey("dbo.Retetes", "Produse_Id", "dbo.Produses");
            DropForeignKey("dbo.StocMateriis", "Materii_Id", "dbo.MateriiPrimes");
            DropForeignKey("dbo.MateriiPrimes", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Consums", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Consums", "Materii_Id", "dbo.MateriiPrimes");
            DropTable("dbo.Incasaris");
            DropTable("dbo.Platis");
            DropTable("dbo.StocProduses");
            DropTable("dbo.Produses");
            DropTable("dbo.Retetes");
            DropTable("dbo.StocMateriis");
            DropTable("dbo.MateriiPrimes");
            DropTable("dbo.Consums");
            DropTable("dbo.UserProfile");
        }
    }
}
