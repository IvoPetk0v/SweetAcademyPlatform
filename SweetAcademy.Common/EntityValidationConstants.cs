namespace SweetAcademy.Common
{
    public static class EntityValidationConstants
    {
        //Recipe
        public const int RecipeNameMaxLength = 100;
        public const int RecipeNameMinLength = 3;

        public const int RecipeDescriptionMaxLength = 5000;
        public const int RecipeDescriptionMinLength = 30;

        public const int RecipeStepsMaxLength = 10000;
        public const int RecipeStepsMinLength = 30;

        //Training
        public const int TrainingNameMaxLength = 100;
        public const int TrainingNameMinLength = 10;
    }
}
