using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspCourse.Models;
using AspCourse.Models.database.entity;
using Microsoft.AspNetCore.Authorization;

namespace AspCourse.Controllers
{
    public class ChatsController : Controller
    {
        private readonly ApplicationContext _context;

        public ChatsController(ApplicationContext context)
        {
            _context = context;
        }
        private void initDataView()
        {
            string name = HttpContext.User.Identity.Name;
            ViewData["Account"] = $"{name}!";
        }

        // GET: Chats
        [Authorize]
        public async Task<IActionResult> Index()
        {
            initDataView();

            var user = _context.Users.Include(a => a.Chats).First(a => a.Email.Equals(HttpContext.User.Identity.Name));

            if (user.Chats == null) return View(new List<Chat>());

            return View(user.Chats);
        }

        // GET: Chats/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            initDataView();
            if (id == null)
            {
                return NotFound();
            }

            var chat = await _context.Chats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chat == null)
            {
                return NotFound();
            }

            return View(chat);
        }

        // GET: Chats/Create
        public IActionResult Create()
        {
            initDataView();
            return View();
        }

        private User GetUser()
        {

            try
            {
                if (_context.Users.Any(a => a.Email.Equals(HttpContext.User.Identity.Name)))
                    return _context.Users.First(a => a.Email.Equals(HttpContext.User.Identity.Name));
                else return null; 
            }
            catch (Exception)
            {
                return null;
            }

        }

        // POST: Chats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Name,Date,ChatType")] Chat chat)
        {
            initDataView();
            if (ModelState.IsValid)
            {
                var currentUser = GetUser();
                chat.UserId = currentUser.Id;
                chat.User = currentUser;
                chat.ChatMembers = new List<ChatMember>() { new ChatMember(){
                                                                Chat = chat,
                                                                ChatId = chat.Id,
                                                                IsAdmin = true,
                                                                User = currentUser,
                                                                UserId = currentUser.Id
                                                           }
                };

                _context.Add(chat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chat);
        }

        // GET: Chats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            initDataView();
            if (id == null)
            {
                return NotFound();
            }

            var chat = await _context.Chats.FindAsync(id);
            if (chat == null)
            {
                return NotFound();
            }
            return View(chat);
        }

        // POST: Chats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Date,ChatType")] Chat chat)
        {
            initDataView();
            if (id != chat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatExists(chat.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(chat);
        }

        // GET: Chats/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            initDataView();
            if (id == null)
            {
                return NotFound();
            }

            var chat = await _context.Chats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chat == null)
            {
                return NotFound();
            }

            return View(chat);
        }

        // POST: Chats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            initDataView();
            var chat = await _context.Chats.FindAsync(id);
            _context.Chats.Remove(chat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddUser(int? id)
        {
            initDataView();
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.IdChat = id;

            var users = await _context.Users.Include(a => a.Chats).Include(a => a.ChatMembers).Where(a => !a.ChatMembers.Any(c => c.UserId.Equals(a.Id) && c.IsAdmin)).ToListAsync();

            ViewBag.Chat = _context.Chats.Include(a => a.ChatMembers).First(a => a.Id.Equals(id));

            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> AddUserForChat(int id, int idUser)
        {
            initDataView();
            if (!_context.Chats.Any(a => a.Id.Equals(id)))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var chat = _context.Chats.Include(c => c.ChatMembers).First(a => a.Id.Equals(id));

                    chat.ChatMembers.Add(new ChatMember()
                    {
                        Chat = chat,
                        ChatId = chat.Id,
                        IsAdmin = false,
                        User = _context.Users.Find(idUser),
                        UserId = idUser
                    });

                    _context.Update(chat);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.IdChat = id;
            var users = await _context.Users.Include(a => a.Chats).Include(a => a.ChatMembers).Where(a => !a.ChatMembers.Any(c => c.UserId.Equals(a.Id) && c.IsAdmin)).ToListAsync();

            ViewBag.Chat = _context.Chats.Include(a => a.ChatMembers).First(a => a.Id.Equals(id));

            return View("AddUser", users);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteUserFromChat(int? id, int idUser)
        {
            initDataView();
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.IdChat = id;
            var users = await _context.Users.Include(a => a.Chats).Include(a => a.ChatMembers).Where(a => !a.ChatMembers.Any(c => c.UserId.Equals(a.Id) && c.IsAdmin)).ToListAsync();

            ViewBag.Chat = _context.Chats.Include(a => a.ChatMembers).First(a => a.Id.Equals(id));
            _context.ChatMembers.Remove(_context.ChatMembers.First(a => a.ChatId.Equals(id) && a.UserId.Equals(idUser)));
            _context.SaveChanges();

            return View("AddUser", users);
        }

        public async Task<IActionResult> ShowMembers(int? id)
        {
            initDataView();
            var applicationContext = _context.ChatMembers.Include(c => c.Chat).Include(c => c.User).Where(a => a.ChatId.Equals(id));
            return View("ShowMembers", await applicationContext.ToListAsync());
        }

        public async Task<IActionResult> MessageHistory(int? id)
        {
            initDataView();
            var applicationContext = _context.Messages.Include(m => m.Chat).Where(a => a.ChatId.Equals(id));
            return View("HistoryMessage", await applicationContext.ToListAsync());
        }

        private bool ChatExists(int id)
        {
            return _context.Chats.Any(e => e.Id == id);
        }
    }
}
