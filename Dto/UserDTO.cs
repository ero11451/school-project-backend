// Model for creating a new user
public class CreateUserModel
{
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}

// Model for updating a user
public class UpdateUserModel
{
    public required string UserName { get; set; }
    public required string Email { get; set; }
}
