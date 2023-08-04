
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetAcademy.Data.Migrations;
using SweetAcademy.Data.Models;

namespace SweetAcademy.Data.Configurations
{
    public class RecipeEntityConfig : IEntityTypeConfiguration<Recipe>
    {

        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.Property(p => p.Active).HasDefaultValue(true);

        }

        public static HashSet<Recipe> Seed()
        {
            HashSet<Recipe> seeds = new HashSet<Recipe>()
        {
            new Recipe()
            {
                Id = 1,
                Description = "Bake an impressive dinner party dessert with minimum fuss – these chocolate puddings, also known as chocolate fondant or lava cake, have a lovely gooey center",
                ImageUrl = "https://img.freepik.com/free-vector/chocolate-lava-cake-with-raspberry-sticker-isolated-white-background_1308-65607.jpg?w=740&t=st=1690710465~exp=1690711065~hmac=c96a6d3712a020c5968f3facf16b2b30de62319e54a40295bdf134c02fef733a",
                Name = "Lava Cake",
                Active = true,

                StepsJson = "[\"Heat oven to 200C/180C fan/gas 6. Butter 6 dariole moulds or basins well and place on a baking tray.\",\"Carefully run a knife around the edge of each pudding, then turn out onto serving plates and serve with single cream.\"]"
            },
            new Recipe()
            {
                Id = 2,
                Description = "Dairy-free and egg-free, this delicious ice cream is surprisingly rich and indulgent. Use whatever add-ins you like in this dairy-free ice cream; a fantastic base recipe that's super easy!",
                ImageUrl = "https://img.freepik.com/free-vector/ice-cream-cone-cartoon-icon-illustration-sweet-food-icon-concept-isolated-flat-cartoon-style_138676-2924.jpg?w=740&t=st=1690915084~exp=1690915684~hmac=541a6d2f00afd0f44bf7033fbbb68151944f853d57559807362364812e0bef60",
                Name = "VEGAN ICE CREAM",
                Active = true,

                StepsJson = "[\"Blend: In a blender, add all ingredients and blend on high until thick and creamy, 1-2 min. Transfer mixture to an airtight container and chill 2-4 hours.\",\"Freeze: May serve immediately for a frozen custard-like texture that's ultra creamy, smooth, and soft. Otherwise, transfer ice cream to an airtight container and freeze 30-60 minutes for a firmer texture. If frozen much longer, it will need thaw time at room temp before serving (actual thaw time depends on your room temp.)\"]",

            },
        };
            return seeds;
        }
    }
}
