using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using QuintrixMVC.Models;

namespace QuintrixMVC.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
        private IQueryable<IdentityRole> _roles;
        private IQueryable<User> _users;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;

            _roles = _roleManager.Roles;
            _users = _userManager.Users;
        }

        // GET: Role/Index
        public async Task<IActionResult> Index()
        {
            return View(_roleManager.Roles);
        }

        // GET: Role/Details/Id
        public async Task<IActionResult> Details(string id)
        {
            var role = _roles.Where(r => r.Id == id).FirstOrDefault();
            if (role == null)
            {
                ModelState.AddModelError("", $"Role id {id} not found");
                return RedirectToAction("Index");
            }

            var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name);
            var usersNotInRole = _users.Where(u => !usersInRole.Contains(u)).ToList();

            return View(new RoleDetails(role.Id, usersInRole, usersNotInRole));
        }

        // POST: Role/Update
        [HttpPost]
        public async Task<IActionResult> Update(RoleUpdate roleUpdate)
        {
            var role = await _roleManager.FindByIdAsync(roleUpdate.RoleId);

            if (ModelState.IsValid)
            {
                foreach (var userId in roleUpdate.RejectionIds)
                {
                    var result = await _userManager.RemoveFromRoleAsync(_users.First(u => u.Id == userId), role.Name);
                    if (! result.Succeeded)
                    {
                        Errors(result);
                    }
                }
                foreach (var userId in roleUpdate.InvitationIds)
                {
                    var result = await _userManager.AddToRoleAsync(_users.First(u => u.Id == userId), role.Name);
                    if (! result.Succeeded)
                    {
                        Errors(result);
                    }
                }
            }
            
            return Redirect($"/Role/Details/{role.Id}");
        }

        // GET: Role/Create
        public async Task<IActionResult> Create() => View();

        // POST: Role/Create
        [HttpPost]
        public async Task<IActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                var roleCreateResult = await _roleManager.CreateAsync(new IdentityRole(name));
                if (roleCreateResult.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(roleCreateResult);
            }

            return View(name);
        }

        // GET: Role/Delete/id
        public async Task<IActionResult> Delete(string? id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "WHAT");

            return View("Index", _roleManager.Roles);
        }

        private void Errors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }

    public struct RoleDetails
    {
        public string Id { get; set; }
        public IEnumerable<User>? UsersInRole { get; set; }
        public IEnumerable<User>? UsersNotInRole { get; set; }

        public RoleDetails(string id, IEnumerable<User>? usersInRole, IEnumerable<User>? usersNotInRole)
        {
            Id = id;
            UsersInRole = usersInRole;
            UsersNotInRole = usersNotInRole;
        }
    } 

    public class RoleUpdate
    {
        public RoleUpdate() {}

        public string RoleId { get; set; } = "";
        public string[] InvitationIds { get; set; } = new string[0];
        public string[] RejectionIds { get; set; } = new string[0];
    }
}