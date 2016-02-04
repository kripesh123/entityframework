namespace Leapfrog.Web.Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Fees = c.Double(nullable: false),
                        Duration = c.Int(nullable: false),
                        DurationType = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        Facilitator_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Facilitators", t => t.Facilitator_Id)
                .Index(t => t.Facilitator_Id);
            
            CreateTable(
                "dbo.Facilitators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        ContactNo = c.String(),
                        Address = c.String(),
                        Bio = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Discount = c.Double(),
                        EnrolledDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        Course_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        ContactNo = c.String(),
                        Education = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        Enrollment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enrollments", t => t.Enrollment_Id)
                .Index(t => t.Enrollment_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "Enrollment_Id", "dbo.Enrollments");
            DropForeignKey("dbo.Enrollments", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Courses", "Facilitator_Id", "dbo.Facilitators");
            DropIndex("dbo.Payments", new[] { "Enrollment_Id" });
            DropIndex("dbo.Enrollments", new[] { "Student_Id" });
            DropIndex("dbo.Enrollments", new[] { "Course_Id" });
            DropIndex("dbo.Courses", new[] { "Facilitator_Id" });
            DropTable("dbo.Payments");
            DropTable("dbo.Students");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Facilitators");
            DropTable("dbo.Courses");
        }
    }
}
