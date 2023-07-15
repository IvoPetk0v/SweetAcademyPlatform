namespace SweetAcademy.Common
{
    public static class EntityValidationConstants
    {
        public static class Recipe
        {
            public const int NameMaxLength = 100;
            public const int NameMinLength = 3;

            public const int DescriptionMaxLength = 5000;
            public const int DescriptionMinLength = 30;

            public const int StepsMaxLength = 10000;
            public const int StepsMinLength = 30;
        }

        public static class Training
        {
            public const int NameMaxLength = 100;
            public const int NameMinLength = 10;
        }

        public static class Product
        {
            public const int NameMaxLength = 500;
            public const int NameMinLength = 5;

            public const int UnitMaxLength = 6;
            public const int UnitMinLength = 1;
        }
       
    }
}
