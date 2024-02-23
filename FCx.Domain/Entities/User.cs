namespace FCx.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; } = null;
        public string? Login { get; set; } = null;
        public string? Password { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? Phone { get; set; } = null;
        public string? Document { get; set; } = null;
        public DateTime DateBirth { get; set; }
        public string? MotherName { get; set; } = null;
        public bool Status { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string? Generation { get; set; } = null!;

        public User()
        {
            Generation = GetGeneration(DateBirth);
        }
        
        public static string GetGeneration(DateTime dateBirth)
        {
            int birthYear = dateBirth.Year;

            if (birthYear <= 1945)
            {
                return "Silent Generation";
            }
            else if (birthYear <= 1964)
            {
                return "Baby Boomer";
            }
            else if (birthYear <= 1979)
            {
                return "Generation X";
            }
            else if (birthYear <= 1994)
            {
                return "Millennial";
            }
            else
            {
                return "Generation Z";
            }
        }
    }
}
