namespace PaELFINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class variasrelaciones : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProfesorAsignaturas", "Profesor_ProfesorID", "dbo.Profesors");
            DropForeignKey("dbo.ProfesorAsignaturas", "Asignatura_asignaturaID", "dbo.Asignaturas");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Profesors", new[] { "TipodeContrato_TipodeContratoId" });
            RenameColumn(table: "dbo.Profesors", name: "TipodeContrato_TipodeContratoId", newName: "TipodeContratoId");
            DropPrimaryKey("dbo.Asignaturas");
            AddColumn("dbo.Asignaturas", "asigID", c => c.Int(nullable: false));
            AddColumn("dbo.Seccions", "asignaturaID", c => c.Int(nullable: false));
            AddColumn("dbo.Seccions", "cod_area", c => c.String(maxLength: 128));
            AlterColumn("dbo.Asignaturas", "asignaturaID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Profesors", "TipodeContratoId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Asignaturas", "asignaturaID");
            CreateIndex("dbo.Asignaturas", "asigID");
            CreateIndex("dbo.Profesors", "TipodeContratoId");
            CreateIndex("dbo.Seccions", "asignaturaID");
            CreateIndex("dbo.Seccions", "cod_area");
            AddForeignKey("dbo.Asignaturas", "asigID", "dbo.Asignaturas", "asignaturaID");
            AddForeignKey("dbo.Seccions", "cod_area", "dbo.Areas", "cod_area");
            AddForeignKey("dbo.Seccions", "asignaturaID", "dbo.Asignaturas", "asignaturaID");
            AddForeignKey("dbo.ProfesorAsignaturas", "Profesor_ProfesorID", "dbo.Profesors", "ProfesorID");
            AddForeignKey("dbo.ProfesorAsignaturas", "Asignatura_asignaturaID", "dbo.Asignaturas", "asignaturaID");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProfesorAsignaturas", "Asignatura_asignaturaID", "dbo.Asignaturas");
            DropForeignKey("dbo.ProfesorAsignaturas", "Profesor_ProfesorID", "dbo.Profesors");
            DropForeignKey("dbo.Seccions", "asignaturaID", "dbo.Asignaturas");
            DropForeignKey("dbo.Seccions", "cod_area", "dbo.Areas");
            DropForeignKey("dbo.Asignaturas", "asigID", "dbo.Asignaturas");
            DropIndex("dbo.Seccions", new[] { "cod_area" });
            DropIndex("dbo.Seccions", new[] { "asignaturaID" });
            DropIndex("dbo.Profesors", new[] { "TipodeContratoId" });
            DropIndex("dbo.Asignaturas", new[] { "asigID" });
            DropPrimaryKey("dbo.Asignaturas");
            AlterColumn("dbo.Profesors", "TipodeContratoId", c => c.Byte());
            AlterColumn("dbo.Asignaturas", "asignaturaID", c => c.Int(nullable: false));
            DropColumn("dbo.Seccions", "cod_area");
            DropColumn("dbo.Seccions", "asignaturaID");
            DropColumn("dbo.Asignaturas", "asigID");
            AddPrimaryKey("dbo.Asignaturas", "asignaturaID");
            RenameColumn(table: "dbo.Profesors", name: "TipodeContratoId", newName: "TipodeContrato_TipodeContratoId");
            CreateIndex("dbo.Profesors", "TipodeContrato_TipodeContratoId");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProfesorAsignaturas", "Asignatura_asignaturaID", "dbo.Asignaturas", "asignaturaID", cascadeDelete: true);
            AddForeignKey("dbo.ProfesorAsignaturas", "Profesor_ProfesorID", "dbo.Profesors", "ProfesorID", cascadeDelete: true);
        }
    }
}
