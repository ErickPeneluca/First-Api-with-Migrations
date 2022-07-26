using Microsoft.AspNetCore.Mvc;
using Usuario.Models;
using Usuario.Repository.Interfaces;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UsuarioController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var users = await _repository.FindUsers();
            return users.Any()
                ? Ok(users)
                : NoContent();
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var users = await _repository.FindUser(id);
            return users != null
                ? Ok(users)
                : NotFound("User not found");
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            _repository.AddUser(user);
            return await _repository.SaveChangesAsync()
                ? Ok(user)
                : BadRequest("Error to save user");
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, User user)
        {
            var userdb = await _repository.FindUser(id);
            if (userdb == null) return NotFound("User not found");

            userdb.Nome = user.Nome ?? userdb.Nome;
            userdb.DataNascimento = user.DataNascimento != new DateTime()
            ? user.DataNascimento : userdb.DataNascimento;

            _repository.EditUser(userdb);

            return await _repository.SaveChangesAsync()
               ? Ok("Üser edit sucessefuly")
               : BadRequest("Error to save user");
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var userdb = await _repository.FindUser(id);
            if (userdb == null) return NotFound("User not found");

            _repository.DelUser(userdb);
            return await _repository.SaveChangesAsync()
            ? Ok("Üser deleted sucessefuly")
            : BadRequest("Error to delete user");
        }
    }
}
