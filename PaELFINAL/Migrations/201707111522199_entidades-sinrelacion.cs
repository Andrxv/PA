namespace PaELFINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entidadessinrelacion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        cod_area = c.String(nullable: false, maxLength: 128),
                        cod_nombre = c.String(),
                    })
                .PrimaryKey(t => t.cod_area);
            
            CreateTable(
                "dbo.Asignaturas",
                c => new
                    {
                        asignaturaID = c.Int(nullable: false, identity: true),
                        NombreAsignatura = c.String(),
                        creditos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.asignaturaID);
            
            CreateTable(
                "dbo.Estudiantes",
                c => new
                    {
                        EstudianteID = c.String(nullable: false, maxLength: 128),
                        primer_nombre = c.String(),
                        segundo_nombre = c.String(),
                        primer_apellido = c.String(),
                        segundo_apellido = c.String(),
                        trimestres_cursados = c.Int(nullable: false),
                        indice = c.Single(nullable: false),
                        creditos_aprobados = c.Int(nullable: false),
                        materias_aprobadas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EstudianteID);
            
            CreateTable(
                "dbo.Profesors",
                c => new
                    {
                        ProfesorID = c.Int(nullable: false, identity: true),
                        Primer_Nombre = c.String(),
                        Segundo_Nombre = c.String(),
                        Apellido = c.String(),
                    })
                .PrimaryKey(t => t.ProfesorID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Seccions",
                c => new
                    {
                        seccionID = c.Int(nullable: false, identity: true),
                        Horario = c.String(),
                        Dias = c.String(),
                        Aula = c.String(),
                    })
                .PrimaryKey(t => t.seccionID);
            
            CreateTable(
                "dbo.TipodeContratoes",
                c => new
                    {
                        TipodeContratoId = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TipodeContratoId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TipodeContratoes");
            DropTable("dbo.Seccions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Profesors");
            DropTable("dbo.Estudiantes");
            DropTable("dbo.Asignaturas");
            DropTable("dbo.Areas");
        }
    }
}
