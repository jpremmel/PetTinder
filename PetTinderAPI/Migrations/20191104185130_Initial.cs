using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetTinderAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    PetId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Species = table.Column<string>(nullable: true),
                    Breed = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    LookingFor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.PetId);
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "PetId", "Age", "Bio", "Breed", "Gender", "LookingFor", "Name", "Species" },
                values: new object[,]
                {
                    { 1, 6, "Grey, lanky, fluffy, distinct underbite. Favorite things: Chicken, tortellini, beach, snow, her toys, being cozy. Least favorite things: Grooming, vet visits, guitars, being cold, being alone.", "Shih-tzu mix", "Female", null, "Sylvie", "Dog" },
                    { 15, 6, "Has an adorable moustache. Favorite things: sleeping. Least favorite things: screaming toddlers.", "Domestic short hair", "Male", null, "Ashford", "Cat" },
                    { 14, 3, "The best dog ever. Favorite things: hikes. Least favorite things: shower.", "Coonhound/Lab", "Female", null, "Kima", "Dog" },
                    { 13, 1, "Dangerous. Favorite things: Total domination, sleeping. Least favorite things: Being locked up.", "Unknown", "Male", null, "Stripes", "Cat" },
                    { 12, 4, "Fluffy, talkative, will steal your cheese. Favorite things: Pets and butt scratches. Least favorite things: Thunder and Vacuums.", "Russian Blue Mix", "Female", null, "Mocha", "Cat" },
                    { 11, 3, "Very Curious, loves to get into trouble spots. Favorite things: Climbing Branches. Least favorite things: Fast Movement.", "Ball Python", "Female", null, "Uwa", "Snake" },
                    { 10, 2, "Ridiculously fluffy and adorable, and knows it. Favorite things: All squeeky toys. Least favorite things: Limes.", "Australian Shepherd", "Female", null, "Molly", "Dog" },
                    { 16, 2, "Very sassy when restless but irresistably cute when sleepy. Favorite things: Paper bags, boxes, being gently stroked on the nose while falling asleep. Least favorite things: Sylvie.", "Mixed Breed Maine Coon", "Male", null, "Jasper", "Cat" },
                    { 9, 4, "Wren is a red heeler that loves to pick on other dogs. Favorite things: Wren loves chasing her favorite toy at the park, she loves belly rubs, and cheese. Least favorite things: Rain and being told what to do", "Australian Cattledog", "Female", null, "Wren", "Dog" },
                    { 7, 1, "Mau is friendly to a fault. Favorite things: Mau enjoys taking naps and climbing house plants. Least favorite things: Rain and being told what to do.", "Medium-hair Domestic Feline", "Female", null, "Mau", "Cat" },
                    { 6, 5, "A Scooby Doo kinda guy looking for his Nova. Favorite things: Itch, eat all the human food scraps, long walks in the neighborhood, tennis balls. Least favorite things: Boxes, rain, baths, anything outdoors (except snow).", "German Shepard 1st Generation German-American", "Male", null, "Roscoe", "Dog" },
                    { 5, 6, "A fine boi looking for his furrever girl. Favorite things: His blanket, chirping at birds and squirrels, snuggling on your lap, licking his butt. Least favorite things: The vacuum, being picked up, having his nails clipped.", "Short-hair Domestic Feline", "Male", null, "Winston", "Cat" },
                    { 4, 7, "Lovebug, Angel, Shy. Favorite things: Snuggles, Gravy, Treats, Feather. Least favorite things: Loud noises, Strangers, Sudden movements, Vacuum.", "Medium-hair Domestic Feline", "Male", null, "Toad", "Cat" },
                    { 3, 5, "Floofy McCuddlebug, Diva. Favorite Things: naps, snacks, being the little spoon, screaming. Least Favorite Things: Toe touches, Watching his brother get affection, Being hungry", "Long-hair Domestic Feline", "Male", null, "Chunk", "Cat" },
                    { 2, 7, "lazy bum. favorite things: yogurt, cheese, carrots, sleep. least favorite things: grooming, vet visits, raspberries (not the food), being alone.", "Shih-tzu", "Female", null, "Bridget", "Dog" },
                    { 8, 12, "A scary looking dog that is a true sweetheart. Favorite things: Jasper loves stuffed toys, food, cheese, and water. Least favorite things: Rain. Loud Noises.", "Dutch Shepherd", "Male", null, "Jasper", "Dog" },
                    { 17, 5, "#1 Handsy Boy. Favorite things: Wearing clothes and playing with the hose. Least favorite things: strangers, other dogs playing with his toys.", "Dachshund mix", "Male", null, "Levi", "Dog" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");
        }
    }
}
