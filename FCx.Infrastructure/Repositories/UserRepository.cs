using Dapper;
using FCx.Domain.Entities;
using FCx.Domain.Interfaces;

namespace FCx.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DapperContext _context;

    public UserRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync(Pager pager)
    {
        var query = @"SELECT * FROM Users WHERE Status = 1 ORDER BY [Id] DESC
                      OFFSET @Offset ROWS
                      FETCH NEXT @Next ROWS ONLY";
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryAsync<User>(query, pager);
            return result.ToList();
        }
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var query = "SELECT * FROM Users WHERE Id = @Id";
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryFirstOrDefaultAsync<User>(query, new { id });
            return result;
        }
    }

    public async Task<User> AddAsync(User user)
    {
        var query = @"INSERT INTO Users (Name, Document, Login, Password, Email, Phone, MotherName, Status, DateBirth, CreatedAt, UpdatedAt, Generation)
                    VALUES (@Name, @Document, @Login, @Password, @Email, @Phone, @MotherName, @Status, @DateBirth, @CreatedAt, @UpdatedAt, @Generation)";
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.ExecuteAsync(query, user);
            return result > 0 ? user : new User();
        }
    }

    public async Task<User> UpdateAsync(User user)
    {
        var query = @"UPDATE Users SET Name = @Name, Document = @Document, Login = @Login,
                    Password = @Password, Email = @Email, Phone = @Phone, MotherName = @MotherName,
                    Status = @Status, DateBirth = @DateBirth, CreatedAt = @CreatedAt,
                    UpdatedAt = @UpdatedAt, Generation = @Generation WHERE Id = @Id";
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.ExecuteAsync(query, user);
            return result > 0 ? user : new User();
        }
    }

    public async Task<int> DeleteAsync(int id)
    {
        var query = "DELETE FROM Users WHERE Id = @Id";
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.ExecuteAsync(query, new { Id = id });
            return result;
        }
    }

    public async Task DeleteSelectedAsync(int[] userIds)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = "UPDATE Users SET Status = 0 WHERE Id IN @UserIds";
            await connection.ExecuteAsync(query, new { UserIds = userIds });
        }
    }

    public async Task<User> GetUserByUsernameAsync(string username)
    {
        var query = "SELECT * FROM Users WHERE Login = @Username AND Status = 1";
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryFirstOrDefaultAsync<User>(query, new { Username = username });
            return result;
        }
    }

    public async Task<User> GetUserByDataAsync(ResetPasswordRequest resetPasswordRequest)
    {
        var query = "SELECT * FROM Users WHERE Login = @Login And Document = @Document AND MotherName = @MotherName AND Status = 1";
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.QueryFirstOrDefaultAsync<User>(query, resetPasswordRequest);
            return result;
        }
    }

    public async Task UpdatePasswordAsync(LoginRequest loginRequest)
    {
        var query = "UPDATE Users SET Password = @Password WHERE Login = @Username";
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, loginRequest);
        }
    }

}
