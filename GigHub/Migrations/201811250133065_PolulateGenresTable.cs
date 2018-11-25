namespace GigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PolulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id, Name) Values (1, 'Jazz'), (2, 'Blues'), (3, 'Rock'), (4, 'Country')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres where Id IN (1, 2, 3, 4)");
        }
    }
}
