using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodebitsBlog.Migrations
{
    /// <inheritdoc />
    public partial class IsFeaturedForPostView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Posts",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5c2820f-1e51-409b-8f90-5940b5004b2b", "AQAAAAIAAYagAAAAEGIm+JP6F2mPThqUhlfkOBsF1K5+qnraYjvFBS5/ToVy1ZfOgfcPW3BBD8LLhtUN8Q==", "a7568aa6-38cd-4bcd-8b48-6734e07eea42" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb5d7295-bbe4-43d7-a845-b09bc2efe8c8", "AQAAAAIAAYagAAAAEE2nfskm/bun5Xb0jHEBCtXJ9h8Cm0kqUXoOwld94Ip2FWgH10gYV7LWjD8tMnEKNQ==", "578ef4b0-d21c-4944-bb47-3e000f44e8c2" });
        }
    }
}
