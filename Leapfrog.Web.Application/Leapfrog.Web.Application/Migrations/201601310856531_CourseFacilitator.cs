namespace Leapfrog.Web.Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseFacilitator : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Facilitator_Id", "dbo.Facilitators");
            DropIndex("dbo.Courses", new[] { "Facilitator_Id" });
            DropColumn("dbo.Courses", "Facilitator_Id");
        }
        
        public override void Down()
        {
            
        }
    }
}
