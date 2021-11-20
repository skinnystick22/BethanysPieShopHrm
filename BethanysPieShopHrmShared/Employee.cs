using System.ComponentModel.DataAnnotations;

namespace BethanysPieShopHrmShared;

public class Employee
{
    public int EmployeeId { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "First name is too long.")]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "Last name too long.")]
    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }
    [Required] [EmailAddress] public string Email { get; set; }
    public string Street { get; set; }
    public string Zip { get; set; }
    public string City { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public string PhoneNumber { get; set; }
    public bool Smoker { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public Gender Gender { get; set; }

    [MaxLength(1000, ErrorMessage = "Comment length cannot be longer than 1000 characters.")]
    public string Comment { get; set; }

    public DateTime? JoinedDate { get; set; }
    public DateTime? ExitDate { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public int JobCategoryId { get; set; }
    public JobCategory JobCategory { get; set; }
}