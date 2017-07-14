namespace PaELFINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandorelaciones : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Asignaturas");
            CreateTable(
                "dbo.ProfesorAsignaturas",
                c => new
                    {
                        Profesor_ProfesorID = c.Int(nullable: false),
                        Asignatura_asignaturaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Profesor_ProfesorID, t.Asignatura_asignaturaID })
                .ForeignKey("dbo.Profesors", t => t.Profesor_ProfesorID, cascadeDelete: true)
                .ForeignKey("dbo.Asignaturas", t => t.Asignatura_asignaturaID, cascadeDelete: true)
                .Index(t => t.Profesor_ProfesorID)
                .Index(t => t.Asignatura_asignaturaID);
            
            AddColumn("dbo.Asignaturas", "cod_area", c => c.String(maxLength: 128));
            AddColumn("dbo.Profesors", "TipodeContrato_TipodeContratoId", c => c.Byte());
            AddColumn("dbo.Seccions", "Profesor_ProfesorID", c => c.Int());
            AddColumn("dbo.Seccions", "Estudiante_EstudianteID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Asignaturas", "asignaturaID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Asignaturas", "asignaturaID");
            CreateIndex("dbo.Asignaturas", "cod_area");
            CreateIndex("dbo.Profesors", "TipodeContrato_TipodeContratoId");
            CreateIndex("dbo.Seccions", "Profesor_ProfesorID");
            CreateIndex("dbo.Seccions", "Estudiante_EstudianteID");
            AddForeignKey("dbo.Asignaturas", "cod_area", "dbo.Areas", "cod_area");
            AddForeignKey("dbo.Seccions", "Profesor_ProfesorID", "dbo.Profesors", "ProfesorID");
            AddForeignKey("dbo.Seccions", "Estudiante_EstudianteID", "dbo.Estudiantes", "EstudianteID");
            AddForeignKey("dbo.Profesors", "TipodeContrato_TipodeContratoId", "dbo.TipodeContratoes", "TipodeContratoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profesors", "TipodeContrato_TipodeContratoId", "dbo.TipodeContratoes");
            DropForeignKey("dbo.Seccions", "Estudiante_EstudianteID", "dbo.Estudiantes");
            DropForeignKey("dbo.Seccions", "Profesor_ProfesorID", "dbo.Profesors");
            DropForeignKey("dbo.ProfesorAsignaturas", "Asignatura_asignaturaID", "dbo.Asignaturas");
            DropForeignKey("dbo.ProfesorAsignaturas", "Profesor_ProfesorID", "dbo.Profesors");
            DropForeignKey("dbo.Asignaturas", "cod_area", "dbo.Areas");
            DropIndex("dbo.ProfesorAsignaturas", new[] { "Asignatura_asignaturaID" });
            DropIndex("dbo.ProfesorAsignaturas", new[] { "Profesor_ProfesorID" });
            DropIndex("dbo.Seccions", new[] { "Estudiante_EstudianteID" });
            DropIndex("dbo.Seccions", new[] { "Profesor_ProfesorID" });
            DropIndex("dbo.Profesors", new[] { "TipodeContrato_TipodeContratoId" });
            DropIndex("dbo.Asignaturas", new[] { "cod_area" });
            DropPrimaryKey("dbo.Asignaturas");
            AlterColumn("dbo.Asignaturas", "asignaturaID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Seccions", "Estudiante_EstudianteID");
            DropColumn("dbo.Seccions", "Profesor_ProfesorID");
            DropColumn("dbo.Profesors", "TipodeContrato_TipodeContratoId");
            DropColumn("dbo.Asignaturas", "cod_area");
            DropTable("dbo.ProfesorAsignaturas");
            AddPrimaryKey("dbo.Asignaturas", "asignaturaID");
        }
    }
}
