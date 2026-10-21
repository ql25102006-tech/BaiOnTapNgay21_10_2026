namespace Bai4_7_MdiApplication
{
    public class Student
    {
        public string StudentId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = "Nam";
        public string AvatarPath { get; set; } = string.Empty;

        public Student() { }

        public Student(string studentId, string fullName, int age, string gender, string avatarPath = "")
        {
            StudentId = studentId;
            FullName = fullName;
            Age = age;
            Gender = gender;
            AvatarPath = avatarPath;
        }
    }

    public class Product
    {
        public string ProductId { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product() { }

        public Product(string id, string name, string category, decimal price, int quantity)
        {
            ProductId = id;
            ProductName = name;
            Category = category;
            Price = price;
            Quantity = quantity;
        }
    }
}
