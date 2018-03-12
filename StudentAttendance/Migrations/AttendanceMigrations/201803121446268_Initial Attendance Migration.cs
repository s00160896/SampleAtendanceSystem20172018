namespace StudentAttendance.Migrations.AttendanceMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAttendanceMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttendanceLists",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        AttendanceOf_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Attendances", t => t.AttendanceOf_id)
                .Index(t => t.AttendanceOf_id);
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Day = c.String(),
                        TimeSlot = c.Time(nullable: false, precision: 7),
                        DeliveredBy_id = c.Int(),
                        DeliveryOf_id = c.Int(),
                        StudentEnrolled_id = c.Int(),
                        Attendance_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Lecturers", t => t.DeliveredBy_id)
                .ForeignKey("dbo.Modules", t => t.DeliveryOf_id)
                .ForeignKey("dbo.Students", t => t.StudentEnrolled_id)
                .ForeignKey("dbo.Attendances", t => t.Attendance_id)
                .Index(t => t.DeliveredBy_id)
                .Index(t => t.DeliveryOf_id)
                .Index(t => t.StudentEnrolled_id)
                .Index(t => t.Attendance_id);
            
            CreateTable(
                "dbo.Lecturers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        EnrollmentDate = c.DateTime(nullable: false),
                        Module_id = c.Int(),
                        Student_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Modules", t => t.Module_id)
                .ForeignKey("dbo.Students", t => t.Student_id)
                .Index(t => t.Module_id)
                .Index(t => t.Student_id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        RegistrationID = c.String(),
                        FirstName = c.String(),
                        SecondName = c.Int(nullable: false),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AttendanceLists", "AttendanceOf_id", "dbo.Attendances");
            DropForeignKey("dbo.Deliveries", "Attendance_id", "dbo.Attendances");
            DropForeignKey("dbo.Enrollments", "Student_id", "dbo.Students");
            DropForeignKey("dbo.Deliveries", "StudentEnrolled_id", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "Module_id", "dbo.Modules");
            DropForeignKey("dbo.Deliveries", "DeliveryOf_id", "dbo.Modules");
            DropForeignKey("dbo.Deliveries", "DeliveredBy_id", "dbo.Lecturers");
            DropIndex("dbo.Enrollments", new[] { "Student_id" });
            DropIndex("dbo.Enrollments", new[] { "Module_id" });
            DropIndex("dbo.Deliveries", new[] { "Attendance_id" });
            DropIndex("dbo.Deliveries", new[] { "StudentEnrolled_id" });
            DropIndex("dbo.Deliveries", new[] { "DeliveryOf_id" });
            DropIndex("dbo.Deliveries", new[] { "DeliveredBy_id" });
            DropIndex("dbo.AttendanceLists", new[] { "AttendanceOf_id" });
            DropTable("dbo.Students");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Modules");
            DropTable("dbo.Lecturers");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Attendances");
            DropTable("dbo.AttendanceLists");
        }
    }
}
