using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web3MusicStore.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    album_id = table.Column<string>(type: "NVARCHAR(32)", nullable: false),
                    name = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    billboard = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    artists = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    popularity = table.Column<int>(type: "int", nullable: true),
                    total_tracks = table.Column<int>(type: "int", nullable: false),
                    album_type = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    image_url = table.Column<string>(type: "NVARCHAR(600)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.album_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    artist_id = table.Column<string>(type: "NVARCHAR(32)", nullable: false),
                    name = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    followers = table.Column<int>(type: "int", nullable: true),
                    popularity = table.Column<int>(type: "int", nullable: true),
                    artist_type = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    main_genre = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    genres = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image_url = table.Column<string>(type: "NVARCHAR(600)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.artist_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Releases",
                columns: table => new
                {
                    artist_id = table.Column<string>(type: "NVARCHAR(32)", nullable: false),
                    album_id = table.Column<string>(type: "NVARCHAR(32)", nullable: false),
                    release_date = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    release_date_precision = table.Column<string>(type: "NVARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Releases", x => new { x.album_id, x.artist_id });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    song_id = table.Column<string>(type: "NVARCHAR(32)", nullable: false),
                    song_name = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    billboard = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    artists = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    release_date_precision = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    popularity = table.Column<int>(type: "int", nullable: true),
                    @explicit = table.Column<bool>(name: "explicit", type: "BOOLEAN(1)", nullable: true),
                    song_type = table.Column<string>(type: "NVARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.song_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    song_id = table.Column<string>(type: "NVARCHAR(32)", nullable: false),
                    album_id = table.Column<string>(type: "NVARCHAR(32)", nullable: false),
                    track_number = table.Column<int>(type: "int", nullable: false),
                    release_date = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    release_date_precision = table.Column<string>(type: "NVARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => new { x.song_id, x.album_id });
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Releases");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Tracks");
        }
    }
}
