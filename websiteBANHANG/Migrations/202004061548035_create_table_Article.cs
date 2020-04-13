namespace websiteBANHANG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_Article : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        ArticleID = c.String(nullable: false, maxLength: 10, unicode: false),
                        Author = c.String(maxLength: 50),
                        ArticleContent = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.ArticleID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Article");
        }
    }
}
